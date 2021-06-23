using System.Collections.Generic;
using UnityEngine;
namespace GameCore
{
    public abstract class World
    {
        private static UIManager mUimanager;
        public readonly static UIManager UIManager;
        public static World mWorld => WorldManager.DefaultGameWorld;
        private List<LogicBehaviour> mLogicBehavioursList = new List<LogicBehaviour>();
        private List<DataBehaviour> mDataBehavioursList = new List<DataBehaviour>();
        private List<MsgBehaviour> mMsgBehavioursList = new List<MsgBehaviour>();


        public virtual void OnCreate() { }
        public virtual void OnUpdate() { }
        public virtual void OnDestroy() { }

        public static T GetExistLogicCtrl<T>() where T : ILogicBehaviour
        {
            for (int i = 0; i < mWorld.mLogicBehavioursList.Count; i++)
            {
                LogicBehaviour logicBehaviour = mWorld.mLogicBehavioursList[i];
                if (string.Equals(logicBehaviour.name, typeof(T).Name))
                {
                    return (T)logicBehaviour.behaviour;
                }
            }
            Debug.LogError(typeof(T).Name + "Not existent Plase Check Param is Error!");
            return default(T);
        }
        public static T GetExitsDataMgr<T>() where T : IDataBehaviour
        {
            for (int i = 0; i < mWorld.mDataBehavioursList.Count; i++)
            {
                DataBehaviour dataBehaviour = mWorld.mDataBehavioursList[i];
                if (string.Equals(dataBehaviour.name, typeof(T).Name))
                {
                    return (T)dataBehaviour.behaviour;
                }
            }
            Debug.LogError(typeof(T).Name + "Not existent Plase Check Param is Error!");
            return default(T);
        }
        public static T GetExitsMsgConter<T>() where T : IMsgBehaviour
        {
            for (int i = 0; i < mWorld.mMsgBehavioursList.Count; i++)
            {
                MsgBehaviour msgBehaviour = mWorld.mMsgBehavioursList[i];
                if (string.Equals(msgBehaviour.name, typeof(T).Name))
                {
                    return (T)msgBehaviour.behaviour;
                }
            }
            Debug.LogError(typeof(T).Name + "Not existent Plase Check Param is Error!");
            return default(T);
        }

        public void AddLogicCtrl(ILogicBehaviour logicBehaviour)
        {
            mWorld.mLogicBehavioursList.Add(new LogicBehaviour { name = logicBehaviour.GetType().Name, behaviour = logicBehaviour });
            logicBehaviour.OnCreate();
        }

        public void AddDataMgr(IDataBehaviour dataBehaviour)
        {
            mWorld.mDataBehavioursList.Add(new DataBehaviour { name = dataBehaviour.GetType().Name, behaviour = dataBehaviour });
            dataBehaviour.OnCreate();
        }

        public void AddMsgConter(IMsgBehaviour msgBehaviour)
        {
            mWorld.mMsgBehavioursList.Add(new MsgBehaviour { name = msgBehaviour.GetType().Name, behaviour = msgBehaviour });
            msgBehaviour.OnCreate();
        }

        //这里没有使用资源存储的原因是：
        //1.字典在IL中性能存在问题
        //2.在帧同步中会造成不同步 原因是字典在不同平台中遍历顺序不一样会导致结果不同
        private class LogicBehaviour
        {
            public string name;
            public ILogicBehaviour behaviour;
        }
        private class DataBehaviour
        {
            public string name;
            public IDataBehaviour behaviour;
        }
        private class MsgBehaviour
        {
            public string name;
            public IMsgBehaviour behaviour;
        }
  
    }
}