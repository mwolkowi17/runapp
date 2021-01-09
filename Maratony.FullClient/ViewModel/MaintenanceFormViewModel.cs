using Maratony.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maratony.UI.ViewModel
{
   public  class MaintenanceFormViewModel: INotifyPropertyChanged
    {
        private MaratonyModel model = new MaratonyModel();

        private IEnumerable<Zawody> zawody;
        private Zawody wybraneZawody;
        public ICommand SaveCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }
        public Zawody WybraneZawody
        {
            get
            {
                return this.wybraneZawody;
            }
            set
            {
                this.wybraneZawody = value;
                this.OnPropertyChanged();
                this.OdswiezBiegaczy();  // dodane ponizej
            }
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
                this.OnPropertyChanged();
            }
        }

        private IEnumerable<Biegacz> biegacze;
        public IEnumerable<Biegacz> Biegacze
        {
            get
            {
                return this.biegacze;
            }
            set
            {
                this.biegacze = value;
                OnPropertyChanged();
            }
        }



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



        public event PropertyChangedEventHandler PropertyChanged;
        //private void OnPropertyChanged(string propertyName)
        private void OnPropertyChanged(
            [System.Runtime.CompilerServices.CallerMemberName]
            string propertyName = "")
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
            this.SaveCommand = new RelayCommand(
                 action => this.DodajBiegacza(),
                 enable => this.CzyMoznaDodacBiegacza());
            this.ClearCommand = new RelayCommand(
                 action => this.WyczyscWybraneZawody(),
                 enable => this.CzyMoznaDodacBiegacza());


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
            model.DodajBiegacza(model.ListaZawodow[0].ID, "Młody", "Bóg","Kraków");
            model.DodajBiegacza(model.ListaZawodow[1].ID, "Jan", "Kowalski", "Warszawa");
            model.DodajBiegacza(model.ListaZawodow[1].ID, "Adam", "Nowak", "Warsdzawa");
        }

        private void OdswiezBiegaczy()
        {
            this.Biegacze = null;
            this.Biegacze = this.WybraneZawody?.Biegacze;
        }

        public void DodajBiegacza()
        {
            if (WybraneZawody != null)
            {
                model.DodajBiegacza(this.WybraneZawody.ID, "Nowy", "Biegacz",this.WybraneZawody.Miejsce);
                this.OdswiezBiegaczy();
            }
        }

        public bool CzyMoznaDodacBiegacza()
        {
            return (this.WybraneZawody != null);
        }

        private void WyczyscWybraneZawody()
        {
            this.WybraneZawody = null;
        }



    }
}
