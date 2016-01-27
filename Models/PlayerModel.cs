using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApplyingTask.Models
{

    public class PlayerModel
    {
        List<Player> players;
        List<Player> playersCLE;
        List<Player> playessLAL;

        public List<Player> getPlayers()
        {
            using(WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("http://api.lod-misis.ru/testassignment");
                players = JsonConvert.DeserializeObject<List<Player>>(json);
            }
            return players;
        }
        public void sortPlayers(List<Player> playersOT)
        {
            for (int i = 0; i < playersOT.Count-1; i++)
            {
                for (int j = 0; j < playersOT.Count-1-i; j++)
                {
                    if (playersOT[j].Score < playersOT[j+1].Score)
                    {
                        Player temp = playersOT[j];
                        playersOT[j] = playersOT[j + 1];
                        playersOT[j + 1] = temp;
                    }
                }
            }
        }

    }

    public class Player
    {
        public string PlayerName { get; set; }
        public string Team { get; set; }
        public int Score { get; set; }
    }

}
