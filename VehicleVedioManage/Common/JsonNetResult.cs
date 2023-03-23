using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VehicleVedioManage.Common
{
    public class JsonNetResult : ActionResult
    {

        public System.Text.Encoding ContentEncoding { get; set; }

        public string ContentType { get; set; }

        public object Data { get; set; }



        public JsonSerializerSettings SerializerSettings { get; set; }

        public Formatting Formatting { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public JsonNetResult()
        {
            SerializerSettings = new JsonSerializerSettings();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_data"></param>
        public JsonNetResult(Object _data)
        {

            SerializerSettings = new JsonSerializerSettings();
            Data = _data;
        }

        public override void ExecuteResult(ActionContext context)
        {
            
            if (context == null)
                throw new ArgumentNullException("context");
            var response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType)
              ? ContentType
              : "application/json";
            if (ContentEncoding != null)
                //response.ContentEncoding = ContentEncoding;
            if (Data != null)
            {
                    TextWriter _textWriter = null;// response.Body;
                JsonTextWriter writer = new JsonTextWriter(_textWriter) { Formatting = Formatting };
                JsonSerializer serializer = JsonSerializer.Create(SerializerSettings);
                serializer.Serialize(writer, Data);
                writer.Flush();

            }
        }
    }

}
