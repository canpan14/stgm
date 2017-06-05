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
        private List<Player> players = new List<Player>();

        // Temporary
        const int HAZARD_DECK_SIZE = 60;
        const int PLAYER_DECK_SIZE = 60;

        public void createNewGame(int numPlayers) {
            gameBoard = new Board(5, 5);
            createHazardDeck();
            createPlayerDeck();
            for(int i = 0; i < numPlayers; i++) {
                players.Add(new STMG.Player("Test Name", i.ToString()));
            }

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
                HazardCard cardToAdd = new HazardCard();
                cardToAdd.name = rnd.Next().ToString();
                hazardDeck.addCard(cardToAdd);
            }
        }

        private void createPlayerDeck() {
            playerDeck = new CardDeck();
            // Will eventually read in deck from somewhere else
            for (int i = 0; i < PLAYER_DECK_SIZE; i++) {
                Random rnd = new Random();
                PlayerCard cardToAdd = new PlayerCard();
                cardToAdd.name = rnd.Next().ToString();
                playerDeck.addCard(cardToAdd);
            }
        }
    }
}
