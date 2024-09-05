using Petfolio.Communication.Enums;

namespace Petfolio.Communication.Responses;

public class ResponseGetAllPetsJson
{
    public List<ResponseShortAllPets> Pets { get; set; } = [];
}
 public class ResponseShortAllPets
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PetType Type { get; set; }
}
