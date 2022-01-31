using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Models;

namespace BLL.Managers.Interfaces
{
    public interface ITagService
    {
        void AddTag(Tag tag);

        void EditTag(int tagIndex, Tag tag);

        void DeleteTag(int tagIndex);

        Tag GetTagByName(string name);

        List<Tag> FindManyTags(Expression<Func<Tag, bool>> filter = null);
        
        Tag FindOneTag(Expression<Func<Tag, bool>> filter = null);
        
        List<Tag> GetAllTags();

    }
}
