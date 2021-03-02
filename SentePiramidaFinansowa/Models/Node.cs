using System;
using System.Collections.Generic;
using System.Text;

namespace SentePiramidaFinansowa.Models
{
    public class Node
    {
        public int NodeId { get; set; }
        public int NodeParent { get; set; }
        public int Level { get; set; }
        public int HowManyChildren { get; set; }
        public decimal AmountOfMoney { get; set; }
    }
}
