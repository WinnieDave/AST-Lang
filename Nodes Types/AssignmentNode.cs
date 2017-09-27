using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDemos.Algorithms.Nodes
{
    /// <summary>
    /// Represent a node that represents an assignment to a certain variable in the environment
    /// </summary>
    class AssignmentNode:SyntaxTreeNode
    {
        /// <summary>
        /// Name of the variable
        /// </summary>
        public string VariableName { get; }

        /// <summary>
        /// Value to be assigned to that variable
        /// </summary>
        public SyntaxTreeNode ValueExpression { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="varName">name of the variable in the environment</param>
        /// <param name="value">value to be assigned</param>
        public AssignmentNode(string varName,SyntaxTreeNode  value)
        {
            VariableName = varName;
            ValueExpression = value;
        }
    }
}
