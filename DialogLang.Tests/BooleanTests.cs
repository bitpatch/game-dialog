using BitPatch.DialogLang;

namespace DialogLang.Tests;

public class BooleanTests
{
    private static List<object> ExecuteScript(string script)
    {
        var dialog = new Dialog();
        return dialog.Execute(script).ToList();
    }

    [Theory]
    [InlineData("<< true", true)]
    [InlineData("<< false", false)]
    public void BooleanLiterals(string script, bool expected)
    {
        // Act
        var results = ExecuteScript(script);

        // Assert
        Assert.Equal(new object[] { expected }, results);
    }
}
