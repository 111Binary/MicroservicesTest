using System;

namespace MicroservicesTest.Common.Exceptions
{
    public class MicroservicesTestException : Exception
    {
        public string Code { get; }

        public MicroservicesTestException()
        {
        }

        public MicroservicesTestException(string code)
        {
            Code = code;
        }

        public MicroservicesTestException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public MicroservicesTestException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public MicroservicesTestException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public MicroservicesTestException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }        
    }
}