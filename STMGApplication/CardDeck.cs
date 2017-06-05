using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMG {
    public class CardDeck {
        private Stack<Card> deckList = new Stack<Card>();

        public Card drawCard() {
            Card drawnCard = deckList.Pop();
            return drawnCard;
        }

        public void addCard(Card card) {
            deckList.Push(card);
        }

        // https://stackoverflow.com/questions/33643104/shuffling-a-stackt
        public void shuffle() {
            var cards = deckList.ToArray();
            deckList.Clear();
            Random rnd = new Random();
            foreach(var card in cards.OrderBy(x => rnd.Next())) {
                deckList.Push(card);
            }
        }
    }
}
