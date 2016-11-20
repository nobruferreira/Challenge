using System;
using Challenge.Domain.Commands.MarvelApi;
using Challenge.Domain.ValueObjects.MarvelApi.Character;
using Challenge.Domain.ValueObjects.MarvelApi.Comics;
using Challenge.Domain.Contracts.Services.MarvelApi;
using Challenge.Domain.Contracts.External_Services.MarvelApi;
using Challenge.Domain.Resources;
using Challenge.ExternalService.CacheOfMemory.MarvelApi;
using Challenge.Data.CacheOfMemory.MarvelApi;

namespace Challenge.ApplicationService.Services.MarvelApi
{
    public class CharacterAppService : ICharacterAppService
    {
        private readonly ICharacterExternalService _characterExternalService;

        public CharacterAppService(ICharacterExternalService characterExternalService)
        {
            _characterExternalService = characterExternalService;
        }

        public bool ValidAuthentication(AccessTokenCommand command, string skip, string take)
        {
            var accessToken = new AccessToken(command.PrivateKey, command.PublicKey);

            var timeStamp = accessToken.GetTimeStamp();
            var hash = accessToken.CreateHash(timeStamp);

            string MARVEL_API_BASE_URL = Urls.ResourceManager.GetString("MARVEL_API_BASE_URL");
            string MARVEL_API_CHARACTER_URL = Urls.ResourceManager.GetString("MARVEL_API_CHARACTER_URL");
            string limit = take;
            string offset = skip;

            var url = String.Format("{0}{1}limit={2}&offset={3}&ts={4}&apikey={5}&hash={6}", MARVEL_API_BASE_URL, MARVEL_API_CHARACTER_URL, limit, offset, timeStamp, accessToken.PublicKey, hash).ToString();

            var isValidAuthentication = _characterExternalService.ValidAuthentication(url);
            return isValidAuthentication;
        }

        //Para desativar o cache só comentar a linha abaixo: [CacheCharacterRootObject]
        [CacheCharacterRootObject]
        public CharacterRootObject GetCharacter(AccessTokenCommand command, string skip, string take)
        {
            var accessToken = new AccessToken(command.PrivateKey, command.PublicKey);
           
            var timeStamp = accessToken.GetTimeStamp();
            var hash = accessToken.CreateHash(timeStamp);

            string MARVEL_API_BASE_URL = Urls.ResourceManager.GetString("MARVEL_API_BASE_URL");
            string MARVEL_API_CHARACTER_URL = Urls.ResourceManager.GetString("MARVEL_API_CHARACTER_URL");
            string limit = take;
            string offset = skip;

            var url = String.Format("{0}{1}limit={2}&offset={3}&ts={4}&apikey={5}&hash={6}", MARVEL_API_BASE_URL, MARVEL_API_CHARACTER_URL, limit, offset, timeStamp, accessToken.PublicKey, hash).ToString();

            var characterExternalService = _characterExternalService.GetCharacter(url).Result;
            return characterExternalService;
        }

        //Para desativar o cache só comentar a linha abaixo: [CacheComicsRootObject]
        [CacheComicsRootObject]
        public ComicsRootObject GetComicsByCharacterId(AccessTokenCommand command, string characterId)
        {
            var accessToken = new AccessToken(command.PrivateKey, command.PublicKey);

            var timeStamp = accessToken.GetTimeStamp();
            var hash = accessToken.CreateHash(timeStamp);

            string MARVEL_API_BASE_URL = Urls.ResourceManager.GetString("MARVEL_API_BASE_URL");
            string MARVEL_API_COMICS_URL_PART1 = Urls.ResourceManager.GetString("MARVEL_API_COMICS_URL_PART1");
            string MARVEL_API_COMICS_URL_PART2 = Urls.ResourceManager.GetString("MARVEL_API_COMICS_URL_PART2");

            var url = String.Format("{0}{1}{2}{3}ts={4}&apikey={5}&hash={6}", MARVEL_API_BASE_URL, MARVEL_API_COMICS_URL_PART1, characterId, MARVEL_API_COMICS_URL_PART2, timeStamp, accessToken.PublicKey, hash).ToString();

            var comicsExternalService = _characterExternalService.GetComicsByCharacterId(url).Result;
            return comicsExternalService;
        }
    }
}
