using System;
using System.Xml.Serialization;

namespace DataClasses
{
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
}
