using System.Diagnostics.CodeAnalysis;

namespace App.Domain.Context.Attributes;

public class DefaultConstraintAttribute : Attribute
{
    public readonly string Expression;
    
    public DefaultConstraintAttribute([NotNull] string Expression)
    {
        this.Expression = Expression;
    }
}
