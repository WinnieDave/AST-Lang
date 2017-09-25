using MyDemos.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDemos.Algorithms
{
    enum AssociationType
    {
        Left,
        Right
    }
    /// <summary>
    /// Represents an binary/unary operator
    /// </summary>
    abstract class Operator
    {
        /// <summary>
        /// Association of the operator
        /// </summary>
        public AssociationType AssociationType { get; }
        /// <summary>
        /// Precedence of the operator
        /// </summary>
        public int Precedence { get; }
    }
}

