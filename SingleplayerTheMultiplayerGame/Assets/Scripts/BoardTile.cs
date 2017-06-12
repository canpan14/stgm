using System.Collections.Generic;
using UnityEngine;

namespace STMG {

    public class BoardTile : MonoBehaviour {
        public List<HazardCard> objectsOnTile = new List<HazardCard>();

        public void addPlayerHere() {

        }

        public void addCardHere(HazardCard card, Direction directionFacing) {
            card.direction = directionFacing;
            objectsOnTile.Add(card);
        }

        public void removeCardHere(HazardCard card) {
            objectsOnTile.Remove(card);
        }
    }
}
