using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pet.DeleteById;
using Petfolio.Application.UseCases.Pet.GetAll;
using Petfolio.Application.UseCases.Pet.GetById;
using Petfolio.Application.UseCases.Pet.Register;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    #region [POST]
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterPetJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterPetJson request)
    {
        //business logic
        var response = new RegisterPetUseCase().Execute(request);

        return Created(string.Empty, response);
    }
    #endregion [POST]

    #region [GET]
    [HttpGet]
    [ProducesResponseType(typeof(ResponseGetPetByIdJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status204NoContent)]
    public IActionResult GetAllPets()
    {
        //business logic
        var response = new GetAllPetsUseCase().Execute();

        if (response.Pets.Any())
        {
            return Ok(response);
        }

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseGetPetByIdJson), StatusCodes.Status200OK)]
    public IActionResult GetPetById([FromRoute] int id)
    {
        //business logic
        var response = new GetPetByIdUseCase().Execute(id);

        return Ok(response);
    }
    #endregion [GET]

    #region [UPDATE]
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult UpdatePetById([FromRoute] int id, [FromBody] RequestRegisterPetJson request)
    {
        //business logic
        new UpdatePetUseCase().Execute(id, request);

        return NoContent();
    }
    #endregion [UPDATE]

    #region [DELETE]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [Route("{id}")]
    public IActionResult DeletePetById([FromRoute] int id)
    {
        //business logic
        new DeletePetByIdUseCase().Execute(id);

        return NoContent();
    }

    #endregion [DELETE]
}
