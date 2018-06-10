using System;

namespace CsOhm
{
    /// <summary>
    /// Represents an error that occured while using CsOhm
    /// </summary>
    /// <inheritdoc cref="Exception"/>
    public class CsOhmException : Exception
    {
        public CsOhmException(string messsage) : base(messsage)
        {
        }
    }
}
