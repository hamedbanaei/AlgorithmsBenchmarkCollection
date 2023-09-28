using System.Linq;

namespace Model;

public class Couple : object
{
    public Couple(string fatherName, string motherName, System.DateTime marriageDate)
    {
        Id = Guid.NewGuid();

        FatherName = fatherName;
        MotherName = motherName;
        MarriageDate = marriageDate;

        Children = new System.Collections.Generic.List<Child>();
    }

    [System.ComponentModel.DataAnnotations.Key]
    public Guid Id { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.MinLength(3)]
    [System.ComponentModel.DataAnnotations.MaxLength(100)]
    public string FatherName { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.MinLength(3)]
    [System.ComponentModel.DataAnnotations.MaxLength(100)]
    public string MotherName { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
    public DateTime MarriageDate { get; set; }

    public virtual System.Collections.Generic.IList<Child> Children { get; private set; }
}
