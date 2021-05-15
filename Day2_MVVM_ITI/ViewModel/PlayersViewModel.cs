using Day2_MVVM_ITI.Model;
using Day2_MVVM_ITI.Services;
using Day2_MVVM_ITI.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Day2_MVVM_ITI.ViewModel
{
    public class PlayersViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Player> players;
        Player player;

        IPlayersService playersService;

      

        public event PropertyChangedEventHandler PropertyChanged;

        ICommand editCmd;
        public ICommand EditCmd
        {
            get
            { return editCmd; }
            set
            {
                editCmd = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EditCmd"));
            }
        }
        public PlayersViewModel(PlayersService playersService)
        {
            this.playersService = playersService;
            editCmd= new EditCommand(OnEdit, CanEdit);
            ShDialog = new DialogService();
        }

        private bool CanEdit(object obj)
        {
            return true;
        }

        private void OnEdit(object obj)
        {
            // MessageBox.Show(obj.ToString());
            ShDialog.ShowDialog();
            Messenger.Default.Send<Player>(SelectedPlayer);
            


        }

        public DialogService ShDialog { get; set; }

        Player selectedPlayer;
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
        public ObservableCollection<Player> Players { get => players ?? (players = new ObservableCollection<Player>( playersService.GetAll())); } 

        public Player Player { get => player ?? (player = playersService.GetPlayer(1)); }

    }
}
