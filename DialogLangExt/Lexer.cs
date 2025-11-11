using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BitPatch.DialogLang
{
    /// <summary>
    /// Lexical analyzer that converts source code into tokens
    /// </summary>
    internal class Lexer
    {
        private readonly TextReader _reader;
        private int _currentChar;
        private int _position;

        public Lexer(TextReader reader)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
            _position = 0;
            _currentChar = _reader.Read();
        }

        /// <summary>
        /// Tokenizes the source code one token at a time (streaming)
        /// </summary>
        public IEnumerable<Token> Tokenize()
        {
            while (_currentChar != -1)
            {
                var token = GetNextToken();
                if (token.Type != TokenType.Unknown)
                {
                    yield return token;
                }
            }

            yield return new Token(TokenType.EndOfFile, string.Empty, _position);
        }

        /// <summary>
        /// Gets the next token from the source code
        /// </summary>
        private Token GetNextToken()
        {
            // Skip whitespace
            while (_currentChar != -1 && char.IsWhiteSpace((char)_currentChar))
            {
                Advance();
            }

            if (_currentChar == -1)
            {
                return new Token(TokenType.EndOfFile, string.Empty, _position);
            }

            var currentChar = (char)_currentChar;
            var startPosition = _position;

            // Integer number
            if (char.IsDigit(currentChar))
            {
                return ReadNumber(startPosition);
            }

            // Identifier (variable name)
            if (char.IsLetter(currentChar) || currentChar == '_')
            {
                return ReadIdentifier(startPosition);
            }

            // Assignment operator
            if (currentChar == '=')
            {
                Advance();
                return new Token(TokenType.Assign, "=", startPosition);
            }

            // Unknown character - skip it
            Advance();
            return new Token(TokenType.Unknown, currentChar.ToString(), startPosition);
        }

        /// <summary>
        /// Reads an integer number from the source
        /// </summary>
        private Token ReadNumber(int startPosition)
        {
            var sb = new StringBuilder();

            while (_currentChar != -1 && char.IsDigit((char)_currentChar))
            {
                sb.Append((char)_currentChar);
                Advance();
            }

            return new Token(TokenType.Integer, sb.ToString(), startPosition);
        }

        /// <summary>
        /// Reads an identifier (variable name) from the source
        /// </summary>
        private Token ReadIdentifier(int startPosition)
        {
            var sb = new StringBuilder();

            while (_currentChar != -1 && 
                   (char.IsLetterOrDigit((char)_currentChar) || (char)_currentChar == '_'))
            {
                sb.Append((char)_currentChar);
                Advance();
            }

            return new Token(TokenType.Identifier, sb.ToString(), startPosition);
        }

        /// <summary>
        /// Advances to the next character
        /// </summary>
        private void Advance()
        {
            _currentChar = _reader.Read();
            _position++;
        }
    }
}
