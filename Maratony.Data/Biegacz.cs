﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maratony.Data
{
    public class Biegacz
    {
        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public System.TimeSpan Wynik { get; set; }

        public long ID { get; set; }

        public Zawody Bieg { get; set; }

    }
}