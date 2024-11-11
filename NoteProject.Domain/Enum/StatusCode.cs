using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.Domain.Enum;

public enum StatusCode
{
    NotesISHasAlready = 1,
    OK = 200,
    InternalServerError = 500
}
