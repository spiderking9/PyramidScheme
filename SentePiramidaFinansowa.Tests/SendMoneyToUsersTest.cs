using System;
using System.Collections.Generic;
using SentePiramidaFinansowa.Models;
using System.Linq;
using Xunit;
using Moq;

namespace SentePiramidaFinansowa.Tests
{
    public class SendMoneyToUsersTest
    {
        [Fact]
        public void OneNodeOneTransfer()
        {
            List<Transfer> transferList = new List<Transfer>
            {
                new Transfer
                {
                    NodeId = 1,
                    AmountOfMoney = 22
                }
            };
            List<Node> userList = new List<Node>
            {
                new Node
                {
                    NodeId = 1,
                    AmountOfMoney = 22
                }
            };
            SendMoneyToUsers sendMoney = new SendMoneyToUsers();

            sendMoney.GetListWithTransferedMoney(transferList, userList);

            Assert.Equal(44, userList.Where(u => u.NodeId == 1).FirstOrDefault().AmountOfMoney);
        }

        [Fact]
        public void TwoNodeOneTransfer()
        {
            List<Transfer> transferList = new List<Transfer>
            {
                new Transfer
                {
                    NodeId = 1,
                    AmountOfMoney = 111
                }
            };
            List<Node> userList = new List<Node>
            {
                new Node
                {
                    NodeId = 1,
                    NodeParent = 0,
                    AmountOfMoney = 0
                },
                new Node
                {
                    NodeId = 2,
                    NodeParent = 1,
                    AmountOfMoney = 0
                }
            };
            SendMoneyToUsers sendMoney = new SendMoneyToUsers();

            sendMoney.GetListWithTransferedMoney(transferList, userList);

            Assert.Equal(111, userList.Where(u => u.NodeId == 1).FirstOrDefault().AmountOfMoney);
            Assert.Equal(0, userList.Where(u => u.NodeId == 2).FirstOrDefault().AmountOfMoney);

        }
        [Fact]
        public void ManyNodeManyTransfer()
        {
            List<Transfer> transferList = new List<Transfer>
            {
                new Transfer
                {
                    NodeId = 1,
                    AmountOfMoney = 22
                },
                new Transfer
                {
                    NodeId = 1,
                    AmountOfMoney = 100
                },
                new Transfer
                {
                    NodeId = 3,
                    AmountOfMoney = 220
                },
                new Transfer
                {
                    NodeId = 4,
                    AmountOfMoney = 30
                }
            };
            List<Node> userList = new List<Node>
            {
                new Node
                {
                    NodeId = 1,
                    AmountOfMoney = 0,
                    NodeParent = 0,
                },
                new Node
                {
                    NodeId = 2,
                    AmountOfMoney = 0,
                    NodeParent = 1,
                },
                new Node
                {
                    NodeId = 3,
                    AmountOfMoney = 0,
                    NodeParent = 1,
                },
                new Node
                {
                    NodeId = 4,
                    AmountOfMoney = 0,
                    NodeParent = 3,
                }
            };
            SendMoneyToUsers sendMoney = new SendMoneyToUsers();

            sendMoney.GetListWithTransferedMoney(transferList, userList);

            Assert.Equal(357, userList.Where(u => u.NodeId == 1).FirstOrDefault().AmountOfMoney);
            Assert.Equal(15, userList.Where(u => u.NodeId == 3).FirstOrDefault().AmountOfMoney);
            Assert.Equal(0, userList.Where(u => u.NodeId == 4).FirstOrDefault().AmountOfMoney);
            Assert.Equal(0, userList.Where(u => u.NodeId == 2).FirstOrDefault().AmountOfMoney);
        }
        [Fact]
        public void SumOfManyFromTransfersTheSameInNodes()
        {
            List<Transfer> transferList = new List<Transfer>
            {
                new Transfer
                {
                    NodeId = 6,
                    AmountOfMoney = 122
                },
                new Transfer
                {
                    NodeId = 4,
                    AmountOfMoney = 100
                },
                new Transfer
                {
                    NodeId = 2,
                    AmountOfMoney = 220
                },
                new Transfer
                {
                    NodeId = 3,
                    AmountOfMoney = 130
                },
                new Transfer
                {
                    NodeId = 3,
                    AmountOfMoney = 220
                },
                new Transfer
                {
                    NodeId = 5,
                    AmountOfMoney = 30
                }
            };
            List<Node> userList = new List<Node>
            {
                new Node
                {
                    NodeId = 1,
                    AmountOfMoney = 0,
                    NodeParent = 0,
                },
                new Node
                {
                    NodeId = 2,
                    AmountOfMoney = 0,
                    NodeParent = 1,
                },
                new Node
                {
                    NodeId = 3,
                    AmountOfMoney = 0,
                    NodeParent = 1,
                },
                new Node
                {
                    NodeId = 4,
                    AmountOfMoney = 0,
                    NodeParent = 3,
                },
                                new Node
                {
                    NodeId = 5,
                    AmountOfMoney = 0,
                    NodeParent = 4,
                },
                new Node
                {
                    NodeId = 6,
                    AmountOfMoney = 0,
                    NodeParent = 3,
                }
            };
            SendMoneyToUsers sendMoney = new SendMoneyToUsers();

            sendMoney.GetListWithTransferedMoney(transferList, userList);

            Assert.Equal(transferList.Sum(z=>z.AmountOfMoney), userList.Sum(w=>w.AmountOfMoney));

        }
    }
}
