using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameCore
{
    public class WorldManager
    {
        private static List<World> mWorldList { get; set; } = new List<World>();
        public static  World DefaultGameWorld { get; private set; }
        public static void CreateWorld<T>() where T : World, new()
        {
            T world = new T();
            world.OnCreate();
            DefaultGameWorld = world;
            mWorldList.Add(world);
            TypeManager.InitliztionWorldAssetbly(world);
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
    }
    public class UIManager
    {

    }
}