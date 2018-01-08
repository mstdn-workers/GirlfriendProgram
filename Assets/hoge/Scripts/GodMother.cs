using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GodMother : MonoBehaviour {

    public int createNum;
    public GameObject obj;
    
    static List<skill> skillData;
    static List<technic> technicData;

    // Use this for initialization
    void Start () {
        //別メソッドにして対応予定
        CSVManeger csv = new CSVManeger();
        setSkillData(csv.readCSV("skillData"));
        setTechnicData(csv.readCSV("technicData"));
        for(int i = 0; i < createNum; i++)
        {
            Instantiate(obj);
        }
	}

    void setSkillData(List<string[]> textData)
    {
        string[] data;
        for (int i = 1; i < textData.Count; i++)
        {
            data = textData[i];

            skill setData = new skill();

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
        for (int i = 1; i < textData.Count; i++)
        {
            data = textData[i];
            technic setData = new technic();
            setData.keyNum = int.Parse(data[0]);
            setData.name = data[1];
            setData.minNum = int.Parse(data[2]);
            setData.maxNum = int.Parse(data[3]);
            setData.point = int.Parse(data[4]);
            setData.description = data[5];
            technicData.Add(setData);
        }
    }

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
