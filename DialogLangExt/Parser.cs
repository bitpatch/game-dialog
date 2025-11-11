using System;
using System.Collections.Generic;
using System.Linq;

namespace BitPatch.DialogLang
{
    /// <summary>
    /// Parser that builds an Abstract Syntax Tree from tokens
    /// </summary>
    internal class Parser
    {
        private readonly IEnumerator<Token> _tokenEnumerator;
        private Token _currentToken;
        private Token? _nextToken;

        public Parser(IEnumerable<Token> tokens)
        {
            _tokenEnumerator = tokens.GetEnumerator();
            
            // Load first token
            if (!_tokenEnumerator.MoveNext())
            {
                _currentToken = new Token(TokenType.EndOfFile, string.Empty, 0);
            }
            else
            {
                _currentToken = _tokenEnumerator.Current;
            }

            // Peek next token
            if (_tokenEnumerator.MoveNext())
            {
                _nextToken = _tokenEnumerator.Current;
            }
        }

        /// <summary>
        /// Parses tokens and yields statements one by one (streaming)
        /// </summary>
        public IEnumerable<AstNode> Parse()
        {
            while (!IsAtEnd())
            {
                yield return ParseStatement();
            }
        }

        /// <summary>
        /// Parses a single statement
        /// </summary>
        private AstNode ParseStatement()
        {
            // Check if this is an assignment statement
            if (_currentToken.Type == TokenType.Identifier && _nextToken?.Type == TokenType.Assign)
            {
                return ParseAssignment();
            }

            throw new Exception($"Unexpected token: {_currentToken}");
        }

        /// <summary>
        /// Parses an assignment statement: identifier = expression
        /// </summary>
        private AssignNode ParseAssignment()
        {
            var variableName = _currentToken.Value;
            Advance(); // consume identifier

            if (_currentToken.Type != TokenType.Assign)
            {
                throw new Exception($"Expected '=' but got {_currentToken}");
            }
            Advance(); // consume '='

            var value = ParseExpression();

            return new AssignNode(variableName, value);
        }

        /// <summary>
        /// Parses an expression (for now, just literals)
        /// </summary>
        private AstNode ParseExpression()
        {
            return ParsePrimary();
        }

        /// <summary>
        /// Parses primary expressions (numbers, variables)
        /// </summary>
        private AstNode ParsePrimary()
        {
            var token = _currentToken;

            if (token.Type == TokenType.Integer)
            {
                Advance();
                return new NumberNode(int.Parse(token.Value));
            }

            if (token.Type == TokenType.Identifier)
            {
                Advance();
                return new VariableNode(token.Value);
            }

            throw new Exception($"Unexpected token in expression: {token}");
        }

        /// <summary>
        /// Checks if we've reached the end of tokens
        /// </summary>
        private bool IsAtEnd()
        {
            return _currentToken.Type == TokenType.EndOfFile;
        }

        /// <summary>
        /// Advances to the next token
        /// </summary>
        private void Advance()
        {
            if (_nextToken != null)
            {
                _currentToken = _nextToken;
                
                // Load next token
                if (_tokenEnumerator.MoveNext())
                {
                    _nextToken = _tokenEnumerator.Current;
                }
                else
                {
                    _nextToken = null;
                }
            }
            else if (!IsAtEnd())
            {
                _currentToken = new Token(TokenType.EndOfFile, string.Empty, _currentToken.Position);
            }
        }
    }
}
