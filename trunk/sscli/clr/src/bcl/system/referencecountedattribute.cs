using System;

namespace System
{
    /// <summary>
    /// An attribute that indicates to the runtime that the applied-to type
    /// should be handled by reference counting, not M&S garbage collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited=true)]
    public class ReferenceCountedAttribute : Attribute
    {
        public ReferenceCountedAttribute()
        {            
        }
    }
}
