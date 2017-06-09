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
        private List<Player> currentHazardPlayers = new List<Player>();
        private List<Player> currentPlayer = new List<Player>();
        private TheSubject theSubject = new TheSubject();

        // Used to decide which cards go into the deck. Card info/amount of each is controlled in the card xmls
        private String[] HAZARD_DECK_LIST = { "Banana", "SpringBoard" };
        private String[] PLAYER_DECK_LIST = { "" };

        private const int STARTING_HAZARD_HAND_SIZE = 5;
        private const int ROUND_INCOME = 3;

        public void createNewGame(int numPlayers) {
            gameBoard = new Board(5, 5);
            createHazardDeck();
            createPlayerDeck();
            createPlayers(numPlayers);
            randomTurnOrder();
            fillPlayerHands();

            int roundCounter = 1;
            int currentPlayerIndexTurnAsTheSubject = 0;
            bool roundCompleted = false;

            while (true) {
                Console.Write("Start of Round " + roundCounter + Environment.NewLine);
                roundStart();
                int numberOfCyclesCompleted = 0;
                while (!roundCompleted) {
                    Console.Write("Player " + players[currentPlayerIndexTurnAsTheSubject].uniquePlayerID + " is The Subject." + Environment.NewLine);                    
                    for(int i = 0; i < numPlayers; i++) {
                        int playerIndexToGrab = (i + numberOfCyclesCompleted)%(numPlayers);
                        Player p = players[playerIndexToGrab];
                        if (i != 0) {
                            // Hazard turns in here
                            turnStart(p);
                            hazardChoices(p);
                            //var key = Console.ReadKey(true).Key;
                            //if (key == ConsoleKey.Escape) {
                            //    break;
                            //}
                        } else {
                            // The Subject turn in here
                        }
                    }
                    currentPlayerIndexTurnAsTheSubject++;
                    if(currentPlayerIndexTurnAsTheSubject >= numPlayers) {
                        currentPlayerIndexTurnAsTheSubject = 0;
                        roundCompleted = true;
                    }
                    numberOfCyclesCompleted++;
                }
                // End round
                roundCounter++;
                roundCompleted = false;
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
                players.Add(new Player("Player " + i, i));
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

        private void roundStart() {
            foreach (Player p in players) {
                p.money = p.money + ROUND_INCOME;
            }
        }

        private void turnStart(Player p) {
            p.hazardHand.Add(hazardDeck.drawCard());
        }

        private void hazardChoices(Player p) {
            // Ask Player what card they want to play
            Console.Write("Choose card for " + p.playerName + ":" + Environment.NewLine);
            p.displayHazardHand();
            String cardOption = Console.ReadLine();
            // Ask Player where they want to play card (Which row, then which column)
            Console.Write("Choose column number to play in (1-5)" + Environment.NewLine);
            int columnToPlayIn = Int32.Parse(Console.ReadLine());
            Console.Write("Choose row number to play in (1-5)" + Environment.NewLine);
            int rowToPlayIn = Int32.Parse(Console.ReadLine());
            // Ask Player direction for card to face (North is normal play direction)
            Console.Write("Choose direction card faces (North, South, East, West)" + Environment.NewLine);
            Direction chosenDirection;
            Enum.TryParse(Console.ReadLine().ToUpper(), out chosenDirection);
            // Will eventually add logic to change mind about above
            // Remove card from hand
            HazardCard chosenCard = p.hazardHand[Int32.Parse(cardOption) - 1];
            p.hazardHand.RemoveAt(Int32.Parse(cardOption) - 1);
            // Play card on board
            gameBoard.addCardToTile(columnToPlayIn - 1, rowToPlayIn - 1, chosenCard, chosenDirection);
            // Print results
            gameBoard.printBoard();
            Console.Write(p.playerName + " played " + chosenCard.name + Environment.NewLine);
            Console.Write("-------------------" + Environment.NewLine);
        }
    }
}
