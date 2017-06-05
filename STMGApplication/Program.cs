using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace STMG {
    class Program {
        static void Main(string[] args) {
            GameController gc = new GameController();
            gc.createNewGame(4);
        }
    }
}
