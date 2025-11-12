using MediatR;
using Microsoft.AspNetCore.Mvc;
using TBC.PersonRegistry.Application.Commons;
using TBC.PersonRegistry.Application.DTOs;
using TBC.PersonRegistry.Application.DTOs.Reports;
using TBC.PersonRegistry.Application.Features.People.Commands;
using TBC.PersonRegistry.Application.Features.People.Commands.Create.Person;
using TBC.PersonRegistry.Application.Features.People.Commands.Create.PersonRelation;
using TBC.PersonRegistry.Application.Features.People.Commands.Delete.Person;
using TBC.PersonRegistry.Application.Features.People.Commands.Delete.PersonRelation;
using TBC.PersonRegistry.Application.Features.People.Commands.Update;
using TBC.PersonRegistry.Application.Features.People.Queries.GetPeople;
using TBC.PersonRegistry.Application.Features.People.Queries.GetPersonDetails;
using TBC.PersonRegistry.Application.Features.People.Queries.GetRelatedPersonsReport;

namespace TBC.PersonRegistry.API.Controllers
{  
    /// <summary>
   /// People Controller
   /// </summary>
    [Route("api/[controller]")]
    [ApiController]
   // [ValidationFilterAttribute]
    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        public PersonController(IMediator mediator) => this.mediator = mediator;


        /// <summary>
        /// Create Person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);
            return CreatedAtRoute("GetPersonById", new { id = result }, result);
        }

        /// <summary>
        /// Update Person
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePersonCommand request, CancellationToken cancellationToken = default)
        {
            await mediator.Send(request.SetPersonId(id), cancellationToken);
            return Ok();
        }


        /// <summary>
        /// Delete Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id, CancellationToken cancellationToken = default)
           => await mediator.Send(new DeletePersonCommand { Id = id }, cancellationToken);



        /// <summary>
        /// Create person relationship
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPut("Relation")]
        public async Task<IActionResult> AddRelation([FromBody] CreatePersonRelationCommand request)
        {
            await mediator.Send(request);
            return Ok();
        }

        /// <summary>
        /// Deletep person relationship
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("DeleteRelatedPerson")]
        public async Task DeleteRelatedPerson(DeletePersonRelationCommand request)
            => await mediator.Send(request);


        /// <summary>
        /// Get Person By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        [HttpGet("{id}", Name = "GetPersonById")]
        public async Task<GetPersonDTO> GetPersonById([FromRoute] int id, CancellationToken cancellationToken) =>
           await mediator.Send(new GetPersonDetailsQuery { Id = id }, cancellationToken);


        /// <summary>
        /// Get People
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("GetPeople")]
        public async Task<Pagination<GetPersonDTO>> Get([FromQuery] GetPeopleQuery request, CancellationToken cancellationToken = default)
              => await mediator.Send(request, cancellationToken);



        /// <summary>
        /// Add Edit Person Image
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost("UploadPicture")]
        public async Task<IActionResult> AddEditPicture([FromForm] UploadPersonImageCommand request)
        {
            await mediator.Send(request);
            return Ok(new { message = "ფოტო წარმატებით აიტვირთა." });
        }


        /// <summary>
        /// Get People Relationship Report
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        [HttpGet("PeopleReport")]
        public async Task<IEnumerable<GetRelatedPersonsReportDto>> GetPeopleRelations(CancellationToken cancellationToken = default)
           => await mediator.Send(new GetRelatedPersonsReportQuery(), cancellationToken);
    }
}
