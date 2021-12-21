using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresentationWebApi.Models;
using AutoMapper;
using PresentationApplication.Presentations.Commands.CreatePresentation;
using PresentationApplication.Presentations.Queries.GetPresentationInfo;
using PresentationApplication.Presentations.Commands.UpdatePresentation;
using PresentationApplication.Presentations.Commands.DeleteCommand;
using PresentationApplication.Presentations.Commands.ClosingPresentation;

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
        [HttpPut]
        public async Task<ActionResult> PresentationUpdate([FromBody] UpdatePresentationDto updatePresentationDto)
        {
            var command = _mapper.Map<UpdatePresentationCommand>(updatePresentationDto);
            
            await Mediator.Send(command);
            return NoContent();
        }


        [HttpPut]
        public async Task<ActionResult> ClosingPresentation([FromBody] ClosingPresentationDto closingPresentationDto)
        {
            var command = _mapper.Map<ClosingPresentationCommand>(closingPresentationDto);

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePresentation(Guid id)
        {
            var command = new DeletePresentationCommand
            {
                EventId = id,
              
            };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
