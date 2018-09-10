using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ClassLib;

namespace HW_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            bool inProgress = true;
            while (inProgress)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("\t\tСериализация объектов");
                Console.WriteLine(new string('-', 50));
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("\t\tВыберите пункт меню:");
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("1. Задание 1. BinaryFormatter");
                Console.WriteLine("2. Задание 2. SoapFormatter");
                Console.WriteLine("3. Задание 3. Библиотека «ClassLib»");
                Console.WriteLine("4. Выход");
                Console.ForegroundColor = color;

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t1. Задание 1. BinaryFormatter");
                            Console.WriteLine(new string('-', 50));

                            Book[] books = new Book[]
                            {
                                new Book("Гоголь Н.В.","Ревизор",5000 ),
                                new Book("Толстой Л.Н.","Война и мир",7000),
                                new Book("Пушкин А.С.","Сказки",3000)
                            };

                            BinaryFormatter formatter = new BinaryFormatter();
                            using (FileStream fs = new FileStream("books.dat", FileMode.OpenOrCreate))
                            {
                                formatter.Serialize(fs, books);
                                Console.WriteLine("Объект сериализован");
                            }
                            Console.WriteLine(new string('-', 50));
                            using (FileStream fs = new FileStream("books.dat", FileMode.Open))
                            {

                                Book[] desBooks = (Book[])formatter.Deserialize(fs);
                                Console.WriteLine("Объект десериализован");
                                Console.WriteLine(new string('-', 50));
                                foreach (Book item in desBooks)
                                {
                                    Console.WriteLine("Автор: {0}\nНазвание: {1}\nЦена: {2}", item.Author, item.Author, item.Price);
                                }
                            }
                        }
                        break;

                    case 2:
                        {
                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t2. Задание 2. SoapFormatter");
                            Console.WriteLine(new string('-', 50));

                            ServicePerson servicePerson = new ServicePerson("practise.csv");
                            servicePerson.SerializationFile();
                            foreach (Person item in servicePerson.DeserializeFile())
                            {
                                Console.WriteLine("Фамилия: {1}\nИмя: {0}\nТелефон: {2}\nГод рождения: {3}",item.LastName, item.FirstName, item.Phone, item.DoB);
                            }
                        }
                        break;

                    case 3:
                        {

                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\tЗадание 3. Библиотека «ClassLib»");
                            Console.WriteLine(new string('-', 50));

                            EventService.DoEventOn(EventPC.On, new PC("asus", "12345", "asd345", 2000));
                            EventService.DoEventOff();

                        }
                        break;
                    case 4:
                        {

                            Console.WriteLine(new string('-', 50));
                            Console.WriteLine("\t\t6. Выход");
                            Console.WriteLine(new string('-', 50));
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Спасибо!");
                            Console.ForegroundColor = color;
                            inProgress = false;
                            Console.WriteLine(new string('-', 50));
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Выберите пункт меню");
                        }
                        break;
                }
            }
        }
    }
}
