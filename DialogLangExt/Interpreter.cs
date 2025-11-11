using System;
using System.Collections.Generic;

namespace BitPatch.DialogLang
{
    /// <summary>
    /// Interpreter that executes the AST
    /// </summary>
    internal class Interpreter
    {
        private readonly Dictionary<string, object> _variables;

        public Interpreter()
        {
            _variables = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets all variables in the current scope
        /// </summary>
        public IReadOnlyDictionary<string, object> Variables => _variables;

        /// <summary>
        /// Executes statements one by one as they arrive (streaming)
        /// </summary>
        public void Execute(IEnumerable<Ast.Node> nodes)
        {
            foreach (var node in nodes)
            {
                switch (node)
                {
                    case Ast.Statement statement:
                        ExecuteStatement(statement);
                        break;
                    default:
                        throw new NotSupportedException($"Unsupported node type: {node.GetType().Name}");
                }
            }
        }

        /// <summary>
        /// Executes a program (legacy method for compatibility)
        /// </summary>
        public void Execute(Ast.Program program)
        {
            Execute(program.Statements);
        }

        /// <summary>
        /// Executes a single statement
        /// </summary>
        private void ExecuteStatement(Ast.Statement node)
        {
            switch (node)
            {
                case Ast.Assign assign:
                     ExecuteAssignment(assign);
                    break;
                default:
                    throw new NotSupportedException($"Unsupported statement type: {node.GetType().Name}");
            }
        }

        /// <summary>
        /// Executes an assignment statement
        /// </summary>
        private void ExecuteAssignment(Ast.Assign node)
        {
            _variables[node.Identifier.Name] = EvaluateExpression(node.Expression);
        }

        /// <summary>
        /// Evaluates an expression and returns its value
        /// </summary>
        private object EvaluateExpression(Ast.Expression expression)
        {
            return expression switch
            {
                Ast.Number number => number.Value,
                Ast.String str => str.Value,
                Ast.Variable variable => EvaluateVariable(variable),
                _ => throw new NotSupportedException($"Unsupported expression type: {expression.GetType().Name}")
            };
        }
        
        private object EvaluateVariable(Ast.Variable variable)
        {
            if (_variables.TryGetValue(variable.Name, out var value))
            {
                return value;
            }

            throw new ScriptException($"Variable '{variable.Name}' is not defined", variable.Position);
        }

        /// <summary>
        /// Gets the value of a variable
        /// </summary>
        public object? GetVariable(string name)
        {
            return _variables.TryGetValue(name, out var value) ? value : null;
        }

        /// <summary>
        /// Clears all variables
        /// </summary>
        public void Clear()
        {
            _variables.Clear();
        }
    }
}
