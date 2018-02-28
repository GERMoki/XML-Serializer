using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace XMLReadWriteTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> list;

            // init and write XML
            list = InitList();
            WriteXML(list, "SerialisationInit");
            list.Clear();

            // get, update and write back
            list = GetXML<Book>("SerialisationInit");
            foreach (Book b in list) {
                b.title = b.title + " hallo";
            }
            WriteXML(list, "SerialisationUpdated");
        }
        
        public static List<Book> InitList()
        {
            List<Book> newList = new List<Book>();

            for (int i = 1; i < 100; i++)
            {
                Book ele = new Book()
                {
                    title = "Name " + i.ToString("000"),
                    id = i,
                    author = new Author()
                    {
                        age = i,
                        name = "Name " + (i * 2).ToString("000")
                    }
                };

                newList.Add(ele);
            }
            return newList;
        }

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

public class Book
{
    [XmlElement("Titel")]
    public String title;

    [XmlElement("ID")]
    public int id;

    public Author author;
}

public class Author
{

    public string name;

   [XmlElement("Alter")]
    public int age;
}