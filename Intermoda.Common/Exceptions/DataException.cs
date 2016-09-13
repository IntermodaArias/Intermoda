using System;

namespace Intermoda.Common.Exceptions
{
    public class DataException : ApplicationException
    {
        public DataException (string message) : base(message) { }

        public DataException(string message, Exception exception) : base(message, exception) { }
    }
}
