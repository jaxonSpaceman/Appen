using System;
using System.ComponentModel.DataAnnotations;

namespace Appen.Enums
{
    public enum OrtTyp
    {
        [Display(Name = "Stad")]
        Stad = 1,
        [Display(Name = "Samhälle")]
        Samhalle = 2,
    }
}
