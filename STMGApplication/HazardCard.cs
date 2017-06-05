using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMG {
    public class HazardCard : ICard {
        public String name = "";
        public String type = "";
        public String description = "";
        public String flavor = "";
        public int cost = 0;
        public bool instant = false;
        public bool endOfTurn = false;
        public bool persistant = false;
    }
}
