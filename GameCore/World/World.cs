using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameCore
{
    public  class World
    {
        private static UIManager mUimanager;
        public readonly static UIManager UIManager;
        public static World mWorld => WorldManager.DefaultGameWorld;
        private List<ILogicBehaviour> mLogicBehavioursList=new List<ILogicBehaviour>();
        private List<IDataBehaviour> mDataBehavioursList = new List<IDataBehaviour>();
        private List<IMsgBehaviour> mMsgBehavioursList = new List<IMsgBehaviour>();

        public virtual void OnCreate() { }
        public virtual void OnUpdate() { }
        public virtual void OnDestroy() { }

        public static T GetExistLogicMgr<T>() where T : ILogicBehaviour
        {
            for (int i = 0; i < mWorld.mLogicBehavioursList.Count; i++)
            {
                if (Type.Equals(mWorld.mLogicBehavioursList[i], typeof(T)))
                {
                    return  (T)mWorld.mLogicBehavioursList[i] ;
                }
            }
            Debug.LogError(typeof(T).Name+ "Not existent Plase Check Param is Error!");
            return default(T);
        }
        public static T GetExitsDataCtrl<T>() where T : IDataBehaviour  
        {
            for (int i = 0; i < mWorld.mLogicBehavioursList.Count; i++)
            {
                if (Type.Equals(mWorld.mLogicBehavioursList[i], typeof(T)))
                {
                    return (T)mWorld.mLogicBehavioursList[i];
                }
            }
            Debug.LogError(typeof(T).Name + "Not existent Plase Check Param is Error!");
            return default(T);
        }
        public static T GetExitsNet<T>() where T : IMsgBehaviour 
        {
            for (int i = 0; i < mWorld.mLogicBehavioursList.Count; i++)
            {
                if (Type.Equals(mWorld.mLogicBehavioursList[i], typeof(T)))
                {
                    return (T)mWorld.mLogicBehavioursList[i];
                }
            }
            Debug.LogError(typeof(T).Name + "Not existent Plase Check Param is Error!");
            return default(T);
        }
 
        public void AddLogicMgr(ILogicBehaviour logicBehaviour)
        {
            mWorld. mLogicBehavioursList.Add(logicBehaviour);
            logicBehaviour.OnCreate();
        }

        public void AddDataMgr(IDataBehaviour dataBehaviour)
        {
            mWorld.mDataBehavioursList.Add(dataBehaviour);
            dataBehaviour.OnCreate();
        }

        public void AddMsgCtrl(IMsgBehaviour msgBehaviour)
        {
            mWorld.mMsgBehavioursList.Add(msgBehaviour);
            msgBehaviour.OnCreate();
        }

    }
}