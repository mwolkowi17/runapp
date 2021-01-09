using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maratony.Data
{
    public class Biegacz
    {
        private static long nextId = 0;
        public Biegacz()
        {
            this.ID = System.Threading.Interlocked.Increment(ref nextId);
        }


        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public System.TimeSpan Wynik { get; set; }

        public long ID { get; set; }

        //public Zawody Bieg { get; set; }
        public string miejsce { get; set; }



    }
}