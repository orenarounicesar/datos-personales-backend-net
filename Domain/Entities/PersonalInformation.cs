namespace Domain.Entities;

public class PersonalInformation : EntityBase<string>
{
    public string DocumentType { get; set; }
    public string Document { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string SecondLastName { get; set; }
    public DateTime Birthdate { get; set; }
    public string Sex { get; set; }

    public PersonalInformation(
        string documentType,
        string document,
        string firstName,
        string secondName,
        string lastName,
        string secondLastName,
        DateTime birthdate,
        string sex)
    {
        DocumentType = documentType;
        Document = document;
        FirstName = firstName;
        SecondName = secondName;
        LastName = lastName;
        SecondLastName = secondLastName;
        Birthdate = birthdate;
        Sex = sex;
    }
}