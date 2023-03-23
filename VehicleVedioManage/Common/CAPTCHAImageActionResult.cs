using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;

namespace VehicleVedioManage.Common
{
    public class CAPTCHAImageActionResult : ActionResult
    {
        public Color BackGroundColor { get; set; }
        public Color RandomTextColor { get; set; }
        public string RandomWord { get; set; }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            RenderCAPTCHAImage(context);
            return Task.CompletedTask;
        }

        private void RenderCAPTCHAImage(ActionContext /*ControllerContext*/ context)
        {
            Bitmap objBMP = new Bitmap(80, 20);//验证码背景图大小设定
            Graphics objGraphics = Graphics.FromImage(objBMP);

            //objGraphics.Clear(BackGroundColor);
            objGraphics.Clear(Color.AliceBlue);//验证码背景图颜色

            // Instantiate object of brush with black color
            //SolidBrush objBrush = new SolidBrush(RandomTextColor);
            SolidBrush objBrush = new SolidBrush(Color.Chocolate);//验证码文字颜色

            Font objFont = null;
            int a;
            String myFont, str;

            //Creating an array for most readable yet cryptic fonts for OCR's
            // This is entirely up to developer's discretion
            String[] crypticFonts = new String[11];

            crypticFonts[0] = "Arial";
            crypticFonts[1] = "Verdana";
            crypticFonts[2] = "Comic Sans MS";
            crypticFonts[3] = "Impact";
            crypticFonts[4] = "Haettenschweiler";
            crypticFonts[5] = "Lucida Sans Unicode";
            crypticFonts[6] = "Garamond";
            crypticFonts[7] = "Courier New";
            crypticFonts[8] = "Book Antiqua";
            crypticFonts[9] = "Arial Narrow";
            crypticFonts[10] = "Estrangelo Edessa";

            //Loop to write the characters on image  
            // with different fonts.
            for (a = 0; a <= RandomWord.Length - 1; a++)
            {
                myFont = crypticFonts[new Random().Next(a)];
                objFont = new Font(myFont, 12, FontStyle.Bold | FontStyle.Italic);//(第二参数为验证码文字大小)
                str = RandomWord.Substring(a, 1);
                objGraphics.DrawString(str, objFont, objBrush, a * 20, 5);
                objGraphics.Flush();
            }
            context.HttpContext.Response.ContentType = "image/GF";
            var _httpResponse = context.HttpContext.Response;
            objBMP.Save(_httpResponse?.Body, ImageFormat.Gif);
            objFont.Dispose();
            objGraphics.Dispose();
            objBMP.Dispose();

        }
    }
}
