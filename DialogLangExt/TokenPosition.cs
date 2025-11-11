namespace BitPatch.DialogLang
{
    /// <summary>
    /// Represents a position in the source code
    /// </summary>
    internal readonly struct TokenPosition
    {
        public int Line { get; }
        public int Column { get; }

        public TokenPosition(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return $"Line: {Line}, Col: {Column}";
        }
    }
}
