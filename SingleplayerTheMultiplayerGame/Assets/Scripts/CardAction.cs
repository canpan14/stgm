using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace STMG {
    public class CardAction : MonoBehaviour {
        public List<Action> primaryActions = new List<Action>();
        public List<Action> alternativeActions = new List<Action>();

        public CardAction(XmlNode actions) {
            foreach (XmlNode action in actions) {
                if (action.SelectSingleNode("//Type").InnerText.Equals("Primary")) {
                    Action pAction = new Action(action);
                } else if (action.SelectSingleNode("//Type").InnerText.Equals("Alternative")) {

                }

            }
        }
        private void flatDamageToPlayer(int damage) {

        }
    }
}
