using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL.Managers.Interfaces;
using BLL.Repositories.Classes;
using BLL.Repositories.Interfaces;
using Domain.Models;

namespace BLL.Services.Classes
{
    public class ComicsService : IComicsService
    {
        private readonly IComicsRepository _comicsRepository;

        public ComicsService()
        {
            _comicsRepository = new ComicsRepository();
        }
        
        public void AddComics(Comics comics)
        {
            _comicsRepository.Add(comics);
        }

        public void EditComics(int comicsIndex, Comics comics)
        {
            _comicsRepository.Edit(comicsIndex, comics);
        }

        public void DeleteComics(int comicsIndex)
        {
            _comicsRepository.Delete(comicsIndex);
        }

        public Comics GetComicsByName(string name)
        {
            return _comicsRepository.FindByName(name);
        }

        public List<Comics> FindManyComicses(Expression<Func<Comics, bool>> filter = null)
        {
            return _comicsRepository.FindMany(filter);
        }

        public Comics FindOneComics(Expression<Func<Comics, bool>> filter = null)
        {
            return _comicsRepository.FindOne(filter);
        }

        public List<Comics> GetAllComicses()
        {
            return _comicsRepository.GetAll();
        }
    }
}