using System;

namespace BitPatch.DialogLang
{
    /// <summary>
    /// Main entry point for the Game Dialog Script language
    /// </summary>
    public class Dialog
    {
        private readonly Interpreter _interpreter;

        public Dialog()
        {
            _interpreter = new Interpreter();
        }

        /// <summary>
        /// Executes a Game Dialog Script source code (streaming mode - does not load entire code into memory)
        /// </summary>
        /// <param name="source">The source code to execute</param>
        public void Execute(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException(nameof(source));
            }

            // Tokenize (streaming)
            var lexer = new Lexer(source);
            var tokens = lexer.Tokenize();

            // Parse (streaming)
            var parser = new Parser(tokens);
            var statements = parser.Parse();

            // Execute (streaming) - statements are executed one by one as they are parsed
            _interpreter.Execute(statements);
        }

        /// <summary>
        /// Gets the value of a variable
        /// </summary>
        public object? GetVariable(string name)
        {
            return _interpreter.GetVariable(name);
        }

        /// <summary>
        /// Gets all variables
        /// </summary>
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Variables => _interpreter.Variables;

        /// <summary>
        /// Clears all variables
        /// </summary>
        public void Clear()
        {
            _interpreter.Clear();
        }
    }
}
