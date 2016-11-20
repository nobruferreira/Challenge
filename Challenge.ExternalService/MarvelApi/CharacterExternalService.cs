using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Challenge.Domain.ValueObjects.MarvelApi.Character;
using Challenge.Domain.ValueObjects.MarvelApi.Comics;
using Challenge.Domain.Contracts.External_Services.MarvelApi;
using System.Net;

namespace Challenge.ExternalService.MarvelApi
{
    public class CharacterExternalService : ExternalServiceBase, ICharacterExternalService
    {
        public bool ValidAuthentication(string url)
        {
            var response = Task.Run(() => Client.GetAsync(url)).Result;

            if (response.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }

        public async Task<CharacterRootObject> GetCharacter(string url)
        {
            var response = Task.Run(() => Client.GetAsync(url)).Result;

            CharacterRootObject characterRootObject;

            using (HttpContent content = response.Content)
            {
                string json = await content.ReadAsStringAsync();
                characterRootObject = JsonConvert.DeserializeObject<CharacterRootObject>(json);
            }

            return characterRootObject;
        }

        public async Task<ComicsRootObject> GetComicsByCharacterId(string url)
        {
            var response = Task.Run(() => Client.GetAsync(url)).Result;

            ComicsRootObject comicsRootObject;

            using (HttpContent content = response.Content)
            {
                string json = await content.ReadAsStringAsync();
                comicsRootObject = JsonConvert.DeserializeObject<ComicsRootObject>(json);
            }

            return comicsRootObject;
        }
    }
}
