using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDemos.Algorithms.Nodes
{
    /// <summary>
    /// Represents node with two subnodes
    /// </summary>
    class ExpressionNode:SyntaxTreeNode
    {
        /// <summary>
        /// Left subnode
        /// </summary>
        public SyntaxTreeNode Left { get; }

        /// <summary>
        /// Right subnode
        /// </summary>
        public SyntaxTreeNode Right { get; }

        /// <summary>
        /// Symbol of the operand the subtrees are operands of
        /// </summary>
        public string OpSymbol { get; }

        /// <summary>
        /// Creates a new node with two subnodes used by the operator 
        /// </summary>
        /// <param name="left">left subnode</param>
        /// <param name="right">right subnode</param>
        /// /// <param name="opSymbol">Symbol of the operand the subtrees are operands of</param>
        public ExpressionNode(string opSymbol,SyntaxTreeNode left, SyntaxTreeNode right)
        {
            Left = left;
            Right = right;
            OpSymbol = opSymbol;
        }
    }
}
