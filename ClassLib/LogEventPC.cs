using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public enum EventPC { On, Off, Reset }
    public class LogEventPC
    {
        public DateTime EventDate { get; set; }
        public EventPC EventPC { get; set; }

        public PC pc = new PC();
    }
}
