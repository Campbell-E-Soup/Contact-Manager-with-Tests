﻿using System.Linq.Expressions;

namespace Contact_Manager.Models
{
    public class QueryOptions<T>
    {
        public Expression<Func<T, Object>> OrderBy { get; set; } = null!;
        public Expression<Func<T, bool>> Where { get; set; } = null!;

        private string[] includes = Array.Empty<string>();
        public string Includes
        {
            set => includes = value.Replace(" ", "").Split(',');
        }
        public string[] GetIncludes() => includes;

        public bool HasOrderBy => OrderBy != null;
        public bool HasWhere => Where != null;
    }
}
