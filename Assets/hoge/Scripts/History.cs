using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History {

    public int keyNum { private set; get; }
    public int minNum { private set; get; }
    public int maxNum { private set; get; }
    public List<int> permission { private set; get; }

    //5wによる来歴
    private class record
    {
        public int turningPoint { set; get; }
        public string location { set; get; }
        public string somebody { set; get; }
        public string something { set; get; }
        public string action { set; get; }
    }

    protected void create()
    {

    }

}
