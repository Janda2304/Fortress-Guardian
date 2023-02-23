using System.Collections;
using System.Collections.Generic;
using FG_Saving;
using UnityEngine;

public class AutoLoad : MonoBehaviour
{
    [SerializeField] private SaveManage _save;
    void Start()
    {
        _save.Load();
    }

}
