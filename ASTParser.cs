using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDemos.Algorithms;
using MyDemos.Misc.StringExtensions;
using ConsoleApplication1.Algorithms;

namespace MyDemos.Algorithms
{
    class ASTParser
    {
        private static int GetHeight(SyntaxTreeNode root)
        {
            if (root == null)
                return 0;
            else
            {
                int left = GetHeight(root.LeftNode);
                int right = GetHeight(root.RightNode);
                return (left > right ? left + 1 : right + 1);
            }
        }
        private static void PrintLevel(SyntaxTreeNode root, int level,int indentLevel)
        {
            if (root == null)
                return;
            if (level == 1)
                Console.WriteLine(new string(' ',indentLevel)+root.Value);
            else if (level > 1)
            {
                PrintLevel(root.LeftNode, level - 1,indentLevel+2);
                PrintLevel(root.RightNode, level - 1,indentLevel+2);
            }
        }

        public static void ReverseOrderTraversal(SyntaxTreeNode root)
        {
            int height = GetHeight(root);
            for (int i = height ; i >= 1; i--)
            //for(int i=0;i<=height; i++)
            {
                PrintLevel(root, i,0);
            }
        }

        public static SyntaxTreeNode InfixToAST(string input)
        {
            string[] splited = input.Split(' ');
            Dictionary<string,Operator> operators = new Dictionary<string, Operator>()
            {
                {"*" , new Operator(false,2,"*") },
                {"/", new Operator(false,2,"/") },
                {"+", new Operator(false,1,"+") },
                {"-", new Operator(false,1,"-") },
                { "(",new Operator(false,0,"(") }
                
            };
            Stack<SyntaxTreeNode> expressionStack = new Stack<SyntaxTreeNode>();
            Stack<Operator> operatorStack = new Stack<Operator>();
            foreach (var token in splited)
            {
                if (token.IsNumber())
                {
                    expressionStack.Push(new SyntaxTreeNode(token));
                    continue;
                }
                if (token == "(")
                {
                    operatorStack.Push(operators[token]);
                    continue;
                }
                if (token == ")")
                {
                    while (operatorStack.Count > 0 && (operatorStack.Peek().Symbol != "("))
                    {
                        var op = operatorStack.Pop();
                        var right = expressionStack.Pop();
                        var left = expressionStack.Pop();
                        expressionStack.Push(new SyntaxTreeNode(op.Symbol, left, right));
                    }
                    operatorStack.Pop();
                }
                if (operators.Keys.Contains(token))
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek().Precedence >= operators[token].Precedence)
                    {
                        var op = operatorStack.Pop();
                        var right = expressionStack.Pop();
                        var left = expressionStack.Pop();
                        expressionStack.Push(new SyntaxTreeNode(op.Symbol, left, right));
                    }
                    operatorStack.Push(operators[token]);
                }
            }
            while (operatorStack.Count > 0)
            {
                Operator op = operatorStack.Pop();
                SyntaxTreeNode right = expressionStack.Pop();
                SyntaxTreeNode left = expressionStack.Pop();
                expressionStack.Push(new SyntaxTreeNode(op.Symbol, left, right));
            }
            return expressionStack.Pop();
        }
    }
}
