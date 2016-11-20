using Challenge.SharedKernel.Helpers;

namespace Challenge.Domain.Commands.MarvelApi
{
    public class AccessToken
    {
        public AccessToken(string privateKey, string publicKey)
        {
            PrivateKey = privateKey;
            PublicKey = publicKey;
        }

        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }

        public string GetTimeStamp()
        {
            var timeStamp = StringHelper.GetTicks();
            return timeStamp;
        }

        public string CreateHash(string timeStamp)
        {
            var toBeHashed = timeStamp + PrivateKey + PublicKey;
            var hashedMessage = StringHelper.Encrypt(toBeHashed);
            return hashedMessage;
        }
    }
}
