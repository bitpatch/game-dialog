namespace BitPatch.DialogLang
{
    /// <summary>
    /// Information about loop iterations for preventing infinite loops.
    /// </summary>
    internal class Loop
    {
        /// <summary>
        /// The line number where the loop is defined.
        /// </summary>
        public int Line => _location.Line;

        /// <summary>
        /// The number of iterations executed so far.
        /// </summary>
        public int IterationCount { get; private set; } = 0;

        private readonly Location _location;

        public Loop(Location location)
        {
            _location = location;
            IterationCount = 0;
        }

        public Loop IncrementIteration()
        {
            IterationCount++;

            return this;
        }

        public Loop Assert(int maxIterations)
        {
            if (IterationCount > maxIterations)
            {
                throw new ScriptException($"More than {maxIterations} iterations exceeded at line {Line}, possible infinite loop", _location);
            }

            return this;
        }
    }
}