using Application.Profiles.Dto;
using Application.Profiles.Queries.GetMe;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/me")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ProfileOutput>> GetMe()
        {
            var myProfiles = await _mediator.Send(new GetMeQuery());
            return Ok(myProfiles);
        }

    }
}
