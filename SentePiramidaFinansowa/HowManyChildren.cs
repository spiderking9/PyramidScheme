using SentePiramidaFinansowa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SentePiramidaFinansowa
{
    public class HowManyChildren
    {
        public void CalculateChildren(IEnumerable<Node> list)
        {
            if (list.Count() == 1) return;
            foreach (var item in list.OrderByDescending(w=>w.Level))
            {
                //if List of childs empty, add to my parents.HowManyChildren one 
                if (!list.Where(x => x.NodeParent == item.NodeId).Any())
                    list.Where(w => w.NodeId == item.NodeParent).FirstOrDefault().HowManyChildren++;
                //if level= 0 break
                else if (item.NodeParent == 0) break;
                //add sum descendant from my child
                else list.Where(w => w.NodeId == item.NodeParent).FirstOrDefault().HowManyChildren += item.HowManyChildren;
            }
        }
    }
}
