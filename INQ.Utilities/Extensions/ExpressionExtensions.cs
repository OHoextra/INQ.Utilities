using System.Linq.Expressions;
using System.Text;

namespace INQ.Utilities.Extensions;

public static class ExpressionExtensions
{
    public static string PropertyPath(this Expression expression)
    {
        var path = new StringBuilder();
        var memberExpression = expression.ToMemberExpression();
        do
        {
            if (path.Length > 0) path.Insert(0, ".");
            path.Insert(0, memberExpression!.Member.Name);
            memberExpression = memberExpression.Expression?.ToMemberExpression();
        } while (memberExpression != null);

        var pathString = path.ToString();

        return !pathString.Contains('.') // Attempt to exclude the outer-most class instance.
            ? pathString
            : pathString[(pathString.IndexOf(".", StringComparison.Ordinal) + 1) ..];
    }

    public static MemberExpression? ToMemberExpression(this Expression expression)
    {
        switch (expression)
        {
            case MemberExpression memberExpression:
                return memberExpression;

            case LambdaExpression lambdaExpression:
                switch (lambdaExpression.Body)
                {
                    case MemberExpression body:
                        return body;

                    case UnaryExpression unaryExpression:
                        return (MemberExpression)unaryExpression.Operand;
                }
                break;
        }

        return null;
    }
}