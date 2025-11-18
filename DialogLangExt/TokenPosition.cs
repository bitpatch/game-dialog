namespace BitPatch.DialogLang
{
    /// <summary>
    /// Represents a position range in the source code
    /// </summary>
    internal readonly struct TokenPosition
    {
        public int Line { get; }
        public int StartColumn { get; }
        public int EndColumn { get; }

        /// <summary>
        /// Backward compatibility property - returns start column
        /// </summary>
        public int Column => StartColumn;

        public TokenPosition(int line, int column) : this(line, column, column)
        {
        }

        public TokenPosition(int line, int startColumn, int endColumn)
        {
            Line = line;
            StartColumn = startColumn;
            EndColumn = endColumn;
        }

        /// <summary>
        /// Creates a position range that spans from the start of one position to the end of another
        /// </summary>
        public static TokenPosition Span(TokenPosition start, TokenPosition end)
        {
            return new TokenPosition(start.Line, start.StartColumn, end.EndColumn);
        }

        public override string ToString()
        {
            if (StartColumn == EndColumn)
            {
                return $"Line: {Line}, Col: {StartColumn}";
            }
            return $"Line: {Line}, Col: {StartColumn}-{EndColumn}";
        }
    }
}
