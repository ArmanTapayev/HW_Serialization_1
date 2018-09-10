using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class PC
    {
        public string Brand { get; set; }
        public string Number { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public PC(string brand, string number, string model, int price)
        {
            Brand = brand;
            Number = number;
            Model = model;
            Price = price;
            Console.WriteLine("Создан новый объект PC.");
        }
        public PC()
        {
            Console.WriteLine("Создан новый объект PC. Конструктор по умолчанию");
        }
    }
}
