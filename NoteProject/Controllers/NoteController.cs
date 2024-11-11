using Microsoft.AspNetCore.Mvc;
using NoteProject.Domain.ViewModel.Note;
using NoteProject.Service.Interfaces;


namespace NoteProject.Controllers;

public class NoteController : Controller
{
    private readonly INoteService _noteService;
    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }

    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateNoteViewModel model)
    {

        var response = await _noteService.Create(model);

        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Ok(new { description = response.Description });
        }
        return BadRequest(error: new { description = response.Description });
    }
    [HttpPost]

    public async Task<IActionResult> NoteHandler()
    {
        var response = await _noteService.GetNotes();
        return Json(data:new { data=response.Data});
    }
}
