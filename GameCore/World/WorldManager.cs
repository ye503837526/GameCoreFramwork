using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameCore
{
    public class WorldManager
    {
        private static List<World> mWorldList { get; set; } = new List<World>();
        public static World DefaultGameWorld { get; private set; }
        public static void CreateWorld<T>() where T : World, new()
        {
            T world = new T();
            DefaultGameWorld = world;
            mWorldList.Add(world);
            world.OnCreate();
            TypeManager.InitliztionWorldAssetbly(world, GetBehaviorExecution());
        }
        public static void DestroyWorld<T>(World world) where T : World
        {
            for (int i = 0; i < mWorldList.Count; i++)
            {
                if (mWorldList[i] == world)
                {
                    mWorldList[i].OnDestroy();
                    mWorldList.Remove(mWorldList[i]);
                }
            }
        }
        public static IBehaviorExecution GetBehaviorExecution()
        {
            if (DefaultGameWorld.GetType().Name == "FishWorld")
            {
                return new FishGameScriptsBehaviorExecutionOrder();
            }
            else if (DefaultGameWorld.GetType().Name=="HallWorld")
            {
                return new HallGameScriptsBehaviorExecutionOrder();
            }
            return null;
        }
    }

    public class UIManager
    {

    }
}