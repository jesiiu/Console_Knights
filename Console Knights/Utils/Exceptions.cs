namespace Console_Knights.Utils.Exceptions
{
    public class NotInitializedException : Exception
    {
        public NotInitializedException() { }
        public NotInitializedException(string message) : base(message) { }
        public NotInitializedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
