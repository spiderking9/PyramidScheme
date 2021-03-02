using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SentePiramidaFinansowa
{
    public class LoadXElement
    {
        readonly XElement transferElements;
        readonly string elementName;

        public LoadXElement(string pathName, string elementName)
        {
            transferElements = XElement.Load(pathName);
            this.elementName = elementName;
        }

        public XElement GetElement()
        {
            return transferElements.Element(elementName);
        }

        public IEnumerable<XElement> GetElements()
        {
            return transferElements.Elements(elementName);
        }
    }
}
