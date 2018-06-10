using System;

namespace CsOhm.Attributes
{
    /// <summary>
    /// Represents a a CsOhm model that can be applied to a class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ModelAttribute : Attribute
    {
    }
}
