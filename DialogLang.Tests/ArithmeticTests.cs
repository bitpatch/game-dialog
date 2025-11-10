using System;
using System.Linq;
using DialogLang;
using Xunit;

namespace DialogLang.Tests
{
    public class ArithmeticTests
    {
        private class TestLogger : ILogger
        {
            public void LogInfo(string message) { }
            public void LogWarning(string message) { }
            public void LogError(string message) { }
        }

        private object? EvaluateExpression(string expression)
        {
            var interpreter = new Interpreter(new TestLogger());
            var script = $"<< {expression}";
            var results = interpreter.Run(script).ToList();
            return results.FirstOrDefault();
        }

        [Fact]
        public void Addition_ShouldReturnCorrectResult()
        {
            var result = EvaluateExpression("5 + 3");
            Assert.Equal(8, result);
        }

        [Fact]
        public void Subtraction_ShouldReturnCorrectResult()
        {
            var result = EvaluateExpression("10 - 4");
            Assert.Equal(6, result);
        }

        [Fact]
        public void Multiplication_ShouldReturnCorrectResult()
        {
            var result = EvaluateExpression("6 * 7");
            Assert.Equal(42, result);
        }

        [Fact]
        public void Division_ShouldReturnCorrectResult()
        {
            var result = EvaluateExpression("20 / 5");
            Assert.Equal(4, result);
        }

        [Fact]
        public void DivisionByZero_ShouldThrowException()
        {
            Assert.Throws<DivideByZeroException>(() => EvaluateExpression("10 / 0"));
        }

        [Fact]
        public void ComplexExpression_ShouldRespectOperatorPrecedence()
        {
            // 2 + 3 * 4 should equal 14, not 20
            var result = EvaluateExpression("2 + 3 * 4");
            Assert.Equal(14, result);
        }

        [Fact]
        public void ParenthesesExpression_ShouldRespectParentheses()
        {
            // (2 + 3) * 4 should equal 20
            var result = EvaluateExpression("(2 + 3) * 4");
            Assert.Equal(20, result);
        }

        [Fact]
        public void MultipleOperations_ShouldReturnCorrectResult()
        {
            var result = EvaluateExpression("10 + 5 - 3 * 2");
            Assert.Equal(9, result); // 10 + 5 - 6 = 9
        }

        [Fact]
        public void NestedParentheses_ShouldWorkCorrectly()
        {
            var result = EvaluateExpression("((10 + 5) * 2) - 6");
            Assert.Equal(24, result); // (15 * 2) - 6 = 24
        }

        [Fact]
        public void DecimalNumbers_ShouldWorkCorrectly()
        {
            var result = EvaluateExpression("5.5 + 2.5");
            Assert.Equal(8.0f, result);
        }

        [Fact]
        public void VariableArithmetic_ShouldWorkCorrectly()
        {
            var interpreter = new Interpreter(new TestLogger());
            var script = @"a = 10
b = 20
<< a + b";
            var results = interpreter.Run(script).ToList();
            Assert.Single(results);
            Assert.Equal(30, results[0]);
        }

        [Fact]
        public void ComplexVariableExpression_ShouldWorkCorrectly()
        {
            var interpreter = new Interpreter(new TestLogger());
            var script = @"x = 5
y = 3
z = x * 2 + y
<< z";
            var results = interpreter.Run(script).ToList();
            Assert.Single(results);
            Assert.Equal(13, results[0]); // 5 * 2 + 3 = 13
        }
    }
}
