using Day2_MVVM_ITI.Model;
using Day2_MVVM_ITI.Services;
using Day2_MVVM_ITI.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_MVVM_ITI.ViewModel
{
    public class CrudViewModel: INotifyPropertyChanged
    {
        Player selectedPlayer;
        
        private IPlayersService playersService;

        private void OnRecieved(Player obj)
        {
            SelectedPlayer = obj;
        }

        public CrudViewModel(IPlayersService _playersService)
        {
            playersService = _playersService;
            Messenger.Default.Register<Player>(this, OnRecieved);


        }

        public Player SelectedPlayer
        {
            get
            { return selectedPlayer; }

            set
            {
                selectedPlayer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedPlayer"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
