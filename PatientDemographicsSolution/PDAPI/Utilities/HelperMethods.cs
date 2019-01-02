using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PDAPI.Utilities
{
    public class HelperMethods
    {
        //This Generic method help to convert the .Net object to XML String
        public static string ObjectToXMLString<T>(T obj)
        {
            string xml = null;
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(sw, obj);
                try
                {
                    xml = sw.ToString();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return xml;
        }

        //This Generic method help to convert the XML string to .Net object
        public static T XMLStringToObject<T>(string xmlString)
        {
            var xmlserializer = new XmlSerializer(typeof(T));
            using (var textReader = new StringReader(xmlString))
            {
                using (var xmlReader = XmlReader.Create(textReader))
                {
                    return (T)xmlserializer.Deserialize(xmlReader);
                }
            }
        }
    }
}