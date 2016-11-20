using Challenge.Domain.ValueObjects.MarvelApi.Character;
using Challenge.Domain.ValueObjects.MarvelApi.Comics;
using System;
using System.Threading.Tasks;

namespace Challenge.Domain.Contracts.External_Services.MarvelApi
{
    public interface ICharacterExternalService
    {
        bool ValidAuthentication(string url);
        Task<CharacterRootObject> GetCharacter(string url);
        Task<ComicsRootObject> GetComicsByCharacterId(string url);
    }
}
