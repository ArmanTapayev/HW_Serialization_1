using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace HW_Serialization
{
    public class ServicePerson
    {
        private string Path { get; set; }
        public ServicePerson(string path)
        {
            Path = path;
        }
        public List<Person> ReadFile()
        {
            List<Person> persons = new List<Person>();
            using (StreamReader sr = new StreamReader(Path, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Person person = new Person();
                    string[] sline = line.Split(';');
                    person.LastName = sline[0];
                    person.FirstName = sline[1];
                    person.Phone = sline[2];
                    person.DoB = int.Parse(sline[3]);
                    persons.Add(person);
                }
            }
            return persons;
        }
        public void SerializationFile()
        {
            List<Person> read = ReadFile();
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fs = new FileStream("soapCSV.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fs, read.ToArray());
            }

        }
        public List<Person> DeserializeFile()
        {
            List<Person> read = null;
            SoapFormatter sf = new SoapFormatter();
            using (FileStream fs = new FileStream("soapCSV.soap", FileMode.Open))
            {
                read = (sf.Deserialize(fs) as Person[]).ToList();
            }
            return read;
        }

    }
}
