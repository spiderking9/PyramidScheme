using System;
using System.Collections.Generic;
using SentePiramidaFinansowa.Models;
using System.Linq;
using Xunit;
using Moq;

namespace SentePiramidaFinansowa.Tests
{
    public class HowManyChildrenTest
    {
        [Fact]
        public void NoChildrenWhenIsOneNode()
        {
            List<Node> userList = new List<Node>
            {
                new Node { NodeId = 1, NodeParent=0 }
            };
            HowManyChildren howMany = new HowManyChildren();
            howMany.CalculateChildren(userList);

            Assert.Equal(0, userList.Where(u => u.NodeId == 1).FirstOrDefault().HowManyChildren);
        }

        [Fact]
        public void OnlyOneChildFromFourDescendant()
        {
            List<Node> userList = new List<Node>
            {
                new Node { NodeId = 1, NodeParent=0, Level=0 },
                new Node { NodeId = 2, NodeParent=1, Level=1 },                
                new Node { NodeId = 3, NodeParent=2, Level=2 },
                new Node { NodeId = 4, NodeParent=3, Level=3 },
                new Node { NodeId = 5, NodeParent=4, Level=4 }
            };
            HowManyChildren howMany = new HowManyChildren();
            howMany.CalculateChildren(userList);

            Assert.Equal(1, userList.Where(u => u.NodeId == 1).FirstOrDefault().HowManyChildren);
            Assert.Equal(1, userList.Where(u => u.NodeId == 2).FirstOrDefault().HowManyChildren); 
            Assert.Equal(1, userList.Where(u => u.NodeId == 3).FirstOrDefault().HowManyChildren);
            Assert.Equal(1, userList.Where(u => u.NodeId == 4).FirstOrDefault().HowManyChildren);
            Assert.Equal(0, userList.Where(u => u.NodeId == 5).FirstOrDefault().HowManyChildren);
        }
        [Fact]
        public void ManyNodesCheck()
        {
            List<Node> userList = new List<Node>
            {
                new Node { NodeId = 1, NodeParent=0, Level=0  },
                new Node { NodeId = 2, NodeParent=1, Level=1  },
                new Node { NodeId = 3, NodeParent=1, Level=1  },
                new Node { NodeId = 4, NodeParent=2, Level=2  },
                new Node { NodeId = 5, NodeParent=2, Level=2  },
                new Node { NodeId = 6, NodeParent=2, Level=2  },
                new Node { NodeId = 7, NodeParent=4, Level=3  },
                new Node { NodeId = 8, NodeParent=4, Level=3  },
                new Node { NodeId = 9, NodeParent=4, Level=3  }
            };
            HowManyChildren howMany = new HowManyChildren();
            howMany.CalculateChildren(userList);

            Assert.Equal(6, userList.Where(u => u.NodeId == 1).FirstOrDefault().HowManyChildren);
            Assert.Equal(3, userList.Where(u => u.NodeId == 4).FirstOrDefault().HowManyChildren);
            Assert.Equal(0, userList.Where(u => u.NodeId == 8).FirstOrDefault().HowManyChildren);
        }
    }
}
