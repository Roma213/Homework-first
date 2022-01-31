using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BLL.Repositories.Interfaces;
using Domain;
using Domain.Models;

namespace BLL.Repositories.Classes
{
    public class AuthorRepository : IAuthorRepository
    {
        public void Add(Author entity)
        {
            FakeDBContext.Authors.Add(entity);

            foreach (var comics in entity.Comicses.Where(comics => !FakeDBContext.Comicses.Contains(comics)))
            {
                FakeDBContext.Comicses.Add(comics);
            }
        }

        public void Edit(int index, Author entity)
        {
            FakeDBContext.Authors[index] = entity;
        }

        public void Delete(int index)
        {
            FakeDBContext.Authors.RemoveAt(index);
        }

        public List<Author> GetAll()
        {
            return FakeDBContext.Authors;
        }

        public Author FindByName(string name)
        {
            return FakeDBContext.Authors.FirstOrDefault(x => x.FirstName == name);
        }

        public Author FindOne(Expression<Func<Author, bool>> filter = null)
        {
            if (filter != null)
            {
                return FakeDBContext.Authors.FirstOrDefault(filter.Compile());
            }

            return FakeDBContext.Authors.First();
        }

        public List<Author> FindMany(Expression<Func<Author, bool>> filter = null)
        {
            if (filter != null)
            {
                return FakeDBContext.Authors.Where(filter.Compile()).ToList();
            }

            return FakeDBContext.Authors;
        }
    }
}