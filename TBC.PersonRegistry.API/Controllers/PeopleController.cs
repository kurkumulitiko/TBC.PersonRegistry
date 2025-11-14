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
    public class PeopleController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        public PeopleController(IMediator mediator) => this.mediator = mediator;


        /// <summary>
        ///  Creates a new person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken).ConfigureAwait(false); ;
            return CreatedAtRoute("GetPersonById", new { id = result }, result);
        }

        /// <summary>
        /// Updates existing person data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePersonCommand request, CancellationToken cancellationToken = default)
        {
            await mediator.Send(request.SetPersonId(id), cancellationToken).ConfigureAwait(false); ;
            return Ok();
        }


        /// <summary>
        /// Deletes a person by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id, CancellationToken cancellationToken = default)
           => await mediator.Send(new DeletePersonCommand { Id = id }, cancellationToken).ConfigureAwait(false);


        /// <summary>
        /// Returns person details by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        [HttpGet("{id}", Name = "GetPersonById")]
        public async Task<GetPersonDTO> GetPersonById([FromRoute] int id, CancellationToken cancellationToken) =>
           await mediator.Send(new GetPersonDetailsQuery { Id = id }, cancellationToken).ConfigureAwait(false);


        /// <summary>
        /// Returns paginated list of people
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<Pagination<GetPersonDTO>> Get([FromQuery] GetPeopleQuery request, CancellationToken cancellationToken = default)
              => await mediator.Send(request, cancellationToken).ConfigureAwait(false);


        /// <summary>
        /// Creates a person relationship
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPut("relations")]
        public async Task<IActionResult> AddRelation([FromBody] CreatePersonRelationCommand request, CancellationToken cancellationToken = default)
        {
            await mediator.Send(request, cancellationToken).ConfigureAwait(false);
            return Ok();
        }

        /// <summary>
        ///Deletes a person relationship
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("relations")]
        public async Task RemoveRelation([FromBody] DeletePersonRelationCommand request, CancellationToken cancellationToken = default)
            => await mediator.Send(request, cancellationToken).ConfigureAwait(false);



        /// <summary>
        /// Uploads or replaces person's profile picture
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost("picture")]
        public async Task<IActionResult> AddEditPicture([FromForm] UploadPersonImageCommand request, CancellationToken cancellationToken = default)
        {
            await mediator.Send(request, cancellationToken).ConfigureAwait(false);
            return Ok(new { message = "ფოტო წარმატებით აიტვირთა." });
        }


        /// <summary>
        /// Returns report of related persons
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        [HttpGet("report")]
        public async Task<IEnumerable<GetRelatedPersonsReportDto>> GetPeopleRelations(CancellationToken cancellationToken = default)
           => await mediator.Send(new GetRelatedPersonsReportQuery(), cancellationToken).ConfigureAwait(false);
    }
}
