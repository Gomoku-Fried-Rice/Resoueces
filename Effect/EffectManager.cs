/**************************************************************************************/
/*! @file     EffectManager.cs
***************************************************************************************
* @brief      サウンドを出力するクラス
*********************************************************************************************
* @author     Ryo Sugiyama
*********************************************************************************************
* Copyright © 2018 Ryo Sugiyama All Rights Reserved.
**********************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EffectManager : Singleton<EffectManager>
{
   
	public class EffectClipInfo
	{
		public string effectName;
		public string objectPath;
		public GameObject effectObject;
        
		public EffectClipInfo(string objectPath, string effectName)
		{
			this.effectName = effectName;
			this.objectPath = objectPath;
		}
        
	}
    
	private  Dictionary<string, EffectClipInfo> effectClips = new Dictionary<string, EffectClipInfo>();
   
	private GameObject effectObject;
    
	/// <summary>
    /// 指定エフェクトフェクトデータをコンテナに追加する。
	/// エフェクトデータ(Prefab)はResourcesフォルダ直下においてください。
    /// effectClips.Add("呼び出し時の名前", new EffectClipInfo("サウンドデータのパス", "ヒエラルキーに出る名前"));
    /// </summary>
	public EffectManager()
	{

	}

    /// <summary>
    /// エフェクトの再生
    /// </summary>
    /// <param name="effectName"> エフェクトの名前 </param>
	/// <param name="vector3"> transform.position 等 </param>    
	/// <param name="float"> 消えるまでの時間 </param>
	public void PlayEffect(string effectName, Vector3 vector3, float destroyTime = 3.0f)
	{
    
		if (!effectClips.ContainsKey(effectName))
		{
			Debug.LogError("<color=red>" effectName + "がコンテナの中にありません。パスが間違っているか、呼び出し名が間違っているか確認してください。</color>");
			return;
		} 

		EffectClipInfo effectInfo = effectClips[effectName];

		if(effectInfo.effectObject == null)
		{
			effectInfo.effectObject = (GameObject)Resources.Load(effectInfo.objectPath);
		}


        // destroyTime後に消えるように生成
		Destroy(effectObject =(GameObject)Instantiate(effectInfo.effectObject, vector3, Quaternion.identity), destroyTime);

		effectObject.name = effectClips[effectName].effectName;

	}
}
