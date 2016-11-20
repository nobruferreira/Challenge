using Challenge.Domain.Commands.MarvelApi;
using Challenge.Domain.Contracts.Services.MarvelApi;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Challenge.Api.Controllers
{
    [RoutePrefix("api/character")]
    public class CharacterController : BaseController
    {
        ICharacterAppService _characterAppService;

        public CharacterController(ICharacterAppService characterAppService)
        {
            _characterAppService = characterAppService;
        }

        [HttpPost]
        [Route("valid/authentication")]
        public Task<HttpResponseMessage> ValidAuthentication([FromBody] dynamic body)
        {
            var accessTokenCommand = new AccessTokenCommand(
                privateKey: (string)body.privateKey,
                publicKey: (string)body.publicKey
            );

            string skip = (string)body.skip;
            string take = (string)body.take;

            var isValidAuthentication = _characterAppService.ValidAuthentication(accessTokenCommand, skip, take);
            return CreateResponse(HttpStatusCode.Created, isValidAuthentication);
        }

        [Authorize]
        [HttpPost]
        [Route("list")]
        public Task<HttpResponseMessage> GetCharacter([FromBody] dynamic body)
        {
            var accessTokenCommand = new AccessTokenCommand(
                privateKey: (string)body.privateKey,
                publicKey: (string)body.publicKey
            );

            string skip = (string)body.skip;
            string take = (string)body.take;

            var character = _characterAppService.GetCharacter(accessTokenCommand, skip, take);
            return CreateResponse(HttpStatusCode.Created, character);
        }

        [Authorize]
        [HttpPost]
        [Route("list/comics/characterId")]
        public Task<HttpResponseMessage> GetComicsByCharacterId([FromBody] dynamic body)
        {
            var accessTokenCommand = new AccessTokenCommand(
                privateKey: (string)body.privateKey,
                publicKey: (string)body.publicKey
            );

            string characterId = (string)body.characterId;

            var comicsByCharacterId = _characterAppService.GetComicsByCharacterId(accessTokenCommand, characterId);
            return CreateResponse(HttpStatusCode.Created, comicsByCharacterId);
        }
    }
}