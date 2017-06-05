using Microsoft.VisualStudio.TestTools.UnitTesting;
using STMG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMG.Tests {
    [TestClass()]
    public class BoardTests {
        [TestMethod()]
        public void BoardTest() {
            Board testGameBoard = new Board(5, 5);
            Assert.IsTrue(testGameBoard.Width == 5);
        }
    }
}