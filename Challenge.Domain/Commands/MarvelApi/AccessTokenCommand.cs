namespace Challenge.Domain.Commands.MarvelApi
{
    public class AccessTokenCommand
    {
        public AccessTokenCommand(string privateKey, string publicKey)
        {
            PrivateKey = privateKey;
            PublicKey = publicKey;
        }

        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
    }
}
