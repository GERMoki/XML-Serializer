using System.Collections.Generic;

using DataClasses;
using XMLHandling;

namespace XMLReadWriteTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> list;

            // init and write XML
            list = InitList();
            XMLHandler.WriteXML(list, "SerialisationInit");
            list.Clear();

            // get, update and write back
            list = XMLHandler.GetXML<Book>("SerialisationInit");
            foreach (Book b in list) {
                b.title = b.title.ToUpper();
            }
            XMLHandler.WriteXML(list, "SerialisationUpdated");
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
    }
}
