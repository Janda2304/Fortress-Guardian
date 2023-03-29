using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace FG_CustomFunctions
{
    public static class GameObjectC
    {
        public static UnityEngine.GameObject FindObjectByName(string name)
        {
            Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>();
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i].hideFlags == HideFlags.None)
                {
                    if (objs[i].name == name)
                    {
                        return objs[i].gameObject;
                    }
                }
            }
            return null;
        }
        
        public static UnityEngine.GameObject FindObjectByTag(string tag)
        {
    
            Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>();
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i].hideFlags == HideFlags.None)
                {
                    if (objs[i].CompareTag(tag))
                    {
                        return objs[i].gameObject;
                    }
                }
            }
            return null;
        }
        
        public static UnityEngine.GameObject FindObjectByLayer(int layer)
        {
    
            Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>();
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i].hideFlags == HideFlags.None)
                {
                    if (objs[i].gameObject.layer == layer)
                    {
                        return objs[i].gameObject;
                    }
                }
            }
            return null;
        }
    }

}
