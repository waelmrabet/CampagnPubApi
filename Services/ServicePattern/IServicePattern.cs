using Core.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.ServicePattern
{
    public interface IServicePattern <T> where T: BaseEntity {

        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void InsertAll(IEnumerable<T> ts);
        void UpdateAll(IEnumerable<T> ts);
        void Commit();
        void RollBack();
    }
}
