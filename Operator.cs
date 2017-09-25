using MyDemos.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Algorithms
{
    class Operator
    {
        public bool RightAssociative { get; }
        public int Precedence { get; }

        public string Symbol { get; }
        public Operator(bool assoc, int prec, string sym)
        {
            RightAssociative = assoc;
            Precedence = prec;
            Symbol = sym;
        }
    }
}
