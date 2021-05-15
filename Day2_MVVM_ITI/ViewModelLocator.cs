using Day2_MVVM_ITI.Services;
using Day2_MVVM_ITI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_MVVM_ITI
{
    public class ViewModelLocator
    {
        PlayersViewModel playersViewModel;
        CrudViewModel crudViewModel;
        public PlayersViewModel PlayersVM { get => playersViewModel ?? (playersViewModel = (new PlayersViewModel(new PlayersService()))); }
        public CrudViewModel CrudVM { get => crudViewModel ?? (crudViewModel = (new CrudViewModel(new PlayersService()))); }

    }
}
