using System.Collections;
using System.Reflection;

namespace VehicleVedioManage.Common
{
    /// <summary>
    /// 属性处理
    /// </summary>
    public class PropertyHandler
    {
        #region Set Properties
        public static void SetProperties(PropertyInfo[] fromFields,
                                         PropertyInfo[] toFields,
                                         object fromRecord,
                                         object toRecord)
        {
            PropertyInfo fromField = null;
            PropertyInfo toField = null;
            try
            {

                if (fromFields == null)
                {
                    return;
                }
                if (toFields == null)
                {
                    return;
                }

                for (int f = 0; f < fromFields.Length; f++)
                {

                    fromField = (PropertyInfo)fromFields[f];

                    for (int t = 0; t < toFields.Length; t++)
                    {

                        toField = (PropertyInfo)toFields[t];

                        if (fromField.Name != toField.Name)
                        {
                            continue;
                        }

                        toField.SetValue(toRecord,
                                         fromField.GetValue(fromRecord, null),
                                         null);
                        break;

                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Set Properties
        public static void SetProperties(PropertyInfo[] fromFields,
                                         object fromRecord,
                                         object toRecord)
        {
            PropertyInfo fromField = null;

            try
            {

                if (fromFields == null)
                {
                    return;
                }

                for (int f = 0; f < fromFields.Length; f++)
                {

                    fromField = (PropertyInfo)fromFields[f];

                    fromField.SetValue(toRecord,
                                       fromField.GetValue(fromRecord, null),
                                       null);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        public static void copyProperties(Object obj, Hashtable ht)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();


            foreach (PropertyInfo p in properties)
            {
                string fieldType = p.PropertyType.Name;
                if (ht.ContainsKey(p.Name))
                {
                    object value = ht[p.Name];
                    if (value == null)
                    {
                        continue;
                    }
                    String strValue = "" + value;
                    if (fieldType == "Int32")
                    {
                        int temp = 0;
                        if (String.IsNullOrEmpty(strValue) == false)
                            temp = Int32.Parse(strValue);

                        //object temp1 = p.GetValue(p, null);
                        p.SetValue(obj, temp, null);
                    }
                    else if (fieldType == "Double")
                    {
                        Double temp = 0;
                        if (String.IsNullOrEmpty(strValue) == false)
                            temp = Double.Parse(strValue);
                        //object temp1 = p.GetValue(p, null);
                        p.SetValue(obj, temp, null);
                    }
                    else if (fieldType == "DateTime" || fieldType == "Nullable`1")
                    {
                        if (value.GetType().Name == "String")
                        {
                            //Date dt = String.Format("yyyy-MM-dd", (string)obj); 

                            DateTime dt = Convert.ToDateTime(value);
                            p.SetValue(obj, dt, null);
                        }
                        //else
                        //    p.SetValue(obj, value, null);
                    }
                    else if (fieldType == "Boolean")
                    {
                        if (value.ToString().ToUpper() == "TRUE" || value.ToString() == "1")
                        {
                            p.SetValue(obj, true, null);
                        }
                        else
                        {
                            p.SetValue(obj, false, null);
                        }
                    }
                    else
                        p.SetValue(obj, value, null);
                }
            }
        }
    }
}
