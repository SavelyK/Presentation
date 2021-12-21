using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresentationApplication.Presentations.Commands.CreateVisitor;
using PresentationApplication.Presentations.Commands.DeleteVisiterCommand;
using PresentationApplication.Presentations.Commands.UpdateVisiter;
using PresentationApplication.Presentations.Queries.GetNumberOfVisitors;
using PresentationWebApi.Models;
using System;
using System.Threading.Tasks;

namespace PresentationWebApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class VisitorsController : BaseController
    {
        private readonly IMapper _mapper;
        public VisitorsController(IMapper mapper) => _mapper = mapper;


        [HttpPost]
        public async Task<ActionResult<Guid>> CreateVisitor([FromBody] CreateVisitorDto createVisitorDto)
        {
            var command = _mapper.Map<CreateVisitorCommand>(createVisitorDto);
            
            var visiterId = await Mediator.Send(command);
            return Ok(visiterId);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GetNumberOfVisitorsVm>> GetNumberOfVisitors(Guid id)
        {
            var query = new GetNumberOfVisitorsQuery
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
                return Ok(vm.Count);
            }
        }

        [HttpPut]
        public async Task<ActionResult> VisitorUpdate([FromBody] UpdateVisitorDto updateVisitorDto)
        {
            var command = _mapper.Map<UpdateVisitorCommand>(updateVisitorDto);

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{idVisiter} , {idEvent}")]
        public async Task<IActionResult> DeleteVisiter (Guid idVisiter, Guid idEvent)
        {
            var command = new DeleteVisiterCommand
            {
                VisitorId = idVisiter,
                EventId = idEvent,

            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
