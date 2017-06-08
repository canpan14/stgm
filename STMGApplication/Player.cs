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
        public List<HazardCard> hazardHand = new List<HazardCard>();
        public List<HazardCard> playerHand = new List<HazardCard>();

        public Player(String name, String uniqueID) {
            playerName = name;
            uniquePlayerID = uniqueID;
        }

        public void displayHazardHand() {
            for(int i = 0; i < hazardHand.Count; i++) {
                Console.Write((i+1) + ") " + hazardHand[i].name + "\n");
            }
        }
    }
}
