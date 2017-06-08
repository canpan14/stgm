using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace STMG
{
    public class CardAction
    {
        public List<Action> primaryActions = new List<Action>();
        public List<Action> alternativeActions = new List<Action>();

        public CardAction(XmlNode actions)
        {
            foreach (XmlNode action in actions)
            {
                if (action.SelectSingleNode("//Type").InnerText.Equals("Primary"))
                {
                    Action pAction = new Action();
                }
                else if (action.SelectSingleNode("//Type").InnerText.Equals("Alternative"))
                {

                }

            }
        }
        private void flatDamageToPlayer(int damage)
        {

        }
    }
}
