
using noteProject.Domain.Enum;
using System.Xml.Linq;

namespace NoteProject.Domain.ViewModel.Note;

public class CreateNoteViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; }

    public void Validate()
    {
        if
            (string.IsNullOrWhiteSpace(Name))
        {
            throw new ArgumentNullException(Name, message: "Укажите название заметки");
        }
        if
           (string.IsNullOrWhiteSpace(Description))
        {
            throw new ArgumentNullException(paramName: Description, message: "Укажите описание заметки");
        }

    }
}


