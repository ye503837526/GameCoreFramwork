using System;
using GameCore.FishGame;
using UnityEngine.Collections;
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

    public class ScriptsBehaviorExecutionOrder
    {
        public static Type[] LogicBehaviorExecutions = new Type[] {
         typeof(PlayerManager),
         typeof(FishManager),
          typeof(UserManager),
        };

        public static Type[] DataBehaviorExecutions = new Type[] {
        typeof(RoomDataManager),
        typeof(PlayerDataManager),
        };

        public static Type[] MsgBehaviorExecutions = new Type[] {
        typeof(FishMsgManager),
        typeof(WindowMsgManager),
        };
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