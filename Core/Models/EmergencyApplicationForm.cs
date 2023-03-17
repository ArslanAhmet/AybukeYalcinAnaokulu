using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AybukeYalcinAnaokulu.Core.Models;

public class EmergencyApplicationForm
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;

    public string MotherNameSurname { get; set; } = null!;
    public string MotherHomeAdress { get; set; } = null!;
    public long MotherHomePhone { get; set; }
    public string MotherWorkAdress { get; set; } = null!;
    public long MotherWorkPhone { get; set; }
    public string MotherDescription { get; set; } = null!;

    public string FatherNameSurname { get; set; } = null!;
    public string FatherHomeAdress { get; set; } = null!;
    public long FatherHomePhone { get; set; }
    public string FatherWorkAdress { get; set; } = null!;
    public long FatherWorkPhone { get; set; }
    public string FatherDescription { get; set; } = null!;

    public string ThirdPersonNameSurname { get; set; } = null!;
    public string ThirdPersonHomeAdress { get; set; } = null!;
    public long ThirdPersonHomePhone { get; set; }
    public string ThirdPersonWorkAdress { get; set; } = null!;
    public long ThirdPersonWorkPhone { get; set; }
    public string ThirdPersonDescription { get; set; } = null!;
    public string SchoolArrivalStatus { get; set; } = null!;

}
