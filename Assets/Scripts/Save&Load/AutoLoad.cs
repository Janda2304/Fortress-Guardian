using System.Collections;
using System.Collections.Generic;
using FG_Saving;
using UnityEngine;

public class AutoLoad : MonoBehaviour
{
    [SerializeField] private SaveManage _save;
    public static bool Enabled = true;
    void Start()
    {
        if (AutoLoad.Enabled)
        {
            _save.Load();
        }
    }

}
