using System;
using System.Collections.Generic;
using UnityEngine;

namespace STMG {
    public class Player {
        public int uniquePlayerID;
        public String playerName = "";
        public int health = 20;
        public int money = 0;
        public List<HazardCard> hazardHand = new List<HazardCard>();
        public List<HazardCard> playerHand = new List<HazardCard>();

        public Player(String name, int uniqueID) {
            playerName = name;
            uniquePlayerID = uniqueID;
        }

        public void displayHazardHand() {
            for (int i = 0; i < hazardHand.Count; i++) {
                Console.Write((i + 1) + ") " + hazardHand[i].cardName + "\n");
            }
        }
    }
}
