using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NoteProject.Dal;
using NoteProject.Dal.Interfaces;
using NoteProject.Domain.Entity;
using NoteProject.Domain.Enum;
using NoteProject.Domain.Extenstion;
using NoteProject.Domain.Response;
using NoteProject.Domain.ViewModel.Note;
using NoteProject.Domain.ViewModels.Note;
using NoteProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.Service.Implementation;

public class NoteService : INoteService

{
    
    private readonly IBaseRepository<NoteEntity> _noteRepository;
    private ILogger<NoteService> _logger;
    public NoteService(IBaseRepository<NoteEntity> noteRepository, ILogger<NoteService> logger)
    {
        _noteRepository = noteRepository;
        _logger = logger;
    }


    public async Task<IBaseResponse<NoteEntity>> Create(CreateNoteViewModel model)
    {
        try
        {
            model.Validate();
            _logger.LogInformation(message: $"Zapros na sozdanie zametki - {model.Name}");

            var note = await _noteRepository.GetAll()
             .Where(x => x.Created.Date == DateTime.Today)
             .FirstOrDefaultAsync(x => x.Name == model.Name);

            if (note != null)
            {
                return new BaseResponse<NoteEntity>()
                {
                    Description = "Zametka s takim nazvaniem uje est",
                    StatusCode = StatusCode.NotesISHasAlready
                };
            }

            note = new NoteEntity()
            {
                Name = model.Name,
                IsDone = false,
                Description = model.Description,
                Priority = model.Priority,
                Created = DateTime.Now,
            };
            await _noteRepository.Create(note);
            _logger.LogInformation(message:$"Zametka sozdalas: {note.Name} {note.Created}");
            return new BaseResponse<NoteEntity>()
            {
                Description = "Zametka sozdalas",
                StatusCode = StatusCode.OK
            };
        }

        catch (Exception ex)
        {
           _logger.LogError(ex, message: $"[NoteService.Create]: {ex.Message}");
            return new BaseResponse<NoteEntity>()
            {
                Description = $"{ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<IEnumerable<NoteViewModel>>> GetNotes()
    {
        try
        {
            var notes = await _noteRepository.GetAll()
                .Select(x => new NoteViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsDone = x.IsDone == true ? "Готово" : "Не готово",
                    Priority = x.Priority.GetDisplayName(),
                    Created = x.Created.ToLongDateString() 
                })
                .ToListAsync();

            return new BaseResponse<IEnumerable<NoteViewModel>>()
            {
                Data = notes,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"[NoteService.GetTasks]: {ex.Message}");
            return new BaseResponse<IEnumerable<NoteViewModel>>()
            {
                Description = ex.Message,
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

}

