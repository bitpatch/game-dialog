using System;

namespace BitPatch.DialogLang
{
    /// <summary>
    /// Exception thrown when an error occurs during script execution.
    /// </summary>
    public class ScriptException : Exception
    {
        public int Line => Position.Line;
        public int Column => Position.Column;
        private TokenPosition Position { get; }

        internal ScriptException(string message, TokenPosition position) : base(message)
        {
            Position = position;
        }
    }

    public class InvalidSyntaxException : ScriptException
    {
        internal InvalidSyntaxException(TokenPosition position)
            : base("Invalid syntax", position)
        {
        }

        internal InvalidSyntaxException(int line, int column)
            : this(new TokenPosition(line, column))
        {
        }

        internal InvalidSyntaxException(string message, TokenPosition position)
            : base(message, position)
        {
        }

        internal InvalidSyntaxException(string message, int line, int column)
            : base(message, new TokenPosition(line, column))
        {
        }
    }

    public class TypeMismatchException : ScriptException
    {
        internal TypeMismatchException(string expected, string actual, TokenPosition position)
            : base($"Type mismatch: expected {expected}, got {actual}", position)
        {
        }

        internal TypeMismatchException(string message, TokenPosition position)
            : base(message, position)
        {
        }

        internal TypeMismatchException(string message, int line, int column)
            : base(message, new TokenPosition(line, column))
        {
        }
    }
}
