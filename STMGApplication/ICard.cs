using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace STMG {
    public interface ICard {
        int getNumberInDeck();
        String getName();
        String cardToString();
    }
}
