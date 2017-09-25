using System;
using System.Collections.Generic;
using System.Linq;
using MyDemos.Misc.StringExtensions;

namespace MyDemos.Algorithms
{
    class ASTParser
    {
        public static object Evaluate(SyntaxTreeNode root)
        {
            if (root is ValueNode)
                return ((ValueNode)root).Value;
            else if (root is ExpressionNode)
            {
                ExpressionNode exprNode = (ExpressionNode)root;
                dynamic o1 = Evaluate(exprNode.Left);
                dynamic o2 = Evaluate(exprNode.Right);
                switch (exprNode.OpSymbol)
                {
                    case "+":
                        return o1 + o2;
                    case "-":
                        return o1 - o2;
                    case "*":
                        return o1 * o2;
                    case "/":
                        return o1 / o2;
                    default:
                        throw new ArgumentException(nameof(root));
                }
            }
            else
                throw new ArgumentException(nameof(root));
        }
        //private static int GetHeight(SyntaxTreeNode root)
        //{
        //    if (root == null)
        //        return 0;
        //    else
        //    {
        //        int left = GetHeight(root.LeftNode);
        //        int right = GetHeight(root.RightNode);
        //        return (left > right ? left + 1 : right + 1);
        //    }
        //}
        //private static void PrintLevel(SyntaxTreeNode root, int level,int indentLevel)
        //{
        //    if (root == null)
        //        return;
        //    if (level == 1)
        //        Console.WriteLine(new string(' ',indentLevel)+root.Value);
        //    else if (level > 1)
        //    {
        //        PrintLevel(root.LeftNode, level - 1,indentLevel+2);
        //        PrintLevel(root.RightNode, level - 1,indentLevel+2);
        //    }
        //}

        //public static void ReverseOrderTraversal(SyntaxTreeNode root)
        //{
        //    int height = GetHeight(root);
        //    for (int i = height ; i >= 1; i--)
        //    //for(int i=0;i<=height; i++)
        //    {
        //        PrintLevel(root, i,0);
        //    }
        //}

        //TODO:Implement tomorrow
        public static SyntaxTreeNode InfixToAST(string input)
        {
           
        }
    }
}
