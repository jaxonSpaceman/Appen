using System;
using System.ComponentModel.DataAnnotations;

namespace Appen.Enums
{
    public enum Djurtyp
    {
        [Display(Name = "Katt")]
        Katt = 1,
        [Display(Name = "Hund")]
        Hund = 2,
    }
}
