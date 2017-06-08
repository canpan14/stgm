using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMG {

    public class BoardTile {
        public List<object> objectsOnTile = new List<object>();

        public void addPlayerHere() {

        }

        public void addCardHere(HazardCard card, Direction directionFacing) {
            card.direction = directionFacing;
            objectsOnTile.Add(card);
        }

        public void removeCardHere(HazardCard card)
        {
            objectsOnTile.Remove(card);
        }
    }
}
