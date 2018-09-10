using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Serialization
{
    [Serializable]
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }

        public Book() { }
        public Book(string author, string title, int price)
        {
            Author = author;
            Title = title;
            Price = price;
        }
    }
}
