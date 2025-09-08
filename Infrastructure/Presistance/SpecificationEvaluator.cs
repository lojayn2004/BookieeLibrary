
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Presistance
{
    public static class SpecificationEvaluator 
    {
        public static IQueryable<T> CreateQuery<T>(IQueryable<T> inputQuery, Specification<T> specification) 
            where T : class
        {
             if(specification.Criteria is not null) 
                inputQuery = inputQuery.Where(specification.Criteria);

             foreach(var include in specification.Includes)
             {
                inputQuery = inputQuery.Include(include);
             }

             if(specification.OrderBy is not null) 
                inputQuery = inputQuery.OrderBy(specification.OrderBy);
             else if(specification.OrderByDesc is not null) 
                inputQuery = inputQuery.OrderByDescending(specification.OrderByDesc);

             if(specification.IsPaginated)
                inputQuery = inputQuery.Skip(specification.Skip).Take(specification.Take);

             return inputQuery;

        }
    }
}
