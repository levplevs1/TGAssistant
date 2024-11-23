using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.CreateArticles_Housing_Code;
using TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.DeleteArticles_Housing_Code;
using TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.UpdateArticles_Housing_Code;
using TelegramBot.Application.src.Entities.Articles_Housing_Code.Queries.GetArticles_Housing_CodeDetails;
using TelegramBot.Application.src.Entities.Articles_Housing_Code.Queries.GetArticles_Housing_CodeList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Articles_Housing_Code;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Articles_Housing_CodeController : BaseController
    {
        private readonly IMapper _mapper;

        public Articles_Housing_CodeController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<Articles_Housing_CodeListVm>> GetAllArticles_Housing_Code()
        {
            var query = new GetArticles_Housing_CodeListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_articles_housing_code}")]
        public async Task<ActionResult<Articles_Housing_CodeDetailsVm>> GetArticles_Housing_CodeDetails(int id_articles_housing_code)
        {
            var query = new GetArticles_Housing_CodeDetailsQuery
            {
                id_articles_housing_code = id_articles_housing_code
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateArticles_Housing_Code([FromBody] CreateArticles_Housing_CodeDto createArticles_Housing_CodeDto)
        {
            var command = _mapper.Map<CreateArticles_Housing_CodeCommand>(createArticles_Housing_CodeDto);
            var id_articles_housing_code = await Mediator.Send(command);
            return Ok(id_articles_housing_code);
        }

        [HttpPut("{id_articles_housing_code}")]
        public async Task<IActionResult> UpdateArticles_Housing_Code(int id_articles_housing_code, [FromBody] UpdateArticles_Housing_CodeDto updateArticles_Housing_CodeDto)
        {
            var command = _mapper.Map<UpdateArticles_Housing_CodeCommand>(updateArticles_Housing_CodeDto);
            command.id_articles_housing_code = id_articles_housing_code;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_articles_housing_code}")]
        public async Task<IActionResult> DeleteArticles_Housing_Code(int id_articles_housing_code)
        {
            var command = new DeleteArticles_Housing_CodeCommand
            {
                id_articles_housing_code = id_articles_housing_code
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
