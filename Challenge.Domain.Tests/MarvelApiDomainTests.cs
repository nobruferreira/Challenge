using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge.Domain.Contracts.External_Services.MarvelApi;
using Challenge.ExternalService.MarvelApi;
using Challenge.Domain.Commands.MarvelApi;

namespace Challenge.Domain.Tests
{
    [TestClass]
    public class MarvelApiDomainTests
    {
        //GLOBAL KEYS
        private const string PRIVATE_KEY = "4b3bb065469cce132e2c06e152df70a487185e6f";
        private const string PUBLIC_KEY = "9d3953a1a0bb0e8051846b1d9569e8cf";

        //BASE URL
        private const string MARVEL_API_BASE_URL = "http://gateway.marvel.com:80/";

        //CHARACTER
        private const string MARVEL_API_CHARACTER_URL = "v1/public/characters?";
        private string limit = "10";
        private string offset = "0";

        //COMICS BY CHARACTER ID
        private const string MARVEL_API_COMICS_URL_PART1 = "v1/public/characters/";
        private string characterId = "1009144";
        private const string MARVEL_API_COMICS_URL_PART2 = "/comics?";

        [TestMethod]
        [TestCategory("MarvelApi - Domain")]
        public void Character_BuscaPersonagem_ValidaSeRetornoNaoEhNulo()
        {
            //Arrange
            var accessToken = new AccessToken(PRIVATE_KEY, PUBLIC_KEY);
            var timeStamp = accessToken.GetTimeStamp();
            var hash = accessToken.CreateHash(timeStamp);
            var url = String.Format("{0}{1}limit={2}&offset={3}&ts={4}&apikey={5}&hash={6}", MARVEL_API_BASE_URL, MARVEL_API_CHARACTER_URL, limit, offset, timeStamp, PUBLIC_KEY, hash).ToString();

            ICharacterExternalService characterExternalService = new CharacterExternalService();

            //Act
            var task = characterExternalService.GetCharacter(url).Result;

            //Assert
            Assert.AreEqual("Ok", task.status.ToString());
        }

        [TestMethod]
        [TestCategory("MarvelApi - Domain")]
        public void Character_BuscaHistoriaEmQuadrinhosDeUmPersonagemPorId_ValidaSeRetornoNaoEhNulo()
        {
            //Arrange
            var accessToken = new AccessToken(PRIVATE_KEY, PUBLIC_KEY);
            var timeStamp = accessToken.GetTimeStamp();
            var hash = accessToken.CreateHash(timeStamp);
            var url = String.Format("{0}{1}{2}{3}ts={4}&apikey={5}&hash={6}", MARVEL_API_BASE_URL, MARVEL_API_COMICS_URL_PART1, characterId, MARVEL_API_COMICS_URL_PART2, timeStamp, PUBLIC_KEY, hash).ToString();

            ICharacterExternalService characterExternalService = new CharacterExternalService();

            //Act
            var task = characterExternalService.GetComicsByCharacterId(url).Result;

            //Assert
            Assert.AreEqual("Ok", task.status.ToString());
        }
    }
}


