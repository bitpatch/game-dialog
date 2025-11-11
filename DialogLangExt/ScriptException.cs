using System;

namespace BitPatch.DialogLang
{
    /// <summary>
    /// Exception thrown when an error occurs during script execution.
    /// </summary>
    public class ScriptException : Exception
    {
        public ScriptException(string message) : base(message)
        {
        }
    }
}
