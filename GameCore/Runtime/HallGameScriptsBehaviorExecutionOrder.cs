using System;
namespace GameCore
{
    public class HallGameScriptsBehaviorExecutionOrder:IBehaviorExecution
    {
        public static Type[] LogicBehaviorExecutions = new Type[] {
 
        };

        public static Type[] DataBehaviorExecutions = new Type[] {
  
        };

        public static Type[] MsgBehaviorExecutions = new Type[] {
 
        };

        public Type[] GetDataBehaviorExecutions()
        {
            return DataBehaviorExecutions;
        }

        public Type[] GetLogicBehaviorExecutions()
        {
            return LogicBehaviorExecutions;
        }

        public Type[] GetMsgBehaviorExecutions()
        {
            return MsgBehaviorExecutions;
        }
    }

}