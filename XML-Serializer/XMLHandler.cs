using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace XMLHandling
{
    class XMLHandler
    {
        public static void WriteXML<T>(List<T> listToWrite, string filename)
        {
            XmlSerializer writer = new XmlSerializer(listToWrite.GetType());

            var path = Directory.GetCurrentDirectory() + "//" + filename + ".xml";
            FileStream file = File.Create(path);

            writer.Serialize(file, listToWrite);
            file.Close();
        }

        public static List<T> GetXML<T>(string filename)
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<T>));

            var path = Directory.GetCurrentDirectory() + "//" + filename + ".xml";
            FileStream file = File.OpenRead(path);

            List<T> deserializedList = (List<T>)reader.Deserialize(file);
            file.Close();

            return deserializedList;
        }
    }
}
