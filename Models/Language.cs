using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restful_crud_asp.net.Models;

public class Language
{
    [Key]
    public int language_id { get; set; }

    public string Name { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? last_update { get; set; }

}
