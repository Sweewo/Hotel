namespace Hotel.Application.Infrastructure
{
    public class SettingsModel
    {
        public string UserAuthInfoEndpoint { get; set; }
        public string TokenSigningKey { get; set; }
        public string GoogleCloudStorageCredFile { get; set; }
        public string GoogleCloudStorageName { get; set; }
    }
}
