using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace SentePiramidaFinansowa
{
    class Program
    {
        public static void Main()
        {
            string folderBase = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

            //Load Xml files
            LoadXElement loadXmlUsers = new LoadXElement(folderBase + "\\piramida.xml", "uczestnik");
            LoadXElement loadXmlTransfers = new LoadXElement(folderBase+ "\\przelewy.xml", "przelew");

            //Loading lists
            LoadListUsers loadUsers = new LoadListUsers(loadXmlUsers);
            LoadListTransfers listTransfers = new LoadListTransfers(loadXmlTransfers);

            //Load amount to list users
            SendMoneyToUsers sendMoneyTo = new SendMoneyToUsers();
            sendMoneyTo.GetListWithTransferedMoney(listTransfers.GetTransfers(), loadUsers.ShowList());

            //Load childrens to list users
            HowManyChildren howManyChildren = new HowManyChildren();
            howManyChildren.CalculateChildren(loadUsers.ShowList());
            Console.WriteLine();

            //foreach (var item in loadUsers.ShowList())
            //{
            //    Console.WriteLine($"id:{item.NodeId}  parent:{item.NodeParent}  money:{item.AmountOfMoney}    howManyChild:{item.HowManyChildren}  level:{item.Level}");
            //}
            Console.WriteLine("Wyjscie");
            foreach (var item in loadUsers.ShowList())
            {
                Console.WriteLine($"{item.NodeId} {item.Level} {item.HowManyChildren} {item.AmountOfMoney}");
            }
            Console.ReadKey();
        }
    }

}
