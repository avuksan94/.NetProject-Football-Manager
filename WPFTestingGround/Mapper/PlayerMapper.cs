using DL.Model;
using FootballManagerWPFApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTestingGround.Model;

namespace FootballManagerWPFApp.Mapper
{
    public class PlayerMapper
    {
        public PlayerBL MapToViewModel(Player player)
        {
            return new PlayerBL
            {
                Name = player.Name,
                Captain = player.Captain,
                ShirtNumber = player.ShirtNumber,
                Position = player.Position,
                YellowCards = player.YellowCards,
                Goals = player.Goals,
                Appearances = player.Appereances
            };
        }
    }
}
