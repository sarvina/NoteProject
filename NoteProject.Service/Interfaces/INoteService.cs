using NoteProject.Domain.Entity;
using NoteProject.Domain.Response;
using NoteProject.Domain.ViewModel.Note;
using NoteProject.Domain.ViewModels.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.Service.Interfaces;


    public interface INoteService
{
    Task<IBaseResponse<NoteEntity>> Create(CreateNoteViewModel model);

    Task<IBaseResponse<IEnumerable<NoteViewModel>>> GetNotes();
}

