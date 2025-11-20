using System.Collections.Generic;

namespace BitPatch.DialogLang
{
    static class Utils
    {
        public static void PushStatements(this Stack<Ast.Statement> stack, IReadOnlyList<Ast.Statement> statements)
        {
            for (int i = statements.Count - 1; i >= 0; i--)
            {
                stack.Push(statements[i]);
            }
        }

        public static Location After(this Location location)
        {
            return new Location(location.Line, location.Final, location.Final + 1);
        }

        public static Ast.Expression AssertBoolean(this Ast.Expression expression)
        {
            if (expression is not Ast.IBoolean)
            {
                throw new InvalidSyntaxException("Expression cannot be boolean", expression.Location);
            }

            return expression;
        }

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

        public static void Clear(this Stack<Loop> loops, Location location)
        {
            if (loops.Count > 0 && loops.Peek().Line == location.Line)
            {
                loops.Pop();
            }
        }
    }
}