using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace STMG
{
    public class HazardCard
    {
        public int numberInDeck = 0;
        public String name = "";
        public String type = "";
        public String primaryEffect = "";
        public String alternativeEffect = "";
        public String flavor = "";
        public int cost = 0;
        public bool instantDamage = false;
        public bool endOfTurnDamage = false;
        public bool persistant = false;
        public bool endsMovement = false;
        public Action[] action;
        public Direction direction = Direction.NORTH;

        public HazardCard(String cardName)
        {
            XmlDocument cardInfo = new XmlDocument();
            cardInfo.Load("..//..//Cards/HazardCards/" + cardName + ".xml");
            XmlNode numberInDeckNode = cardInfo.DocumentElement.SelectSingleNode("//NumberInDeck");
            XmlNode nameNode = cardInfo.DocumentElement.SelectSingleNode("//Name");
            XmlNode typeNode = cardInfo.DocumentElement.SelectSingleNode("//Type");
            XmlNode primaryNode = cardInfo.DocumentElement.SelectSingleNode("//PrimaryEffect");
            XmlNode alternitiveNode = cardInfo.DocumentElement.SelectSingleNode("//AlternativeEffect");
            XmlNode flavorNode = cardInfo.DocumentElement.SelectSingleNode("//FlavorText");
            XmlNode costNode = cardInfo.DocumentElement.SelectSingleNode("//Cost");
            XmlNode instantNode = cardInfo.DocumentElement.SelectSingleNode("//isInstantDamage");
            XmlNode endOfTurnNode = cardInfo.DocumentElement.SelectSingleNode("//isEndOfTurnDamage");
            XmlNode persistantNode = cardInfo.DocumentElement.SelectSingleNode("//isPersistant");
            XmlNode endsMovementNode = cardInfo.DocumentElement.SelectSingleNode("//EndsMovement");
            XmlNode actions = cardInfo.DocumentElement.SelectSingleNode("//Actions");

            numberInDeck = Int32.Parse(numberInDeckNode.InnerText);
            name = nameNode.InnerText;
            type = typeNode.InnerText;
            primaryEffect = primaryNode.InnerText;
            alternativeEffect = alternitiveNode.InnerText;
            flavor = flavorNode.InnerText;
            cost = Int32.Parse(costNode.InnerText);
            instantDamage = Convert.ToBoolean(instantNode.InnerText);
            endOfTurnDamage = Convert.ToBoolean(endOfTurnNode.InnerText);
            persistant = Convert.ToBoolean(persistantNode.InnerText);
            endsMovement = Convert.ToBoolean(endsMovementNode.InnerText);
            action = xmlToArrayOfCardActions(actions);
        }

        public String cardToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: " + name + "\n");
            sb.Append("NumberInDeck: " + numberInDeck + "\n");
            sb.Append("Type: " + type + "\n");
            sb.Append("Primary: " + primaryEffect + "\n");
            sb.Append("Alt: " + alternativeEffect + "\n");
            sb.Append("Flavor: " + flavor + "\n");
            sb.Append("Cost: " + cost + "\n");
            sb.Append("IsInstant: " + instantDamage + "\n");
            sb.Append("IsEndOfTurn: " + endOfTurnDamage + "\n");
            sb.Append("IsPersistant: " + persistant + "\n");
            sb.Append("EndsMovement: " + endsMovement + "\n");
            return sb.ToString();
        }

        private Action[] xmlToArrayOfCardActions(XmlNode actions)
        {
            List<Action> actionList = new List<Action>();
            foreach (XmlNode action in actions)
            {
                actionList.Add(new Action(action));
            }

            return actionList.ToArray();
        }
    }
}
