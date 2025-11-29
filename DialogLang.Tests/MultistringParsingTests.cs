using BitPatch.DialogLang;

namespace DialogLang.Tests;

public class MultistringParsingTests
{
    [Fact]
    public void SimpleString()
    {
        // Arrange
        var source = "<< \"\"\"Hello, World!\"\"\"\t\t";

        var expected = new TokenSequence(
        [
            TokenType.Output, TokenType.StringStart, TokenType.InlineString, TokenType.StringEnd, TokenType.Newline,
            TokenType.EndOfSource
        ]);

        // Act
        var result = source.Tokenize();

        // Assert
        Assert.Equal(expected.Sequence, result);
    }

    [Fact]
    public void TwoStrings()
    {
        // Arrange
        var source = """"
            << """
                Hello,
                World!
                """
            """";

        var expected = new TokenSequence(
        [
            TokenType.Output, TokenType.StringStart,
            TokenType.Indent, TokenType.InlineString,
            TokenType.InlineString, TokenType.StringEnd, TokenType.Newline,
            TokenType.Dedent,
            TokenType.EndOfSource
        ]);

        // Act
        var result = source.Tokenize();

        // Assert
        Assert.Equal(expected.Sequence, result);

    }

    [Fact]
    public void TwoStringsAndExpression()
    {
        // Arrange
        var source = """"
            << """
                Hello {"World!"}
                Hello!
                """
            """";

        var expected = new TokenSequence(
        [
            TokenType.Output, TokenType.StringStart,
            TokenType.Indent, TokenType.InlineString, TokenType.InlineExpressionStart, TokenType.InlineString, TokenType.InlineExpressionEnd,
            TokenType.InlineString, TokenType.StringEnd, TokenType.Newline,
            TokenType.Dedent,
            TokenType.EndOfSource
        ]);

        // Act
        var result = source.Tokenize();

        // Assert
        Assert.Equal(expected.Sequence, result);

    }
}