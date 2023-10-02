namespace Model;

public class Child : System.Object
{
    public Child() { }

    public long Id { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.MinLength(3)]
    [System.ComponentModel.DataAnnotations.MaxLength(100)]
    public string Name { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    public long FatherId { get; set; }


    [System.ComponentModel.DataAnnotations.Required]
    public virtual Father? Father { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.MaxLength(100)]
    public string Avatar { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    [System.ComponentModel.DataAnnotations.MaxLength(1000)]
    public string Description { get; set; }
}
