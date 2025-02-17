﻿using AlliantProductManagementServer.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantProductManagementServer.Domain.Repositories.Core
{
    public interface IRepository<T> where T : CoreEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllPaginatedAsync(int page, int limit);
        Task<int> CountAsync();
        Task<T> AddAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<int> DeleteAsync(int Id);
    }
}
