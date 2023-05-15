#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class Wedding
{
  [Key]
  public int WeddingId { get;set; }
  [Required(ErrorMessage = "Wedder One is required.")]
  public string WedderOne { get;set; }
  [Required(ErrorMessage = "Wedder Two is required.")]
  public string WedderTwo { get;set; }
  [Required(ErrorMessage = "A date is required.")]
  [DataType(DataType.Date)]
  [FutureDate]
  public DateTime? WeddingDate { get;set; }
  [Required(ErrorMessage = "Address is required.")]
  public string Address { get;set; }
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
  public int UserId { get;set; }
  public User? Planner { get;set; }
  public List<RSVP> PeopleGoing { get;set; } = new List<RSVP>();
}