﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMG {
    public class CardDeck {
        private Stack<HazardCard> deckList = new Stack<HazardCard>();

        public HazardCard drawCard() {
            HazardCard drawnCard = deckList.Pop();
            return drawnCard;
        }

        public void addCard(HazardCard card) {
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
            foreach(HazardCard card in deckList) {
                Console.Write("Card " + cardCounter + ": " + card.name + "\n");
                cardCounter++;
            }
        }
    }
}
