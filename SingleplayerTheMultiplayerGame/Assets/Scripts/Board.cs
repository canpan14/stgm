using System;
using UnityEngine;

namespace STMG {
    public class Board : MonoBehaviour {
        public GameObject tiles;
        public int width;
        public int height;

        private BoardTile[,] gameBoard;

        public Board(int boardWidth, int boardHeight) {
            width = boardWidth;
            height = boardHeight;
            gameBoard = new BoardTile[width, height];
            for (int i = 0; i < gameBoard.GetLength(0); i++) {
                for (int j = 0; j < gameBoard.GetLength(1); j++) {
                    gameBoard[j, i] = new BoardTile();
                }
            }
        }

        private void Start() {
            RectTransform boardRect = (RectTransform)this.transform;
            float xSpacing = boardRect.rect.width / width;
            float ySpacing = boardRect.rect.height / height;
            float startingXLocation = -2*xSpacing;
            float startingYLocation = 2*ySpacing;
            for(int i = 0; i < 5; i++) {
                float newYLocation = startingYLocation - ySpacing * i;
                for (int j = 0; j < 5; j++) {
                    float newXLocation = startingXLocation + xSpacing * j;
                    GameObject tile = (GameObject)Instantiate(tiles);
                    tile.transform.parent = this.gameObject.transform;
                    tile.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                    tile.GetComponent<RectTransform>().localPosition = new Vector3(newXLocation, newYLocation, 0);
                }
            }
        }

        public BoardTile getTile(int x, int y) {
            return gameBoard[x, y];
        }

        public void addCardToTile(int x, int y, HazardCard cardToAdd, Direction directionFacing) {
            BoardTile tileToAddTo = gameBoard[x, y];
            tileToAddTo.addCardHere(cardToAdd, directionFacing);
            gameBoard[x, y] = tileToAddTo;
        }
    }
}
