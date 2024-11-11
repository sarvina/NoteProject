using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.Domain.ViewModels.Note
{
    public class NoteViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Название  ")]
        public string Name { get; set;}

        [Display(Name = "Готовность")]
        public string IsDone { get; set; }

        [Display(Name = "Приоритет")]
        public string Priority { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Дата создания")]
        public string Created { get; set; }
    }
}
