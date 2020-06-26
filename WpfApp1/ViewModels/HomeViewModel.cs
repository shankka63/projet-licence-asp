using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModels.Common;

namespace WpfApp1.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Variables

        private ListeEleveViewModel _listeEleveViewModel = null;

        #endregion

        #region Constructeurs

        public HomeViewModel()
        {
            _listeEleveViewModel = new ListeEleveViewModel();
        }

        #endregion

        #region Data Bindings

        public ListeEleveViewModel ListeEleveViewModel
        {
            get { return _listeEleveViewModel; }
            set { _listeEleveViewModel = value; }
        }

        #endregion
    }
}
