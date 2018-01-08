using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameMaster : MonoBehaviour {

    public int moveTime;

    Timer timer;
    Charcter charcter;
    private bool moveLock;

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        timer = new Timer();
        charcter = GameObject.FindGameObjectWithTag("Player").GetComponent<Charcter>();
        moveLock = false;

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