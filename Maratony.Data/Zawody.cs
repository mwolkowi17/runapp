using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maratony.Data
{
    public class Zawody
    {
        public string Miejsce { get; set; }

        public DateTime Data { get; set; }

        public double Dystans { get; set; }

        public long ID { get; set; }

        public List<Biegacz> Biegacze { get; set; }

    }
}