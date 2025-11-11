using System;

namespace BitPatch.DialogLang
{
    /// <summary>
    /// Exception thrown when an error occurs during script execution.
    /// </summary>
    public class ScriptException : Exception
    {
        public int Line { get; }
        public int Column { get; }

        public ScriptException(string message, int line, int column) : base(message)
        {
            Line = line;
            Column = column;
        }
    }

    public class InvalidSyntaxException : ScriptException
    {
        public InvalidSyntaxException(int line, int column)
            : base("Invalid syntax", line, column)
        {
        }

        public InvalidSyntaxException(string message, int line, int column)
            : base(message, line, column)
        {
        }
    }
}
