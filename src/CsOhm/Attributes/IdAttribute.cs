using System;

namespace CsOhm.Attributes
{
    /// <summary>
    /// Represents an Index within a CsOhm model that can be applied to a class' property. Property must be of type long.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class IdAttribute: Attribute
    {
    }
}
