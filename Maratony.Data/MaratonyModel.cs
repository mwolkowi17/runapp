using System;
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




    }
}
