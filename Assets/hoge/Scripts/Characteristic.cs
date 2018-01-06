using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

abstract public class Characteristic // Characteristic:性質
{
    public int keyNum { protected internal set; get; }
    public string name { protected internal set; get; }
    public int minNum { protected internal set; get; }
    public int maxNum { protected internal set; get; }
    public int point { protected internal set; get; }
    public string description { protected internal set; get; }
}

/// <summary>
/// 精神的技術
/// </summary>
public class skill : Characteristic
{

}

/// <summary>
/// 肉体的技術
/// </summary>
public class technic : Characteristic
{

}

