using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace GameCore
{
    public class TypeManager
    {
        public static IBehaviorExecution BehaviorExecution;
        public static void InitliztionWorldAssetbly(World world,IBehaviorExecution behaviorExecution)
        {
            BehaviorExecution = behaviorExecution;
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Assembly worldAssembly = null;
            foreach (var assembly in assemblies)
            {
                if (assembly.GetName().Name == "GameCore")
                {
                    worldAssembly = assembly;
                    break;
                }
            }
            if (worldAssembly == null)
            {
                UnityEngine.Debug.LogError("worldAssembly is Nunn Check Have Create Assemblies");
                return;
            }
            UnityEngine.Debug.LogError("world.GetType().Namespace>>>>>>>>>>" + world.GetType().Namespace);
            string Namespace = world.GetType().Namespace;
            Type logicType = typeof(ILogicBehaviour);
            Type dataType = typeof(IDataBehaviour);
            Type msgType = typeof(IMsgBehaviour);

            List<TypeOrder> logicBehaviourlsit = new List<TypeOrder>();
            List<TypeOrder> dataBehaviourlsit = new List<TypeOrder>();
            List<TypeOrder> msgBehaviourlsit = new List<TypeOrder>();
            Type[] types = worldAssembly.GetTypes();
            foreach (var type in types)
            {
                string space = type.Namespace;
                //Attribute attribute = type.GetCustomAttribute(typeof(LogicBehaviorBeforAttribute));
                if (!string.Equals(type.Namespace, Namespace))
                {
                    continue;
                }
                if (type.IsAbstract)
                {
                    continue;
                }
                if (logicType.IsAssignableFrom(type))
                {
                    int order = GetLogicBehaviourOrderIndex(type);
                    logicBehaviourlsit.Add(new TypeOrder(order, type));
                }
                else if (dataType.IsAssignableFrom(type))
                {
                    int order = GetDataBehaviourOrderIndex(type);
                    dataBehaviourlsit.Add(new TypeOrder(order, type));
                }
                else if (msgType.IsAssignableFrom(type))
                {
                    int order = GetMsgBehaviourOrderIndex(type);
                    msgBehaviourlsit.Add(new TypeOrder(order, type));
                }
            }

            logicBehaviourlsit.Sort((a, b) => a.Order.CompareTo(b.Order));
            dataBehaviourlsit.Sort((a, b) => a.Order.CompareTo(b.Order));
            msgBehaviourlsit.Sort((a, b) => a.Order.CompareTo(b.Order));

            for (int i = 0; i < dataBehaviourlsit.Count; i++)
            {
                world.AddDataMgr(Activator.CreateInstance(dataBehaviourlsit[i].Type) as IDataBehaviour);
            }
            for (int i = 0; i < msgBehaviourlsit.Count; i++)
            {
                world.AddMsgConter(Activator.CreateInstance(msgBehaviourlsit[i].Type) as IMsgBehaviour);
            }
            for (int i = 0; i < logicBehaviourlsit.Count; i++)
            {
                world.AddLogicCtrl(Activator.CreateInstance(logicBehaviourlsit[i].Type) as ILogicBehaviour);
            }

            logicBehaviourlsit.Clear();
            dataBehaviourlsit.Clear();
            msgBehaviourlsit.Clear();
            logicBehaviourlsit = null;
            dataBehaviourlsit = null;
            msgBehaviourlsit = null;
        }

        public static int GetLogicBehaviourOrderIndex(Type logicType)
        {
            Type[] logicTypes = BehaviorExecution.GetLogicBehaviorExecutions();
            for (int i = 0; i < logicTypes.Length; i++)
            {
                if (logicTypes[i] == logicType)
                    return i;
            }
            return 999;
        }
        public static int GetDataBehaviourOrderIndex(Type dataType)
        {
            Type[] dataTypes = BehaviorExecution.GetDataBehaviorExecutions();
            for (int i = 0; i < dataTypes.Length; i++)
            {
                if (dataTypes[i] == dataType)
                    return i;
            }
            return 999;
        }
        public static int GetMsgBehaviourOrderIndex(Type msgType)
        {
            Type[] msgTypes = BehaviorExecution.GetMsgBehaviorExecutions();
            for (int i = 0; i < msgTypes.Length; i++)
            {
                if (msgTypes[i] == msgType)
                    return i;
            }
            return 999;
        }
    }
}
