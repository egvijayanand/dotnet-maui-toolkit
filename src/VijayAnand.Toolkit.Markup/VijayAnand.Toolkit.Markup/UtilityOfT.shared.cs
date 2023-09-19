using System.Linq.Expressions;
using System.Reflection;

namespace VijayAnand.Toolkit.Markup
{
    public static class Utility<TSource>
    {
        public static string PropertyName<TProperty>(Expression<Func<TSource, TProperty>> expression)
        {
            MemberExpression? memExp;

            if (expression.Body is UnaryExpression unExp)
            {
                if (unExp.NodeType == ExpressionType.Convert)
                {
                    memExp = (MemberExpression)unExp.Operand;
                    return memExp.Member.Name;
                }
            }

            memExp = (MemberExpression)expression.Body;
            var propMemExp = memExp;

            string path = string.Empty;

            while (memExp is not null && memExp.Expression.NodeType == ExpressionType.MemberAccess)
            {
                var propInfo = memExp.Expression.GetType().GetProperty("Member");
                var propValue = propInfo?.GetValue(memExp.Expression, null) as PropertyInfo;
                path = $"{propValue?.Name}.{path}";

                memExp = memExp.Expression as MemberExpression;
            }

            return path + propMemExp.Member.Name;
        }
    }
}
