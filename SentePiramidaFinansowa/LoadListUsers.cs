using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SentePiramidaFinansowa.Models;
using System.Text;
using System.Xml.Linq;

namespace SentePiramidaFinansowa
{
    public class LoadListUsers
    {
        readonly List<Node> nodeList;

        public LoadListUsers(LoadXElement listXml)
        {
            nodeList = new List<Node>();
            InputElementsToList(0, listXml.GetElement(), 0);
        }

        public IEnumerable<Node> ShowList()
        {
            return nodeList.OrderBy(x=>x.NodeId);
        }

        public List<Node> InputElementsToList(int indentLevel, XElement element, int level)
        {

            if (element.Attribute("id") != null)
            {
                nodeList.Add(new Node
                {
                    NodeId = Int32.Parse(element.Attribute("id").Value),
                    NodeParent = indentLevel,
                    Level = level
                });
            }
            foreach (XElement childElement in element.Elements())
            {
                InputElementsToList(Int32.Parse(element.Attribute("id").Value), childElement, level + 1);
            }

            return nodeList;
        }

    }
}
