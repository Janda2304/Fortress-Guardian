using UnityEngine;

/// <summary>
/// <para>`PlayerPrefs` is a class that stores Player preferences between game sessions. </para>
/// <para> It can store string, float and integer values into the user’s platform registry.</para>
/// <para> It can also store boolean, Vector2, Vector3 and Color values using multiple PlayerPrefs keys.</para>
/// </summary>
public static class PlayerPrefs
{
  
    #region CustomPlayerPrefs

    
    
    #region Boolean
    public static void SetBool(string key, bool value)
    {
            int intValue = value ? 1 : 0;
            PlayerPrefs.SetInt(key, intValue);
    }
    
    public static bool GetBool(string key)
    {
       int intValue = PlayerPrefs.GetInt(key);
       return intValue == 1 ? true : false;
    }
    #endregion Boolean
    
    #region Vector2
    public static void SetVector2(string key, Vector2 value)
    {
        PlayerPrefs.SetFloat(key + "x", value.x);
        PlayerPrefs.SetFloat(key + "y", value.y);
    }

    public static Vector2 GetVector2(string key)
    {
        Vector2 value = new Vector2();
        value.x = PlayerPrefs.GetFloat(key + "x");
        value.y = PlayerPrefs.GetFloat(key + "y");
        return value;
    }
    #endregion Vector2
    
    #region Vector3
    public static void SetVector3(string key, Vector3 value)
    {
        PlayerPrefs.SetFloat(key + "x", value.x);
        PlayerPrefs.SetFloat(key + "y", value.y);
        PlayerPrefs.SetFloat(key + "z", value.z);
    }

    public static Vector3 GetVector3(string key)
    {
        Vector3 value = new Vector3();
        value.x = PlayerPrefs.GetFloat(key + "x");
        value.y = PlayerPrefs.GetFloat(key + "y");
        value.z = PlayerPrefs.GetFloat(key + "z");
        return value;

    }
    #endregion Vector3
    
    #region Color
    public static void SetColor(string key, Color value)
    {
        PlayerPrefs.SetFloat(key + "r", value.r);
        PlayerPrefs.SetFloat(key + "g", value.g);
        PlayerPrefs.SetFloat(key + "b", value.b);
        PlayerPrefs.SetFloat(key + "a", value.a);
    }
    
    public static Color GetColor(string key)
    {
        Color value = new Color();
        value.r = PlayerPrefs.GetFloat(key + "r");
        value.g = PlayerPrefs.GetFloat(key + "g");
        value.b = PlayerPrefs.GetFloat(key + "b");
        value.a = PlayerPrefs.GetFloat(key + "a");
        return value;
    }
    
    #endregion Color
  
   
   
        
        
    #endregion CustomPlayerPrefs
        
    #region Original PlayerPrefs
        public static void SetInt(string key, int value)
        {
            UnityEngine.PlayerPrefs.SetInt(key, value);
        }
        
        public static int GetInt(string key)
        {
            return  UnityEngine.PlayerPrefs.GetInt(key);
        }
        
        public static void SetFloat(string key, float value)
        {
            UnityEngine.PlayerPrefs.SetFloat(key, value);
        }
        
        public static float GetFloat(string key)
        {
            return  UnityEngine.PlayerPrefs.GetFloat(key);
        }
        
        public static void SetString(string key, string value)
        {
            UnityEngine.PlayerPrefs.SetString(key, value);
        }
        
        public static string GetString(string key)
        {
            return UnityEngine.PlayerPrefs.GetString(key);
        }
        
        public static void DeleteKey(string key)
        {
            UnityEngine.PlayerPrefs.DeleteKey(key);
        }
        
        public static void DeleteAll()
        {
            UnityEngine.PlayerPrefs.DeleteAll();
        }
        
        public static bool HasKey(string key)
        {
            return UnityEngine.PlayerPrefs.HasKey(key);
        }
        
        public static void Save()
        {
            UnityEngine.PlayerPrefs.Save();
        }
        
        
        #endregion Original PlayerPrefs
    
    
    
}
