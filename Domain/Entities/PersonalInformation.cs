namespace Domain.Entities;

public class PersonalInformation : EntityBase<string>
{
    public string tipoDocumento { get; set; }
    public string documento { get; set; }
    public string nombre1 { get; set; }
    public string nombre2 { get; set; }
    public string apellido1 { get; set; }
    public string apellido2 { get; set; }
    public DateTime fechaNacimiento { get; set; }
    public string sexo { get; set; }

    public PersonalInformation(
        string tipoDocumento,
        string documento,
        string nombre1,
        string nombre2,
        string apellido1,
        string apellido2,
        DateTime fechaCumpleaños,
        string sexo)
    {
       this.tipoDocumento = tipoDocumento;
        this.documento = documento;
        this.nombre1 = nombre1;
        this.nombre2 = nombre2;
        this.apellido1 = apellido1;
        this.apellido2 = apellido2;
        this.fechaNacimiento = fechaCumpleaños;
        this.sexo = sexo;
    }

    public void Update(
        string tipoDocumento,
        string documento,
        string nombre1,
        string nombre2,
        string apellido1,
        string apellido2
    )
    {
        if (tipoDocumento != string.Empty && !(tipoDocumento).Equals(this.tipoDocumento))
        {
            this.tipoDocumento = tipoDocumento;
        }

        if (documento != string.Empty && !(documento).Equals(this.documento))
        {
            this.documento = documento;
        }

        if (nombre1 != string.Empty && !(nombre1).Equals(this.nombre1))
        {
            this.nombre1 = nombre1;
        }

        if (nombre2 != string.Empty && !(nombre2).Equals(this.nombre2))
        {
            this.nombre2 = nombre2;
        }

        if (apellido1 != string.Empty && !(apellido1).Equals(this.apellido1))
        {
            this.apellido1 = apellido1;
        }

        if (apellido2 != string.Empty && !(apellido2).Equals(this.apellido2))
        {
            this.apellido2 = apellido2;
        }
    }
}