﻿/********************************************************************************************
* @file       Singleton.cs
*********************************************************************************************
* @brief      シングルトン生成用基底クラス
*********************************************************************************************
* @author     Ryo Sugiyama
*********************************************************************************************
* Copyright © 2017 Ryo Sugiyama All Rights Reserved.
*********************************************************************************************/
using System.Collections;
using UnityEngine;

public class Singleton<T> where T : class, new()
{
    static T obj = null;

    Singleton() { }
    
    public static T Instance
    {
        set{ obj = value; }
        get
        {
            // なければ生成
            if (obj == null)
                obj = new T();
            return obj;
        }
    }    
}
