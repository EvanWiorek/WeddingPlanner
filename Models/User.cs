

#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;

public class User
{
  [Key]
  public int UserId { get; set; }
  [Required(ErrorMessage = "First name is required.")]
  public string FirstName { get; set; }
  [Required(ErrorMessage = "Last name is required.")]
  public string LastName { get; set; }
  [Required(ErrorMessage = "Email is required.")]
  [EmailAddress]
  [UniqueEmail]
  public string Email { get; set; }
  [Required(ErrorMessage = "First name is required.")]
  [DataType(DataType.Password)]
  [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
  public string Password { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;

  [NotMapped]
  [Compare("Password")]
  [DataType(DataType.Password)]
  public string PasswordConfirm { get; set; }
  public List<Wedding> PlannedWeddings { get;set; } = new List<Wedding>();
  public List<RSVP> WeddingsGoingTo { get;set; } = new List<RSVP>();
}