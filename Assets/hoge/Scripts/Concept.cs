
using System;
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

    status status = new status();
    protected internal void setStandard(string[] statusData)
    {
        status.keyNum = int.Parse(statusData[0]);
        status.basicName = statusData[1];
        status.life = int.Parse(statusData[2]);
        status.lifeRisingValue = int.Parse(statusData[3]);
        status.lifeDecreaseValue = int.Parse(statusData[4]);
        status.mind = int.Parse(statusData[5]);
        status.mindRisingValue = int.Parse(statusData[6]);
        status.mindDecreaseValue = int.Parse(statusData[7]);
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
    public void settechnicList(technic data)
    {
        technicList.Add(data);
    }

    protected internal void setTechnic(List<technic> technicData)
    {

        for (int i = 0; i < technicData.Count; i++)
        {
            if (technicData[i].minNum <= original && technicData[i].maxNum >= original)
            {
                settechnicList(technicData[i]);
            }
        }
    }
    #endregion
    public shell()
    {
        
    }

}

public class status
{
    public int keyNum { protected internal set; get; }
    public string basicName { protected internal set; get; }
    //耐久
    public int life { protected internal set; get; }
    public int lifeRisingValue { protected internal set; get; }
    public int lifeDecreaseValue { protected internal set; get; }
    //精神
    public int mind { protected internal set; get; }
    public int mindRisingValue { protected internal set; get; }
    public int mindDecreaseValue { protected internal set; get; }
}