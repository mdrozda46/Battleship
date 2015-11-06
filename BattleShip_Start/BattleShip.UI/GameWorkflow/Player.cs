using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI.GameWorkflow
{
    public class Player
    {
        //getPlayerName and Player Board
        public string Name { get; set;}
        public Board PlayerBoard { get; }

        public Player()
        {
            Name = "New Player";
            PlayerBoard = new Board();
           
        }
    }
        
}
