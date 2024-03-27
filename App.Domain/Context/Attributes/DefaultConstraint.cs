using System.Diagnostics.CodeAnalysis;

namespace App.Domain.Context.Attributes;
/// <summary>
///     Attribute to set default constraints on db columns
/// </summary>
public class DefaultConstraintAttribute : Attribute
{
    /// <summary>
    ///     Expresion string representation for default constraint
    /// </summary>
    public readonly string Expression;
    /// <summary>
    ///     Attribute to set default constraints on db columns
    /// </summary>
    /// <param name="Expression">Expresion string representation for default constraint</param>
    public DefaultConstraintAttribute([NotNull] string Expression)
    {
        this.Expression = Expression;
    }
}
