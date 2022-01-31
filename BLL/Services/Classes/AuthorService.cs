using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL.Managers.Interfaces;
using BLL.Repositories.Classes;
using BLL.Repositories.Interfaces;
using Domain.Models;

namespace BLL.Services.Classes
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService()
        {
            _authorRepository = new AuthorRepository();
        }
        
        public void AddAuthor(Author author)
        {
            _authorRepository.Add(author);
        }

        public void EditAuthor(int authorIndex, Author author)
        {
            _authorRepository.Edit(authorIndex, author);
        }

        public void DeleteAuthor(int authorIndex)
        {
            _authorRepository.Delete(authorIndex);
        }

        public Author GetAuthorByName(string name)
        { 
            return _authorRepository.FindByName(name);
        }

        public List<Author> FindManyAuthors(Expression<Func<Author, bool>> filter = null)
        {
            return _authorRepository.FindMany(filter);
        }

        public Author FindOneAuthor(Expression<Func<Author, bool>> filter = null)
        {
            return _authorRepository.FindOne(filter);
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
        }
    }
}