using Petfolio.Communication.Enums;
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pet.GetById;

public class GetPetByIdUseCase
{
    public ResponseGetPetByIdJson Execute(int id)
    {
        return new ResponseGetPetByIdJson
        {
            Id = id,
            Birthday = DateTime.Now,
            Name = "Garfield",
            Type = PetType.Cat,
        };
    }
}
