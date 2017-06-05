using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMG {
    public class Player {
        public String uniquePlayerID = "";
        public String playerName = "";
        public int health = 20;
        public int money = 0;
        public List<ICard> hazardHand = new List<ICard>();
        public List<ICard> playerHand = new List<ICard>();

        public Player(String name, String uniqueID) {
            playerName = name;
            uniquePlayerID = uniqueID;
        }
    }
}
