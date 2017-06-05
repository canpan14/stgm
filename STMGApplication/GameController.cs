using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMG {
    public class GameController {

        private Board gameBoard;
        private CardDeck hazardDeck;
        private CardDeck playerDeck;

        // Temporary
        const int HAZARD_DECK_SIZE = 5;
        const int PLAYER_DECK_SIZE = 5;

        public void createNewGame() {
            gameBoard = new Board(5, 5);
            createHazardDeck();
            createPlayerDeck();
            // Set up players
            // Pre game setup
            // Roll for turn order

            // Begin Game Loop

            // End Game
        }

        private void createHazardDeck() {
            hazardDeck = new CardDeck();
            // Will eventually read in deck from somewhere else
            for(int i = 0; i < HAZARD_DECK_SIZE; i++) {
                Random rnd = new Random();
                Card cardToAdd = new Card();
                cardToAdd.cost = rnd.Next();
                hazardDeck.addCard(cardToAdd);
            }
        }

        private void createPlayerDeck() {
            playerDeck = new CardDeck();
            // Will eventually read in deck from somewhere else
            for (int i = 0; i < PLAYER_DECK_SIZE; i++) {
                Random rnd = new Random();
                Card cardToAdd = new Card();
                cardToAdd.cost = rnd.Next();
                playerDeck.addCard(cardToAdd);
            }
        }
    }
}
