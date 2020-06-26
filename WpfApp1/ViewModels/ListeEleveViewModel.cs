using ClassLibrary1;
using ClassLibrary1.Entites;
using ClassLibrary2.Queries;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModels.Common;

namespace WpfApp1.ViewModels
{
    public class ListeEleveViewModel : BaseViewModel
    {

        private ObservableCollection<DetailEleveViewModel> _eleves = null;
        private DetailEleveViewModel _selectedEleve;
        public ListeEleveViewModel()
        {
            MonProjetDbContext context = new MonProjetDbContext();
            EleveQuery query = new EleveQuery(context);

            _eleves = new ObservableCollection<DetailEleveViewModel>();
            
            foreach (Eleve e in query.GetAll().ToList())
            {
                _eleves.Add(new DetailEleveViewModel(e));
            }
            if (_eleves != null && _eleves.Count > 0)
            {
                _selectedEleve = _eleves.ElementAt(0);
            }
        }

        #region Data Bindings


        public ObservableCollection<DetailEleveViewModel> Eleves
        {
            get { return _eleves; }
            set
            {
                _eleves = value;
                OnPropertyChanged("Eleves");
            }
        }


        public DetailEleveViewModel SelectedEleve
        {
            get { return _selectedEleve; }
            set
            {
                _selectedEleve = value;
                OnPropertyChanged("SelectedEleve");
            }
        }


        #endregion
    }
}
