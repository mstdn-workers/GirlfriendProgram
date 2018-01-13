using System;
using System.Collections.Generic;
using UnityEngine;

public class Concept : shell {

    // Use this for initialization
    void Start () {

        if (1 <= original)
        {
            entity = true;
        }
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

        
        Debug.Log(text+":"+original);

	}
    // Update is called once per frame
    void Update () {
		
	}

}

/// <summary>
/// 実体最小分割クラス
/// 本質のみを保持
/// </summary>
abstract public class ghost : MonoBehaviour
{
    #region 基本データ設定
    private List<Characteristic> characteristicList;
    protected Characteristic getCharacteristicList(int num)
    {
        Characteristic data;
        try
        {
            data = characteristicList[num];
        }
        catch (IndexOutOfRangeException)
        {
            data = null;
        }

        return data;
    }
    private void setCharacteristicList(Characteristic data)
    {
        characteristicList.Add(data);
    }
    protected internal void setCharacteristic(List<Characteristic> characteristicData)
    {

        for (int i = 0; i < characteristicData.Count; i++)
        {
            if (characteristicData[i].minNum <= original && characteristicData[i].maxNum >= original)
            {
                setCharacteristicList(characteristicData[i]);
            }
        }
    }

    [SerializeField]
    protected internal int original { private set; get; }
    #endregion

    public virtual void Awake()
    {
        original = UnityEngine.Random.Range(-10, 11); //-10~10
    }
}

/// <summary>
/// 外面クラス
/// 本質から枝別れする性質を設定
/// </summary>
abstract public class shell : ghost
{
    #region 基本データ設定
    //実体
    public bool entity { protected internal set; get; }
    private int shellNum { set; get; }

    public status status { private get; set; }
    protected internal void selectStatus(List<status> statusData)
    {
        for (int i = 1;i<statusData.Count;i++)
        {
            if (shellNum == statusData[i].keyNum)
            {
                status = statusData[i];
                break;
            }
        }
    }

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
    private void setTechnicList(technic data)
    {
        technicList.Add(data);
    }

    protected internal void selectTechnic(List<technic> technicData)
    {

        for (int i = 0; i < technicData.Count; i++)
        {
            if (technicData[i].minNum <= original && technicData[i].maxNum >= original)
            {
                setTechnicList(technicData[i]);
            }
        }
    }
    #endregion
    public shell()
    {
        
    }

}

