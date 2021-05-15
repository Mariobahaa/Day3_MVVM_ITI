using Day2_MVVM_ITI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_MVVM_ITI.Services
{
    public interface IPlayersService
    {
        public List<Player> GetAll();
        public Player GetPlayer(int id);

        public void Create(Player player);

        public void Delete(int id);

        public void Edit(Player player);
        //public List<Player> GetAll();
    }
}
