using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Helper
{
    public static class IQueryableExtension
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return ExecuteOrderedQueryable(query, "OrderBy", propertyName, comparer);
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return ExecuteOrderedQueryable(query, "OrderByDescending", propertyName, comparer);
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return ExecuteOrderedQueryable(query, "ThenBy", propertyName, comparer);
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return ExecuteOrderedQueryable(query, "ThenByDescending", propertyName, comparer);
        }

        public static IOrderedQueryable<T> ExecuteOrderedQueryable<T>(this IQueryable<T> query, string methodName, string propertyName, IComparer<object> comparer = null)
        {
            var param = Expression.Parameter(typeof(T), "x");

            var body = propertyName.Split('.')
                                   .Aggregate<string, Expression>(param, Expression.PropertyOrField);

            return comparer != null ? (IOrderedQueryable<T>)query.Provider.CreateQuery(Expression.Call(typeof(Queryable),
                                                                                                       methodName,
                                                                                                       new[] { typeof(T), body.Type },
                                                                                                       query.Expression,
                                                                                                       Expression.Lambda(body, param),
                                                                                                       Expression.Constant(comparer)))

                                    : (IOrderedQueryable<T>)query.Provider.CreateQuery(Expression.Call(typeof(Queryable),
                                                                                                       methodName,
                                                                                                       new[] { typeof(T), body.Type },
                                                                                                       query.Expression,
                                                                                                       Expression.Lambda(body, param)));
        }
    }
}
