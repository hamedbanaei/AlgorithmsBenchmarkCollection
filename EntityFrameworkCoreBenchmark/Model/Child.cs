namespace Model;

public class Child : System.Object
{
    public Child(System.Guid parrentId, string name, System.DateTime birthDate)
    {
        Id = Guid.NewGuid();

        Name = name;
        ParrentId = parrentId;
        BirthDate = birthDate;
    }

    [System.ComponentModel.DataAnnotations.Key]
    public Guid Id { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.MinLength(3)]
    [System.ComponentModel.DataAnnotations.MaxLength(100)]
    public string Name { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
    public DateTime BirthDate { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    public System.Guid ParrentId { get; set; }


    [System.ComponentModel.DataAnnotations.Required]
    public virtual Couple? Parrent { get; set; }
}
