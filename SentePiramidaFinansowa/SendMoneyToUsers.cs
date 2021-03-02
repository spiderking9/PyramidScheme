using System;
using System.Collections.Generic;
using System.Diagnostics;
using SentePiramidaFinansowa.Models;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SentePiramidaFinansowa
{
    public class SendMoneyToUsers
    {
        public void GetListWithTransferedMoney(IEnumerable<Transfer> listTransfers, IEnumerable<Node> listUsers)
        {
            if (listUsers.Count() == 1) listUsers.FirstOrDefault().AmountOfMoney += listTransfers.Sum(x => x.AmountOfMoney);
            else
            {
                foreach (var item in listTransfers)
                {
                    if (item.NodeId == 1|| GetNodesById(item.NodeId, listUsers).FirstOrDefault().NodeParent==1) 
                    { 
                        listUsers.FirstOrDefault(w => w.NodeId == 1).AmountOfMoney += item.AmountOfMoney;
                        continue;
                    }
                    var nodeParent = listUsers.Where(w => w.NodeId == item.NodeId).FirstOrDefault().NodeParent;
                    decimal lastPartMany = AddMoney(nodeParent, item.AmountOfMoney, listUsers);
                    listUsers.Where(x => x.NodeId == nodeParent).FirstOrDefault().AmountOfMoney += lastPartMany;


                }
            }
        }
        decimal AddMoney(int id, decimal amountFromTransfer, IEnumerable<Node> usersList)
        {
            decimal calculatedMoney;

            if (id == 1) calculatedMoney = amountFromTransfer / 2;
            else  calculatedMoney = AddMoney(GetNodesById(id, usersList).FirstOrDefault().NodeParent, amountFromTransfer, usersList) / 2;

            GetNodesById(id, usersList).FirstOrDefault().AmountOfMoney += Math.Floor(calculatedMoney);

            return Math.Ceiling(calculatedMoney);

        }
        private IEnumerable<Node> GetNodesById(int id,IEnumerable<Node> nodeList)
        {
            return nodeList.Where(x => x.NodeId == id);
        }
    }
}
