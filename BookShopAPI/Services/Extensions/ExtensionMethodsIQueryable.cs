using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using BookShopAPI.Models.Book;

namespace BookShopAPI.Services.Extensions
{
    public static class ExtensionMethodsIQueryable
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string property,
            SortDirection asc = SortDirection.Asc) where T : class
        {
            var searchProperty = typeof(T).GetProperty(property);

            VerifyArgumentException(searchProperty);

            var parameter = Expression.Parameter(typeof(T), "object");
            var selectorExpr = Expression.Lambda(Expression.Property(parameter, property), parameter);

            Expression queryExpr = source.Expression;
            queryExpr = Expression.Call(
                typeof(Queryable),
                asc==SortDirection.Asc ? "OrderBy" : "OrderByDescending",
                new Type[] {
                    source.ElementType,
                    searchProperty.PropertyType },
                queryExpr,
                selectorExpr);

            return source.Provider.CreateQuery<T>(queryExpr);
        }

        private static void VerifyArgumentException(PropertyInfo searchProperty)
        {
            if (searchProperty == null)
                throw new ArgumentException("property");

            if (!searchProperty.PropertyType.IsValueType &&
                !searchProperty.PropertyType.IsPrimitive &&
                !searchProperty.PropertyType.Namespace.StartsWith("System") &&
                !searchProperty.PropertyType.IsEnum)
                throw new ArgumentException("property");

            if (searchProperty.GetMethod == null ||
                !searchProperty.GetMethod.IsPublic)
                throw new ArgumentException("property");
        }
    }
}
