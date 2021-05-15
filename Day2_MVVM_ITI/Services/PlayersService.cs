using Day2_MVVM_ITI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Day2_MVVM_ITI.Services
{
    public class PlayersService : IPlayersService
    {
        HttpClient client = new HttpClient();
        public List<Player> players;
        public Player player;

        public PlayersService()
        {
            GetAllData();
           // GetPlayerData(1);
        }
        const string baseAddress = "http://localhost:4321/api/Players/";


        private void GetAllData() 
        {
            string data = client.GetStringAsync(baseAddress).Result;
            var des = JsonConvert.DeserializeObject<List<Player>>(data);
            players = des;
        }

        private void GetPlayerData(int id) 
        {
            string data = client.GetStringAsync(baseAddress+id.ToString()).Result;
            var des = JsonConvert.DeserializeObject<Player>(data);
            player = des;
        }

        private void PostPlayerData(Player player)
        {
            var ser = JsonConvert.SerializeObject(player);
            var response = client.PostAsync(
                    baseAddress,new StringContent(ser, Encoding.Default, "application/json")).Result; //Default
                
        }

        private void DeletePlayerData(int id)
        {
            var response = client.DeleteAsync(baseAddress + id); 

        }

        private void PutPlayerData(Player player)
        {
            var ser = JsonConvert.SerializeObject(player);
            var response = client.PutAsync(
                    baseAddress+player.Id, new StringContent(ser, Encoding.Default, "application/json")).Result; //Default
        }

        public  List<Player> GetAll()
        {
            GetAllData();
            return players;
        }

        public Player GetPlayer(int id)
        {
            GetPlayerData(id);
            return player;
        }

        public void Create(Player player)
        {
            PostPlayerData(player);
        }

        public void Delete(int id)
        {
            DeletePlayerData(id);
        }

        public void Edit(Player player)
        {
            PutPlayerData(player);
        }

       
    }
}
