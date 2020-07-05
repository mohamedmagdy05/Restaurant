using System;
using System.Collections.Generic;
using System.Text;

namespace Safcsp.Restaurant.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class OperationOrderAttribute : Attribute
    {
        public int Order { get; }

        public OperationOrderAttribute(int order)
        {
            this.Order = order;
        }
    }
}
