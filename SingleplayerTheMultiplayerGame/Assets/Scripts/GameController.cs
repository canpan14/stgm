using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace STMG {
    public enum Direction { NORTH, EAST, SOUTH, WEST };
    public enum HazardType { TRAP, OBSTRUCTION, NATURALDISASTER, SPELL }
    public class GameController : MonoBehaviour {

        private Board gameBoard;
        private CardDeck hazardDeck;
        private CardDeck playerDeck;
        private List<Player> players = new List<Player>();
        private List<Player> currentHazardPlayers = new List<Player>();
        private List<Player> currentPlayer = new List<Player>();
        private TheSubject theSubject = new TheSubject();
        private Player currentSubjectPlayer;
        private Player currentHazardPlayerPlaying;

        private int currentCycleInRound = 0;
        private int hazardTurnsPassedInCurrentCycle = 0;

        // Used to decide which cards go into the deck. Card info/amount of each is controlled in the card xmls
        private String[] HAZARD_DECK_LIST = { "Banana", "SpringBoard" };
        private String[] PLAYER_DECK_LIST = { "" };

        private const int STARTING_HAZARD_HAND_SIZE = 5;
        private const int ROUND_INCOME = 3;

        public Text columnText;
        public Text rowText;
        public Text directionFacingText;
        public Text theCurrentSubjectText;
        public Text theCurrentHazardText;

        private void Start() {
            createNewGame(4);
        }

        public void createNewGame(int numPlayers) {
            // Setup
            gameBoard = new Board(5, 5);
            createHazardDeck();
            createPlayerDeck();
            createPlayers(numPlayers);
            randomTurnOrder();
            fillPlayerHands();
            Debug.Log("Inital Turn Order: " + players[0].playerName + ", " + players[1].playerName + ", " + players[2].playerName + ", " + players[3].playerName);
            // Start things going
            roundStart();
            cycleStart();
            hazardTurnStart();
        }

        public void playCardClicked() {
            // Currently only playing first card in hand
            HazardCard cardToPlay = currentHazardPlayerPlaying.hazardHand[0];
            playHazardCard(cardToPlay, Int32.Parse(columnText.text), Int32.Parse(rowText.text), (Direction)Enum.Parse(typeof(Direction), directionFacingText.text.ToUpper()));
            removeCardFromHand(cardToPlay);
            hazardTurnEnd();
        }

        private void hazardTurnEnd() {
            hazardTurnsPassedInCurrentCycle++;
            if(hazardTurnsPassedInCurrentCycle >= players.Count - 1) {
                cycleEnd();
            } else {
                hazardTurnStart();
            }
        }

        private void roundStart() {
            foreach (Player p in players) {
                p.money += ROUND_INCOME;
            }
        }

        private void cycleStart() {
            currentSubjectPlayer = players[currentCycleInRound];
            currentHazardPlayerPlaying = players[(currentCycleInRound + 1) % players.Count];
            theCurrentSubjectText.text = "Subject: " + currentSubjectPlayer.playerName;
        }

        private void hazardTurnStart() {            
            currentHazardPlayerPlaying = players[(currentCycleInRound + 1 + hazardTurnsPassedInCurrentCycle) % players.Count];
            currentHazardPlayerPlaying.hazardHand.Add(hazardDeck.drawCard());
            theCurrentHazardText.text = "Hazard Player: " + currentHazardPlayerPlaying.playerName;

            Debug.Log("CycleInRound: " + currentCycleInRound);
            Debug.Log("HazardTurnInCycle: " + hazardTurnsPassedInCurrentCycle);
        }

        private void cycleEnd() {
            hazardTurnsPassedInCurrentCycle = 0;
            currentCycleInRound++;
            if(currentCycleInRound >= players.Count) {
                roundEnd();
            } else {
                cycleStart();
                hazardTurnStart();
            }
        }

        private void roundEnd() {
            currentCycleInRound = 0;
            cycleStart();
            hazardTurnStart();
        }

        private void playHazardCard(HazardCard chosenCard, int columnToPlayIn, int rowToPlayIn, Direction chosenDirection) {
            gameBoard.addCardToTile(columnToPlayIn - 1, rowToPlayIn - 1, chosenCard, chosenDirection);
        }
        
        private void removeCardFromHand(HazardCard cardToRemove) {
            currentHazardPlayerPlaying.hazardHand.Remove(cardToRemove);
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
            System.Random rnd = new System.Random();
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
