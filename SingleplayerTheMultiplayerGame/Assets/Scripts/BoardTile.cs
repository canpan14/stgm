using System.Collections.Generic;
using UnityEngine;

namespace STMG {

    public class BoardTile : MonoBehaviour {
        public HazardCard nonNaturalDisasterHere = null;
        public HazardCard naturalDisasterHere = null;
        public List<HazardCard> subHazardCardsHere = new List<HazardCard>();
        public bool isPlayerHere = false;

        public void addPlayerHere() {
            isPlayerHere = true;
        }

        public void removePlayerHere() {
            isPlayerHere = false;
        }

        public void addCardHere(HazardCard card, Direction directionFacing) {
            card.direction = directionFacing;
            if(card.type == HazardType.NATURALDISASTER) {
                naturalDisasterHere = card;
            } else {
                nonNaturalDisasterHere = card;
            }
        }

        public void addSubCardHere(HazardCard card, Direction directionFacing) {
            card.direction = directionFacing;
            subHazardCardsHere.Add(card);
        }

        public void removeNaturalDisaster(HazardCard card) {
            naturalDisasterHere = null;
        }

        public void removeNonNaturalDisaster(HazardCard card) {
            nonNaturalDisasterHere = null;
        }

        public void removeSubHazardCard(HazardCard card) {
            // Will need to be reworked so that the associated sub is removed in the case of duplicates
            // This may as well be a stub
            foreach(HazardCard c in subHazardCardsHere) {
                if(c == card) {
                    subHazardCardsHere.Remove(c);
                }
            }
        }
    }
}
