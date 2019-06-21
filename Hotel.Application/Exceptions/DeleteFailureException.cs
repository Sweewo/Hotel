using System;

namespace Hotel.Application.Exceptions
{
    public class DeleteFailureException : Exception
    {
        public DeleteFailureException(string name, string message)
            : base($"Deletion of {name} failed. {message}")
        {
        }
    }
}
