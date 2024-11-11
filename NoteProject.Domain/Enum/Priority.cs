using System.ComponentModel.DataAnnotations;

namespace noteProject.Domain.Enum
{
    public enum Priority
    {
        [Display(Name = "Рабочый")]
        Easy = 1,
        [Display(Name = "Личный")]
        Medium = 2

    }
}
