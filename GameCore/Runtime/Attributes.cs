using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class LogicBehaviorOrderAttribute : Attribute
    {
        public LogicBehaviorOrderAttribute(int order)
        {
            Order = order;
        }
        public int Order { get; }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class DataBehaviorOrderAttribute : Attribute
    {
        public DataBehaviorOrderAttribute(int order)
        {
            Order = order;
        }
        public int Order { get; }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class MsgBehaviorOrderAttribute : Attribute
    {
        public MsgBehaviorOrderAttribute(int order)
        {
            Order = order;
        }
        public int Order { get; }
    }
    public class TypeOrder
    {
        public readonly int Order;
        public readonly Type Type;
        public TypeOrder(int order, Type type)
        {
            Order = order;
            Type = type;
        }
    }
}
