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

        public void addCardHere(ICard card) {
            objectsOnTile.Add(card);
        }
    }
}
