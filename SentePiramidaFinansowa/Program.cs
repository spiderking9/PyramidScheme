using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SentePiramidaFinansowa
{
    class Program
    {
        public static void Main()
        {
            string folderBase = "C:\\Users\\Luk\\source\\repos\\PyramidSheme\\SentePiramidaFinansowa\\";

            //Load Xml files
            LoadXElement loadXmlUsers = new LoadXElement(folderBase + "piramida.xml", "uczestnik");
            LoadXElement loadXmlTransfers = new LoadXElement(folderBase+ "przelewy.xml", "przelew");

            //Loading lists
            LoadListUsers loadUsers = new LoadListUsers(loadXmlUsers);
            LoadListTransfers listTransfers = new LoadListTransfers(loadXmlTransfers);

            //Load amount to list users
            SendMoneyToUsers sendMoneyTo = new SendMoneyToUsers();
            sendMoneyTo.GetListWithTransferedMoney(listTransfers.GetTransfers(), loadUsers.ShowList());

            //Load childrens to list users
            HowManyChildren howManyChildren = new HowManyChildren();
            howManyChildren.CalculateChildren(loadUsers.ShowList());


            foreach (var item in loadUsers.ShowList())
            {
                Console.WriteLine($"id:{item.NodeId}  parent:{item.NodeParent}  money:{item.AmountOfMoney}    howManyChild:{item.HowManyChildren}  level:{item.Level}");
            }
            //Console.WriteLine("Wyjscie");
            //foreach (var item in loadUsers.ShowList())
            //{
            //    Console.WriteLine($"{item.NodeId} {item.Level} {item.HowManyChildren} {item.AmountOfMoney}");
            //}
            Console.ReadKey();
        }
    }


    //    public void Podmetoda()
    //    {
    //        Stopwatch stopWatch = new Stopwatch();
    //        stopWatch.Start();


    //        string folderBase = "C:\\Users\\Luk\\source\\repos\\SentePiramidaFinansowa\\";
    //        XElement piramidElements = XElement.Load(folderBase + @"piramida.xml");
    //        XElement transferElements = XElement.Load(folderBase + @"przelewy.xml");
            
            
    //        Program program = new Program();
    //        program.InputElementsToListsOff(0, piramidElements.Element("uczestnik"),0);

    //        List<Transfer> przelew = new List<Transfer>();

    //        var listsMoneyTransfer = transferElements.Elements("przelew").ToList().Select(x =>
    //        new Transfer
    //        {
    //            NodeId = Int32.Parse(x.Attribute("od").Value),
    //            AmountOfMoney = Decimal.Parse(x.Attribute("kwota").Value)
    //        });




    //        foreach (var item in listsMoneyTransfer)
    //        {
    //            var nodeParent=program.nodeList.Where(w => w.NodeId == item.NodeId).FirstOrDefault().NodeParent;
    //            var lastPartMoneyFromTransfer_ForFatherPerson = program.AddMoney(nodeParent, item.AmountOfMoney);
    //            program.nodeList.Where(x => x.NodeId == nodeParent).FirstOrDefault().AmountOfMoney += lastPartMoneyFromTransfer_ForFatherPerson; 
    //            Console.WriteLine($"kasa od {item.NodeId}, a ilosc taka:{item.AmountOfMoney}");
    //        }

    //        //-----------------------------------------


    //        foreach (var item in program.nodeList.OrderBy(x=>x.NodeId))
    //        {
    //            item.HowManyChildren = program.HowManyKids(item.NodeId);
    //            Console.WriteLine($"id:{item.NodeId}  parent:{item.NodeParent}  money:{item.AmountOfMoney} howManyChild:{item.HowManyChildren}  level:{item.Level}");
    //        }

    //        Console.WriteLine( program.nodeList.Sum(x => x.AmountOfMoney));

    //        Console.WriteLine(listsMoneyTransfer.Sum(w=>w.AmountOfMoney));
    //        Console.WriteLine();
            
            
    //        stopWatch.Stop();
    //        TimeSpan ts = stopWatch.Elapsed;
    //        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
    //        ts.Hours, ts.Minutes, ts.Seconds,
    //        ts.Milliseconds );
    //        Console.WriteLine();
    //        Console.WriteLine("RunTime " + elapsedTime);
    //    }




    //    List<Node> nodeList = new List<Node>();

    //    public List<Node> InputElementsToListsOff(int indentLevel, XElement element, int level)
    //    {


    //        if (element.Attribute("id") != null)
    //        {
    //            nodeList.Add(new Node
    //            {
    //                NodeId = Int32.Parse(element.Attribute("id").Value),
    //                NodeParent = indentLevel,
    //                Level=level
    //            });
    //        }
    //            foreach (XElement childElement in element.Elements())
    //            {
    //                InputElementsToListsOff(Int32.Parse(element.Attribute("id").Value), childElement,level+1);
    //            }

    //        return nodeList;
    //    }

    //    public int HowManyKids(int id)
    //    {
    //        return nodeList.Where(x => x.NodeParent == id).Count();
    //    }

    //    public decimal AddMoney(int id,decimal kwota)
    //    {
    //        decimal kwotaDlaMnie = 0;
    //        if (id == 1)
    //        {
    //            kwotaDlaMnie = kwota / 2;
    //        }
    //        else
    //        {
    //            kwotaDlaMnie = AddMoney(GetNodesById(id).FirstOrDefault().NodeParent, kwota) / 2;
    //        }
    //        GetNodesById(id).FirstOrDefault().AmountOfMoney += Math.Floor(kwotaDlaMnie);

    //        return Math.Ceiling(kwotaDlaMnie);

    //    }

    //    private IEnumerable<Node> GetNodesById(int id)
    //    {
    //        return nodeList.Where(x => x.NodeId == id);
    //    }
    //}

}
