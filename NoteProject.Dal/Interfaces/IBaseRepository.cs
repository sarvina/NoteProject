using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteProject.Dal.Interfaces;
using NoteProject.Domain.Entity;


namespace NoteProject.Dal.Interfaces;

public interface IBaseRepository<T>
{

    Task Create(T entity);
    IQueryable<T> GetAll();
    Task Delete(T entity);
    Task<T> Update(T entity);



}

