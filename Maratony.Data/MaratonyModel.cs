﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maratony.Data
{
    public class MaratonyModel
    {
        private ObservableCollection<Zawody> listaZawodow;
        private ObservableCollection<Biegacz> listaBiegaczy;

        public MaratonyModel()
        {
            this.listaZawodow = new ObservableCollection<Zawody>();
            this.listaBiegaczy = new ObservableCollection<Biegacz>();
        }

        public ObservableCollection<Zawody> ListaZawodow
        {
            get { return listaZawodow; }
        }

        public ObservableCollection<Biegacz> ListaBiegaczy
        {
            get { return listaBiegaczy; }
        }

        public Zawody DodajZawody(string miejsce, DateTime data, double dystans)
        {
            Zawody z = new Zawody() { Miejsce = miejsce, Data = data, Dystans = dystans };
            this.listaZawodow.Add(z);
            return z;
        }

        public Biegacz DodajBiegacza(long zawodyId, string imie, string nazwisko)
        {
            Zawody zawody = listaZawodow.Where(z => (z.ID == zawodyId)).FirstOrDefault();
            Biegacz b = new Biegacz() { Imie = imie, Nazwisko = nazwisko };
            this.listaBiegaczy.Add(b);
            b.Bieg = zawody;
            zawody.Biegacze.Add(b);
            return b;
        }



    }
}
