﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace BLL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        void Add(T entity);

        void Edit(int index, T entity);

        void Delete(int index);

        List<T> GetAll();

        T FindByName(string name);

        T FindOne(Expression<Func<T, bool>> filter = null);

        List<T> FindMany(Expression<Func<T, bool>> filter = null);
    }
}
