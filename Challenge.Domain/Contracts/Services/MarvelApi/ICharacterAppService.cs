using Challenge.Domain.Commands.MarvelApi;
using Challenge.Domain.ValueObjects.MarvelApi.Character;
using Challenge.Domain.ValueObjects.MarvelApi.Comics;
using System;

namespace Challenge.Domain.Contracts.Services.MarvelApi
{
    public interface ICharacterAppService
    {
        bool ValidAuthentication(AccessTokenCommand command, string skip, string take);
        CharacterRootObject GetCharacter(AccessTokenCommand command, string skip, string take);
        ComicsRootObject GetComicsByCharacterId(AccessTokenCommand command, string characterId);
    }
}
