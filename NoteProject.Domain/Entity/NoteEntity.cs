

using noteProject.Domain.Enum;

namespace NoteProject.Domain.Entity;

public class NoteEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsDone { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }

    public Priority Priority { get; set; }

}