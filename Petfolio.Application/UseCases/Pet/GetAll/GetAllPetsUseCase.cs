using Petfolio.Communication.Enums;
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pet.GetAll;

public class GetAllPetsUseCase
{
    public ResponseGetAllPetsJson Execute()
    {

        var res = new ResponseGetAllPetsJson
        {
            Pets = new List<ResponseShortAllPets>()
            {
                new ResponseShortAllPets
                {
                    Id = 1,
                    Name = "Tico",
                    Type = PetType.Dog
                    
                }
            }
        };
        return res;
    }
}
