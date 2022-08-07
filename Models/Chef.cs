#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;

public class Chef
{
    [Key]
    [Required(ErrorMessage = "Please select a chef!")]
    public int ChefId {get;set;}

    [Required]
    [Display(Name = "First Name")]
    public string FirstName {get;set;}

    [Required]
    [Display(Name = "Last Name")]
    public string LastName {get;set;}

    [Required]
    [Display(Name = "Date of Birth")]
    [DateValidation]
    public DateTime DateOfBirth {get;set;}

    public int? Age()
    {
        int age = DateTime.Now.Year - DateOfBirth.Year;
        return age;
    }

    // Navigation property for related Dish objects
    public List<Dish> CreatedDishes {get;set;} = new List<Dish>();

    public DateTime CreatedAt {get;set;} = DateTime.Now;

    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}