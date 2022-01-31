using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Models;

namespace BLL.Managers.Interfaces
{
    public interface IComicsService
    {
        void AddComics(Comics comics);

        void EditComics(int comicsIndex, Comics comics);

        void DeleteComics(int comicsIndex);

        Comics GetComicsByName(string name);

        List<Comics> FindManyComicses(Expression<Func<Comics, bool>> filter = null);
        
        Comics FindOneComics(Expression<Func<Comics, bool>> filter = null);
        
        List<Comics> GetAllComicses();
    }
}