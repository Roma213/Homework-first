using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Models;

namespace BLL.Managers.Interfaces
{
    public interface IAuthorService
    {
        void AddAuthor(Author author);

        void EditAuthor(int authorIndex, Author author);

        void DeleteAuthor(int authorIndex);

        Author GetAuthorByName(string name);

        List<Author> FindManyAuthors(Expression<Func<Author, bool>> filter = null);
        
        Author FindOneAuthor(Expression<Func<Author, bool>> filter = null);
        
        List<Author> GetAllAuthors();
    }
}