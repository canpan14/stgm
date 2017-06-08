using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace STMG {
    public enum Direction { NORTH, EAST, SOUTH, WEST };
    public class GameController {

        private Board gameBoard;
        private CardDeck hazardDeck;
        private CardDeck playerDeck;
        private List<Player> players = new List<Player>();
        private TheSubject theSubject = new TheSubject();

        // Used to decide which cards go into the deck. Card info/amount of each is controlled in the card xmls
        private String[] HAZARD_DECK_LIST = { "Banana", "SpringBoard" };
        private String[] PLAYER_DECK_LIST = { "" };

        private const int STARTING_HAZARD_HAND_SIZE = 5;

        public void createNewGame(int numPlayers) {
            gameBoard = new Board(5, 5);
            createHazardDeck();
            createPlayerDeck();
            createPlayers(numPlayers);
            randomTurnOrder();
            fillPlayerHands();

            int roundCounter = 1;
            // Begin Game Loop
            while (true) {
                Console.Write("Start of Round " + roundCounter + "\n");
                foreach (Player p in players) {
                    p.hazardHand.Add(hazardDeck.drawCard());
                    Console.Write("Choose card for " + p.playerName + ":" + "\n");
                    p.displayHazardHand();
                    String cardOption = Console.ReadLine();
                    HazardCard chosenCard = p.hazardHand[Int32.Parse(cardOption) - 1];
                    p.hazardHand.RemoveAt(Int32.Parse(cardOption) - 1);
                    Console.Write(p.playerName + " played " + chosenCard.name + "\n");
                    Console.Write("-------------------" + "\n");

                    //var key = Console.ReadKey(true).Key;
                    //if (key == ConsoleKey.Escape) {
                    //    break;
                    //}
                }
                roundCounter++;
            }
            // End Game
        }

        private void createHazardDeck() {
            hazardDeck = new CardDeck();
            foreach (String hazardCardName in HAZARD_DECK_LIST) {
                HazardCard card = new HazardCard(hazardCardName);
                for (int i = 0; i < card.numberInDeck; i++) {
                    hazardDeck.addCard(card);
                }
            }
            hazardDeck.shuffle();
        }

        private void createPlayerDeck() {
            playerDeck = new CardDeck();
            // TODO
        }

        private void createPlayers(int numPlayers) {
            for (int i = 0; i < numPlayers; i++) {
                players.Add(new STMG.Player("Player " + i, i.ToString()));
            }
        }

        private void randomTurnOrder() {
            var tempPlayers = players.ToArray();
            players.Clear();
            Random rnd = new Random();
            foreach (var p in tempPlayers.OrderBy(x => rnd.Next())) {
                players.Add(p);
            }
        }

        private void fillPlayerHands() {
            for (int i = 0; i < STARTING_HAZARD_HAND_SIZE; i++) {
                foreach (Player p in players) {
                    p.hazardHand.Add(hazardDeck.drawCard());
                }
            }
        }
    }
}
