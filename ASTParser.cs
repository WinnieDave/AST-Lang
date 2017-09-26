using System;
using System.Collections.Generic;
using System.Linq;
using MyDemos.Misc.StringExtensions;

namespace MyDemos.Algorithms
{
    class ASTParser
    {
        public static double Evaluate(SyntaxTreeNode root)
        {
            if (root is ValueNode)
                return double.Parse(((ValueNode)root).Value);
            else if (root is ExpressionNode)
            {
                ExpressionNode exprNode = (ExpressionNode)root;
                double o1 = Evaluate(exprNode.Left);
                double o2 = Evaluate(exprNode.Right);
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
            string[] splited = input.Split(' ');//basic parsing
            Dictionary<string, Operator> operators = new Dictionary<string, Operator>()
            {
                {"+",new Operator("+",AssociationType.Left,1)},
                {"-",new Operator("-",AssociationType.Left,1)},
                {"*",new Operator("*",AssociationType.Left,2)},
                {"/",new Operator("/",AssociationType.Left,2)},
                { "(",new Operator("(",AssociationType.Left,0)}
            };
            Stack<Operator> opStack = new Stack<Operator>();
            Stack<SyntaxTreeNode> exprStack = new Stack<SyntaxTreeNode>();
            foreach (var token in splited)
            {
                if (token.IsNumber())
                {
                    exprStack.Push(new ValueNode(token));
                    continue;
                }
                if (token == "(")
                {
                    opStack.Push(operators[token]);
                    continue;
                }
                if (token == ")")
                {
                    while (opStack.Count > 0 && (opStack.Peek().Symbol != "("))
                    {
                        var op = opStack.Pop();
                        var rightExpr = exprStack.Pop();
                        var leftExpr = exprStack.Pop();
                        exprStack.Push(new ExpressionNode(op.Symbol, leftExpr, rightExpr));
                    }
                    opStack.Pop();//popping "("
                    continue;
                }
                if (operators.ContainsKey(token))
                {
                    while (opStack.Count > 0 &&
                        operators[token].AssociationType == AssociationType.Left &&
                        operators[token].Precedence <= operators[opStack.Peek().Symbol].Precedence)
                    {
                        var op = opStack.Pop();
                        var rightExpr = exprStack.Pop();
                        var leftExpr = exprStack.Pop();
                        exprStack.Push(new ExpressionNode(op.Symbol, leftExpr, rightExpr));
                    }
                    opStack.Push(operators[token]);
                    continue;
                }

            }
                while (opStack.Count > 0)
                {
                    var op = opStack.Pop();
                    var rightExpr = exprStack.Pop();
                    var leftExpr = exprStack.Pop();
                    exprStack.Push(new ExpressionNode(op.Symbol, leftExpr, rightExpr));
                }
                return exprStack.Pop();
            }
        }
    }
