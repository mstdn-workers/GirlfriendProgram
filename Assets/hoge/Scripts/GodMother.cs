using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GodMother : MonoBehaviour {

    List<skill> skillData;
    List<technic> technicData;


    // Use this for initialization
    void Start () {
        //別メソッドにして対応？
        CSVManeger csv = new CSVManeger();
        setSkillData(csv.readCSV("testSkill"));
        setTechnicData(csv.readCSV("testTechnic"));
	}

    void setSkillData(List<string[]> textData)
    {
        string[] data;
        for (int i = 0; i < textData.Count; i++)
        {
            data = textData[i];

            skill setData = new skill();
            setData.keyNum = Convert.ToInt32(data[0]);
            setData.name = data[1];
            setData.minNum = Convert.ToInt32(data[2]);
            setData.maxNum = Convert.ToInt32(data[3]);
            setData.point = Convert.ToInt32(data[4]);
            setData.description = data[5];
            skillData.Add(setData);
        }
    }
    void setTechnicData(List<string[]> textData)
    {
        string[] data;
        for (int i = 0; i < textData.Count; i++)
        {
            data = textData[i];
            technic setData = new technic();
            setData.keyNum = Convert.ToInt32(data[0]);
            setData.name = data[1];
            setData.minNum = Convert.ToInt32(data[2]);
            setData.maxNum = Convert.ToInt32(data[3]);
            setData.point = Convert.ToInt32(data[4]);
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
        List<string[]> csvData = new List<string[]>();
        TextAsset csv = Resources.Load("../Resourse/" + dataName + ".csv") as TextAsset;
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvData.Add(line.Split(',')); // リストに入れる
        }
        return csvData;
    }
}

