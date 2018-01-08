using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Concept : shell {

	// Use this for initialization
	void Start () {

        string text = null;
        //実体の制御
        if (entity)
        {
            text = "実体があります";
        }
        else
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            text = "実体がありません";
        }

        Debug.Log(text);

	}


    /// <summary>
    /// GameMasterからのデータセット用
    /// </summary>
    /// <param name="skillData"></param>
    private void setSkill(List<skill> skillData)
    {
        int original = getOriginal();
        for (int i = 0; i < skillData.Count; i++)
        {
            if (skillData[i].minNum <= original && skillData[i].maxNum >= original)
            {
                setSkillList(skillData[i]);
            }
        }
    }
    /// <summary>
    /// 修正必須
    /// </summary>
    /// <param name="technicData"></param>
    private void setTechnic(List<technic> technicData)
    {
        int original = getOriginal();
        for (int i = 0; i < technicData.Count; i++)
        {
            if (technicData[i].minNum <= original && technicData[i].maxNum >= original)
            {
                settechnicList(technicData[i]);
            }
        }
    }


    // Update is called once per frame
    void Update () {
		
	}

}

/// <summary>
/// 実体最小分割クラス
/// 継承を前提とする
/// </summary>
abstract public class ghost : MonoBehaviour
{
    [SerializeField]
    private List<skill> skillList;
    private skill getSkillList(int num)
    {
        skill data;
        try
        {
            data = skillList[num];
        }
        catch (IndexOutOfRangeException)
        {
            data = null;
        }

        return data;
    }
    protected internal void setSkillList(skill data)
    {
        skillList.Add(data);
    }

    private int original;
    public int getOriginal()
    {
        return original;
    }

    public ghost()
    {
        //Int32と同じサイズのバイト配列にランダムな値を設定する
        //byte[] bs = new byte[sizeof(int)];
        byte[] bs = new byte[4];
        System.Security.Cryptography.RNGCryptoServiceProvider rng =
            new System.Security.Cryptography.RNGCryptoServiceProvider();
        rng.GetBytes(bs);

        //Int32に変換する
        original = System.BitConverter.ToInt32(bs, 0);
        Debug.Log(original);
    }
}

/// <summary>
/// 実体クラス
/// 側面を生成する
/// </summary>
abstract public class shell : ghost
{
    
    public string basicName { protected internal set; get; }
    //耐久
    public int life { protected internal set; get; }
    public int lifeRisingValue { protected internal set; get; }
    public int lifeDecreaseValue { protected internal set; get; }
    //精神
    public int mind { protected internal set; get; }
    public int mindRisingValue { protected internal set; get; }
    public int mindDecreaseValue { protected internal set; get; }
    //実体
    public bool entity { protected internal set; get; }

    [SerializeField]
    protected List<technic> technicList;
    public technic gettechnicList(int num)
    {
        technic data;
        try
        {
            data = technicList[num];
        }
        catch (IndexOutOfRangeException)
        {
            data = null;
        }

        return data;
    }
    public void settechnicList(technic data)
    {
        technicList.Add(data);
    }

}
