using System;

namespace CsOhm.Attributes
{
    /// <summary>
    /// Represents a Field within a CsOhm model that can be applied to a class' property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class FieldAttribute: Attribute
    {
    }
}
