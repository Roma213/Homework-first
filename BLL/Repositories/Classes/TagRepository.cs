using BLL.Repositories.Interfaces;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BLL.Repositories.Classes
{
    public class TagRepository : ITagRepository
    {
        public void Add(Tag entity)
        {
            FakeDBContext.Tags.Add(entity);
        }
        
        public void Edit(int index, Tag entity)
        {
            FakeDBContext.Tags[index] = entity;
        }

        public void Delete(int index)
        {
            FakeDBContext.Tags.RemoveAt(index);
        }

        public Tag FindByName(string name)
        {
            return FakeDBContext.Tags.FirstOrDefault(x=>x.Name == name);
        }
        
        public List<Tag> FindMany(Expression<Func<Tag, bool>> filter = null)
        {
            if ( filter!= null )
            {
                return FakeDBContext.Tags.Where(filter.Compile()).ToList();
            }

            return FakeDBContext.Tags;
        }
        
        public Tag FindOne(Expression<Func<Tag, bool>> filter = null)
        {
            if (filter != null)
            {
                return FakeDBContext.Tags.FirstOrDefault(filter.Compile());
            }

            return FakeDBContext.Tags.First();
        }
        
        public List<Tag> GetAll()
        {
            return FakeDBContext.Tags;
        }
    }
}
