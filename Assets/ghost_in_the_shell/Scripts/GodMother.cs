using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

/// <summary>
/// 管理クラス
/// 彼女の作成とデータの管理を行う
/// </summary>
public class GodMother : MonoBehaviour {

    public int createNum;
    public GameObject obj;
    
    static List<Characteristic> CharacteristicData;
    static List<skill> skillData;
    static List<technic> technicData;
    static List<status> statusData;

    private void Awake()
    {
        dataLoad();
    }

    // Use this for initialization
    void Start () {
        
        for(int i = 0; i < createNum; i++)
        {
            Instantiate(obj);
        }
	}

    void dataLoad()
    {
        //別メソッドにして対応予定
        CSVManeger csv = new CSVManeger();
        setCharacteristicData(csv.readCSV("CharacteristicData"));
        setSkillData(csv.readCSV("skillData"));
        setTechnicData(csv.readCSV("technicData"));
        setStatusData(csv.readCSV("statusData"));
    }
    #region データの設定
    void setCharacteristicData(List<string[]> textData)
    {
        string[] data;
        Characteristic setData;
        for (int i = 1; i < textData.Count; i++)
        {
            data = textData[i];
            setData = new Characteristic();

            setData.keyNum = int.Parse(data[0]);
            setData.name = data[1];
            setData.minNum = int.Parse(data[2]);
            setData.maxNum = int.Parse(data[3]);
            setData.point = int.Parse(data[4]);
            setData.description = data[5];
            CharacteristicData.Add(setData);

        }
    }
    void setSkillData(List<string[]> textData)
    {
        string[] data;
        skill setData;
        for (int i = 1; i < textData.Count; i++)
        {
            data = textData[i];
            setData = new skill();

            setData.keyNum = int.Parse(data[0]);
            setData.name = data[1];
            setData.minNum = int.Parse(data[2]);
            setData.maxNum = int.Parse(data[3]);
            setData.point = int.Parse(data[4]);
            setData.description = data[5];
            skillData.Add(setData);
        }
    }
    void setTechnicData(List<string[]> textData)
    {
        string[] data;
        technic setData;
        for (int i = 1; i < textData.Count; i++)
        {
            data = textData[i];
            setData = new technic();

            setData.keyNum = int.Parse(data[0]);
            setData.name = data[1];
            setData.minNum = int.Parse(data[2]);
            setData.maxNum = int.Parse(data[3]);
            setData.point = int.Parse(data[4]);
            setData.description = data[5];
            technicData.Add(setData);
        }
    }
    void setStatusData(List<string[]> textData)
    {
        string[] data;
        status setData;
        for (int i = 1; i < textData.Count; i++)
        {
            data = textData[i];
            setData = new status();

            setData.keyNum = int.Parse(data[0]);
            setData.basicName = data[1];
            setData.life = int.Parse(data[2]);
            setData.lifeRisingValue = int.Parse(data[3]);
            setData.lifeDecreaseValue = int.Parse(data[4]);
            setData.mind = int.Parse(data[5]);
            setData.mindRisingValue = int.Parse(data[6]);
            setData.mindDecreaseValue = int.Parse(data[7]);
            statusData.Add(setData);
        }
    }
    #endregion

    // Update is called once per frame
    void Update () {
		
	}
}

public class CSVManeger
{
    public List<string[]> readCSV(string dataName)
    {
        Debug.Log(dataName);
        List<string[]> csvData = new List<string[]>();
        try
        {
            TextAsset csv = Resources.Load(dataName) as TextAsset;
            StringReader reader = new StringReader(csv.text);
            while (reader.Peek() > -1)
            {
                string line = reader.ReadLine();
                csvData.Add(line.Split(',')); // リストに入れる
            }
        }
        catch (NullReferenceException)
        {
            
        }
        
        
        return csvData;
    }
}
