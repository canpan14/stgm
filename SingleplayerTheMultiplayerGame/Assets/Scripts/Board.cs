using System;
using UnityEngine;

namespace STMG {
    public class Board : MonoBehaviour {
        public GameObject boardTile;
        public int width;
        public int height;

        private GameObject[,] gameBoard;

        private void Awake() {
            initializeGameBoard(5, 5);
            RectTransform boardRect = (RectTransform)this.transform;
            float xSpacing = boardRect.rect.width / width;
            float ySpacing = boardRect.rect.height / height;
            float startingXLocation = -2*xSpacing;
            float startingYLocation = 2*ySpacing;
            for(int i = 0; i < 5; i++) {
                float newYLocation = startingYLocation - ySpacing * i;
                for (int j = 0; j < 5; j++) {
                    float newXLocation = startingXLocation + xSpacing * j;
                    GameObject tile = (GameObject)Instantiate(boardTile);
                    tile.transform.parent = this.gameObject.transform;
                    tile.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    tile.GetComponent<RectTransform>().localPosition = new Vector3(newXLocation, newYLocation, 0);
                    gameBoard[j, i] = tile;
                }
            }
        }

        public void initializeGameBoard(int boardWidth, int boardHeight) {
            width = boardWidth;
            height = boardHeight;
            gameBoard = new GameObject[width, height];
            for (int i = 0; i < gameBoard.GetLength(0); i++) {
                for (int j = 0; j < gameBoard.GetLength(1); j++) {
                    gameBoard[j, i] = new GameObject();
                }
            }
        }

        public BoardTile getTile(int x, int y) {
            return gameBoard[x, y].GetComponent<BoardTile>();
        }

        public void addCardToTile(int x, int y, HazardCard cardToAdd, Direction directionFacing) {
            BoardTile tileToAddTo = gameBoard[x, y].GetComponent<BoardTile>();
            tileToAddTo.addCardHere(cardToAdd, directionFacing);
        }

        public void moveTheSubjectToTile(int x, int y, GameObject subject) {
            BoardTile tileToAddTo = gameBoard[x, y].GetComponent<BoardTile>();
            tileToAddTo.addPlayerHere();
            subject.transform.SetParent(tileToAddTo.transform);
        }
    }
}
