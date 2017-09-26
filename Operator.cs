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
     class Operator
    {
        /// <summary>
        /// Association of the operator
        /// </summary>
        public AssociationType AssociationType { get; }
        /// <summary>
        /// Precedence of the operator
        /// </summary>
        public int Precedence { get; }
        /// <summary>
        /// Symbol of the operator
        /// </summary>
        public string Symbol { get; }

        public Operator(string symbol,AssociationType assocType,int prec)
        {
            this.Symbol = symbol;
            this.AssociationType = assocType;
            this.Precedence = prec;
        }
    }
}

