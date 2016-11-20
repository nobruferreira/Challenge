using System;
using Challenge.SharedKernel.Helpers;
using Challenge.Domain.Commands.MarvelApi;

namespace Challenge.Domain.Entities
{
    public class Character
    {
        public Character(string characterId)
        {
            CharacterId = characterId;
        }

        public string CharacterId { get; set; }
    }
}
