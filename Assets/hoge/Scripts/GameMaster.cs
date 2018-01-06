using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameMaster : MonoBehaviour {

    public int moveTime;

    private int date;
    Timer timer;
    Charcter charcter;
    private bool moveLock;

    List<skill> skillData;
    List<technic> technicData;

    private void Awake()
    {
        date = 0;
    }

    // Use this for initialization
    void Start () {
        timer = new Timer();
        charcter = GameObject.FindGameObjectWithTag("Player").GetComponent<Charcter>();
        moveLock = false;

    }
	
    void setCSV(string dataName)
    {
        List<string[]> csvDatas = new List<string[]>();
        TextAsset csv = Resources.Load("../Resourse/"+ dataName +".csv") as TextAsset;
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(',')); // リストに入れる
        }
    }
    void setSkillData(string[] textData)
    {
        skill setData = new skill();
        setData.keyNum  = Convert.ToInt32(textData[0]);
        setData.name    = textData[1];
        setData.minNum  = Convert.ToInt32(textData[2]);
        setData.maxNum  = Convert.ToInt32(textData[3]);
        setData.point   = Convert.ToInt32(textData[4]);
        setData.description = textData[5];
        skillData.Add(setData);
    }
    void setTechnicData(string[] textData)
    {
        technic setData = new technic();
        setData.keyNum = Convert.ToInt32(textData[0]);
        setData.name = textData[1];
        setData.minNum = Convert.ToInt32(textData[2]);
        setData.maxNum = Convert.ToInt32(textData[3]);
        setData.point = Convert.ToInt32(textData[4]);
        setData.description = textData[5];
        technicData.Add(setData);
    }


	// Update is called once per frame
	void Update () {
        timer.CountTime = Time.deltaTime;
        switch((int)timer.CountTime % 60)
        {
            case 3:
                if (moveLock == false)
                {
                    charcter.move();
                    moveLock = true;
                }

                break;

            case 5:
                if (moveLock == true)
                {
                    charcter.attack();
                    moveLock = false;
                }
                
                break;

            case 8:
                timer.reset();
                break;
        }
        /*
        if (moveTime <= (int)timer.CountTime % 60)
        {
            charcter.move();
            timer.reset();
        }
        */
	}

}

public class Timer {

    private float countTime = 0.0f;

    public float CountTime
    {
        get
        {
            return this.countTime;
        }
        set
        {
            this.countTime += value;
            prepareTimer();
        }
    }

    public void reset()
    {
        countTime = 0.0f;
    }

    private void prepareTimer()
    {
        int minute = (int)countTime / 60;
        int second = (int)countTime % 60;
        Debug.Log("Time" +  minute.ToString() + ":" + second.ToString() );
    }

}