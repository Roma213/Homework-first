using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL.Managers.Interfaces;
using BLL.Repositories.Classes;
using BLL.Repositories.Interfaces;
using Domain.Models;

namespace BLL.Services.Classes
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService()
        {
            _tagRepository = new TagRepository();
        }

        public void AddTag(Tag tag)
        {
            _tagRepository.Add(tag);
        }

        public void EditTag(int tagIndex, Tag tag)
        {
            _tagRepository.Edit(tagIndex, tag);
        }

        public void DeleteTag(int tagIndex)
        {
            _tagRepository.Delete(tagIndex);
        }

        public Tag GetTagByName(string name)
        {
            return _tagRepository.FindByName(name);
        }

        public List<Tag> FindManyTags(Expression<Func<Tag, bool>> filter = null)
        {
            return _tagRepository.FindMany(filter);
        }

        public Tag FindOneTag(Expression<Func<Tag, bool>> filter = null)
        {
            return _tagRepository.FindOne(filter);
        }

        public List<Tag> GetAllTags()
        {
            return _tagRepository.GetAll();
        }
    }
}
