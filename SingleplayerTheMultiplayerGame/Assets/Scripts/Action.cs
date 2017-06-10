using System.Xml;
using UnityEngine;

namespace STMG {
    public class Action : MonoBehaviour {
        XmlNode actionXml;
        public Action(XmlNode action) {
            actionXml = action;
        }

        public void performAction() {
            //Type thisType = this.GetType();
            //MethodInfo theMethod = thisType.GetMethod(actionToPerform);
            //theMethod.Invoke(this, null);
        }

        private void directDamage(Player p, int damage) {
            // Do stuff
        }

        private void moveTheSubject(TheSubject s, int xRelative, int yRelative) {
            // Do stuff
        }

        private void moveTheSubjectBasedOnCardDirection(TheSubject s, Direction d) {
            // Do stuff
        }
    }
}
