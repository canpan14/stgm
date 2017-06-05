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

        public void setTile(int x, int y, BoardTile tile, String directionFacing) {
            // Impliment directionFacing later using enum or something better
            gameBoard[x, y] = tile;
        }
    }
}
