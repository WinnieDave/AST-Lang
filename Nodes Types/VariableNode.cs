using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDemos.Algorithms.Nodes
{

    /// <summary>
    /// Represents a variable 
    /// </summary>
    class VariableNode:SyntaxTreeNode
    {
        /// <summary>
        /// Name of the variable
        /// </summary>
        public string VariableName { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="varName">Name of the variable in the environment</param>
        public VariableNode(string varName)
        {
            VariableName = varName;
        }
    }
}
