using System.Linq.Expressions;

namespace SportsPro.Models
{
    public class QueryOptions<T>
    {
        public Expression<Func<T, Object>> OrderBy { get; set; }

        public string OrderByDiretion { get; set; } = "asc"; //default  

        public WhereClauses<T> WhereClauses { get; set; }

        public Expression<Func<T, bool>> Where
        {
            set 
            {
                if (WhereClauses == null)
                {
                    WhereClauses = new WhereClauses<T>();
                }

                WhereClauses.Add(value);
            }
        }

        private string[] includes;

        public string Includes
        {
            set => includes = value.Replace(" ", "").Split(',');
        }

        public string[] GetIncludes() => includes ?? new string[0];

        public bool HasWhere => WhereClauses != null;
        public bool HasOrderBy => OrderBy != null;
    }
}
