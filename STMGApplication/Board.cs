using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMG {
    public class Board {
        public int width;
        public int height;

        private BoardTile[,] gameBoard;

        public Board(int boardWidth, int boardHeight) {
            width = boardWidth;
            height = boardHeight;
            gameBoard = new BoardTile[width, height];
        }

        public BoardTile getTile(int x, int y) {
            return gameBoard[x, y];
        }

        public void addCardToTile(int x, int y, HazardCard cardToAdd, Direction directionFacing) {
            // Impliment directionFacing later using enum or something better
            BoardTile tileToAddTo = gameBoard[x, y];
            tileToAddTo.addCardHere(cardToAdd, directionFacing);
            gameBoard[x, y] = tileToAddTo;
        }

        private void printBoard()
        {

            int rowLength = gameBoard.GetLength(0);
            int colLength = gameBoard.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if (gameBoard[i, j].objectsOnTile.Count > 0)
                    {
                        Console.Write(string.Format("{0} ", "1"));
                    } else
                    {
                        Console.Write(string.Format("{0} ", "0"));
                    }
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }
    }
}
