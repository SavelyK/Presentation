using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresentationWebApi.Models;
using AutoMapper;
using PresentationApplication.Presentations.Commands.CreatePresentation;
using PresentationApplication.Presentations.Queries.GetPresentationInfo;

namespace PresentationWebApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class PresentationController : BaseController
    {
        private readonly IMapper _mapper;
        public PresentationController(IMapper mapper) => _mapper = mapper;
        

        [HttpPost]
        public async Task<ActionResult<Guid>> CreatePresentation([FromBody] CreatePresentationDto createPresentationDto)
        {
            var command = _mapper.Map<CreatePresentationCommand>(createPresentationDto);
            command.EventCreatorId = UserId;       
            var presentationId = await Mediator.Send(command);
            return Ok(presentationId);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PresentationInfoVm>> GetPresentationInfo(Guid id)
        {
            var query = new GetPresentationInfoQuery
            {
                EventCreatorId = UserId,
                EventId = id
            };
            var vm = await Mediator.Send(query);
            if (vm == null)
            {
                return NotFound();
            }    
            else
            {
                return Ok(vm);
            }
        }


    }
}
