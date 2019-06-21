using System;

namespace Hotel.Application.Exceptions
{
    public class UploadImageException:Exception
    {
        public UploadImageException(string name, object key)
            : base($"Upload image \"{name}\" with service ({key}) failed.")
        {
        }
    }
}
