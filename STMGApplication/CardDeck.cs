using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMG {
    public class CardDeck {
        private Stack<ICard> deckList = new Stack<ICard>();

        public ICard drawCard() {
            ICard drawnCard = deckList.Pop();
            return drawnCard;
        }

        public void addCard(ICard card) {
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

        public void printDeck() {
            int cardCounter = 1;
            Console.Write("Deck Size: " + deckList.Count + "\n");
            foreach(ICard card in deckList) {
                Console.Write("Card " + cardCounter + ": " + card.getName() + "\n");
                cardCounter++;
            }
        }
    }
}
