using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YfinderAPIdotnet2.Models
{
  public class Rating
  {
    [Key]
    public int RatingId { get; set; }

    public string Comment { get; set; }

    [DataType(DataType.Date)]
    public DateTime RatingDate { get; set; }

    [Required]
    public int HotspotId { get; set; }
    public Hotspot Hotspot { get; set; }

    [Required]
    public int Public { get; set; } // int as bool

    [Required]
    public int Score { get; set; }

    public float? Speed { get; set; }

    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }

    public virtual ICollection<RatingDescriptor> RatingDescriptor { get; set ; }

    public Rating() {
      RatingDate = DateTime.Now;
    }

  }
}