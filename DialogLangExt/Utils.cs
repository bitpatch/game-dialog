using System.Collections.Generic;

namespace BitPatch.DialogLang
{
    /// <summary>
    /// Utility methods for the interpreter.
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// Pushes a list of statements onto the stack in reverse order.
        /// </summary>
        /// <param name="stack">The stack to push statements onto.</param>
        /// <param name="statements">The list of statements to push.</param>
        public static void PushStatements(this Stack<Ast.Statement> stack, IReadOnlyList<Ast.Statement> statements)
        {
            for (int i = statements.Count - 1; i >= 0; i--)
            {
                stack.Push(statements[i]);
            }
        }

        /// <summary>
        /// Returns a new Location that is immediately after the current one.
        /// </summary>
        public static Location After(this Location location)
        {
            return new Location(location.Line, location.Final, location.Final + 1);
        }

        /// <summary>
        /// Asserts that the expression is a boolean expression.
        /// </summary>
        public static Ast.Expression AssertBoolean(this Ast.Expression expression)
        {
            if (expression is not Ast.IBoolean)
            {
                throw new InvalidSyntaxException("Expression cannot be boolean", expression.Location);
            }

            return expression;
        }

        /// <summary>
        /// Gets the Loop instance for the given location, creating a new one if necessary.
        /// </summary>
        /// <param name="loops">The stack of Loop instances.</param>
        /// <param name="location">The location of the loop in the source code.</param>
        /// <returns>The Loop instance for the given location.</returns>
        public static Loop Get(this Stack<Loop> loops, Location location)
        {
            if (loops.Count is 0 || loops.Peek().Line != location.Line)
            {
                var loop = new Loop(location);
                loops.Push(loop);
                return loop;
            }

            return loops.Peek();
        }

        /// <summary>
        /// Clears the Loop instance for the given location if it exists.
        /// </summary>
        /// <param name="loops">The stack of Loop instances.</param>
        /// <param name="location">The location of the loop in the source code.</param>
        public static void Clear(this Stack<Loop> loops, Location location)
        {
            if (loops.Count > 0 && loops.Peek().Line == location.Line)
            {
                loops.Pop();
            }
        }
    }
}