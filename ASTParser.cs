using System;
using System.Collections.Generic;
using System.Linq;
using MyDemos.Misc.StringExtensions;
using MyDemos.Algorithms.Nodes;

namespace MyDemos.Algorithms
{
    class ASTParser
    {
        public static double Evaluate(SyntaxTreeNode root,Dictionary<string,object> env)
        {
            if (root is ValueNode)
                return double.Parse(((ValueNode)root).Value);
            if (root is AssignmentNode)
            {
                AssignmentNode node = (AssignmentNode)root;
                env[node.VariableName] = Evaluate(node.ValueExpression, env);
                return double.NaN;
            }
            else if (root is ExpressionNode)
            {
                ExpressionNode exprNode = (ExpressionNode)root;
                double o1 = Evaluate(exprNode.Left, env);
                double o2 = Evaluate(exprNode.Right, env);
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
        public static SyntaxTreeNode InfixToAST(string input)
        {
            string[] splited = input.Split(' ');//basic parsing
            Dictionary<string, Operator> operators = new Dictionary<string, Operator>()
            {
                {"=",new Operator("=",AssociationType.Right,1)},
                {"+",new Operator("+",AssociationType.Left,2)},
                {"-",new Operator("-",AssociationType.Left,2)},
                {"*",new Operator("*",AssociationType.Left,4)},
                {"/",new Operator("/",AssociationType.Left,4)},
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

                if (token.IsAVariableName())
                {
                    exprStack.Push(new VariableNode(token));
                    continue;
                }

                if (operators.ContainsKey(token))
                {
                    while (opStack.Count > 0 &&
                        operators[token].AssociationType == AssociationType.Left &&
                        operators[token].Precedence <= operators[opStack.Peek().Symbol].Precedence)
                    {
                        if (token == "=")
                        {
                            var assignmentOp = opStack.Pop();
                            ExpressionNode value = ((ExpressionNode)exprStack.Pop());
                            string varName = ((VariableNode)exprStack.Pop()).VariableName;
                            exprStack.Push(new AssignmentNode(varName, value));

                        }
                        else
                        {
                            var op = opStack.Pop();
                            var rightExpr = exprStack.Pop();
                            var leftExpr = exprStack.Pop();
                            exprStack.Push(new ExpressionNode(op.Symbol, leftExpr, rightExpr));
                        }
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
                if (op.Symbol == "=")
                {
                    var valueNode = (ExpressionNode)rightExpr;
                    var variableNode = (VariableNode)leftExpr;
                    exprStack.Push(new AssignmentNode(variableNode.VariableName, valueNode));
                }
                else
                {
                    exprStack.Push(new ExpressionNode(op.Symbol, leftExpr, rightExpr));
                }
            }
            return exprStack.Pop();
            }
        }
    }
