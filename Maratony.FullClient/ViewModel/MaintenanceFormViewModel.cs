﻿using Maratony.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maratony.UI.ViewModel
{
   public  class MaintenanceFormViewModel: INotifyPropertyChanged
    {
        private MaratonyModel model = new MaratonyModel();

        private IEnumerable<Zawody> zawody;

        public MaintenanceFormViewModel()
        {
            Task.Run(() => Init());

        }

        public MaintenanceFormViewModel(bool init)
        {
            // Konstruktor uzywany w testach jednostkowych
            if (init)
                Init();
        }


        public IEnumerable<Zawody> Zawody
        {
            get
            {
                return this.zawody;
            }
            set
            {
                this.zawody = value;
                this.OnPropertyChanged(nameof(Zawody));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            /*
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            */
            // C# 6.0:
            this.PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(propertyName));
        }

       

        internal void Init()
        {
            this.PrzykladoweDane();
            this.OdswiezZawody();
        }

        private void OdswiezZawody()
        {
            // this.Zawody -> wywoluje Zawody.set{...} oraz OnPropertyChanged
            this.Zawody = model.ListaZawodow;
        }

        internal void PrzykladoweDane()
        {
            model.DodajZawody("Kraków", new DateTime(2016, 1, 10), 11.6);
            model.DodajZawody("Warszawa", new DateTime(2016, 1, 23), 6);
            model.DodajBiegacza(model.ListaZawodow[0].ID, "Młody", "Bóg");
            model.DodajBiegacza(model.ListaZawodow[1].ID, "Jan", "Kowalski");
            model.DodajBiegacza(model.ListaZawodow[1].ID, "Adam", "Nowak");
        }

    }
}