using SentePiramidaFinansowa.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SentePiramidaFinansowa
{
    public class LoadListTransfers
    {
        readonly LoadXElement load;

        public LoadListTransfers(LoadXElement load)
        {
            this.load = load;
        }

        public List<Transfer> GetTransfers()
        {
            return load.GetElements().Select(x =>
                new Transfer
                {
                    NodeId = Int32.Parse(x.Attribute("od").Value),
                    AmountOfMoney = Decimal.Parse(x.Attribute("kwota").Value)
                }).ToList();
        }
    }
}
