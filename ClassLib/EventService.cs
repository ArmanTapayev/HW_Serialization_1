using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ClassLib
{
    public class EventService
    {
        public static void DoEventOn(EventPC eventPC, PC pc)
        {
            Console.WriteLine("Событие: On");
            LogEventPC log = new LogEventPC();
            log.EventPC = eventPC;
            log.pc = pc;
            log.EventDate = DateTime.Now;
            XmlSerializer formatter = new XmlSerializer(log.GetType());
            using (FileStream fs = new FileStream("file.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, log);
                Console.WriteLine("Объект сериализован");
            }
        }
        public static void DoEventOff()
        {
            Console.WriteLine("Событие: Off");
            LogEventPC log = new LogEventPC();
            //LogEventPC log = new LogEventPC();
            //log.EventPC = log.EventPC;
            //log.pc = pc;
            //log.EventDate = DateTime.Now;
            XmlSerializer formatter = new XmlSerializer(typeof(LogEventPC));
            using (FileStream fs = new FileStream("file.xml", FileMode.Open))
            {
                log = (LogEventPC)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine("Марка: {0}\nМодель: {1}\nЦена: {2}", log.pc.Brand, log.pc.Model, log.pc.Price);
                Console.WriteLine("Объект десериализован");
            }
        }
    }
}
