using ClassLibrary1.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModels.Common;

namespace WpfApp1.ViewModels
{
    public class DetailEleveViewModel : BaseViewModel
    {
        private string _nom;
        private string _prenom;
        private double _moyenne;
        public DetailEleveViewModel(Eleve e)
        {
            _nom = e.Nom;
            _prenom = e.Prenom;
            int i = 0;
            float total = 0;
            foreach(Note n in e.notes.ToList()){
                total = total + n.Notation;
                i++;
            }
            _moyenne = (from n in e.notes select n.Notation).Average();
        }

        #region Data Bindings


        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public string Moyenne
        {
            get { return _moyenne.ToString(); }
        }

        #endregion
    }


}
