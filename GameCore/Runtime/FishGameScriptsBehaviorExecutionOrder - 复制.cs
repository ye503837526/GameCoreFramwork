using System;
using GameCore.FishGame;
namespace GameCore
{
    public class FishGameScriptsBehaviorExecutionOrder:IBehaviorExecution
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