using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BLL.Repositories.Interfaces;
using Domain;
using Domain.Models;

namespace BLL.Repositories.Classes
{
    public class ComicsRepository : IComicsRepository
    {
        public void Add(Comics entity)
        {
            FakeDBContext.Comicses.Add(entity);

            if (!FakeDBContext.Authors.Contains(entity.Author))
            {
                FakeDBContext.Authors.Add(entity.Author);
            }

            foreach (var tag in entity.Tags.Where(tag => !FakeDBContext.Tags.Contains(tag)))
            {
                FakeDBContext.Tags.Add(tag);
            }
        }

        public void Edit(int index, Comics entity)
        {
            FakeDBContext.Comicses[index] = entity;
        }

        public void Delete(int index)
        {
            FakeDBContext.Comicses.RemoveAt(index);
        }

        public List<Comics> GetAll()
        {
            return FakeDBContext.Comicses;
        }

        public Comics FindByName(string name)
        {
            return FakeDBContext.Comicses.FirstOrDefault(x => x.Name == name);
        }

        public Comics FindOne(Expression<Func<Comics, bool>> filter = null)
        {
            if (filter != null)
            {
                return FakeDBContext.Comicses.FirstOrDefault(filter.Compile());
            }

            return FakeDBContext.Comicses.First();
        }

        public List<Comics> FindMany(Expression<Func<Comics, bool>> filter = null)
        {
            if (filter != null)
            {
                return FakeDBContext.Comicses.Where(filter.Compile()).ToList();
            }

            return FakeDBContext.Comicses;
        }
    }
}