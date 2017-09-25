using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDemos.Algorithms
{
    class SyntaxTreeNode
    {
        public SyntaxTreeNode LeftNode { get; }
        public SyntaxTreeNode RightNode { get; }

        public string Value { get; }
        public SyntaxTreeNode(string value, SyntaxTreeNode left = null, SyntaxTreeNode right = null)
        {
            Value = value;
            LeftNode = left;
            RightNode = right;
        }
    }
}
