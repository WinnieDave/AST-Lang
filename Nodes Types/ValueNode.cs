using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDemos.Algorithms
{
    /// <summary>
    /// Represents node with the concrete value
    /// </summary>
    class ValueNode:SyntaxTreeNode
    {
        /// <summary>
        /// Value of the node
        /// </summary>
        public dynamic Value { get;}

        /// <param name="value">Value of the node</param>
        public ValueNode(dynamic value)
        { Value = value; }
    }
}
