using Day2_MVVM_ITI.Model;
using Day2_MVVM_ITI.Services;
using Day2_MVVM_ITI.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
            //initialize both commands 
            UpdateCmd = new EditCommand(onUpdate, canUpdate);
            DeleteCmd = new EditCommand(onDelete, canDelete);


        }

        public Player SelectedPlayer
        {
            get
            { return selectedPlayer; }

            set
            {
                selectedPlayer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedPlayer"));
                //playersService.Edit(selectedPlayer);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        ICommand updateCmd;
        public ICommand UpdateCmd
        {
            get => updateCmd;
            set
            {
                updateCmd = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UpdateCmd"));
            }
        }

        ICommand deleteCmd;
        public ICommand DeleteCmd
        {
            get => deleteCmd;
            set
            {
                deleteCmd = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeleteCmd"));
            }
        }

        private void onUpdate(object obj)
        {
            playersService.Edit(selectedPlayer);
        }
        private bool canUpdate(object obj)
        {
            return true;
        }

        private void onDelete(object obj)
        {
            var Result = MessageBox.Show("Are you sure you want to delete this player?", "Delete Player", MessageBoxButton.YesNo);
            if (Result == MessageBoxResult.Yes)
            {
                playersService.Delete(selectedPlayer.Id);
                Messenger.Default.Send<int>(selectedPlayer.Id); //send a message to subsrcibers, to delete this player
                selectedPlayer = null;

                DialogService.Close();
            }

            //selectedPlayer = null;
        }
        private bool canDelete(object obj)
        {
            return true;
        }



    }
}
