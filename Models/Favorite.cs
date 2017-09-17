using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YfinderAPIdotnet2.Models
{
  public class Favorite
  {
    [Key]
    public int FavoriteId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public virtual User User { get; set; }

    [Required]
    public int HostId { get; set; }

    [Required]
    public virtual Host Host { get; set; }

  }
}