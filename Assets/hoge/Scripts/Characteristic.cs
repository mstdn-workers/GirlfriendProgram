/// <summary>
/// 特性クラス
/// ghostで使用
/// 例）飢餓：性愛：探求
/// </summary>
public class Characteristic
{
    public int keyNum { protected internal set; get; }
    public string name { protected internal set; get; }
    public int minNum { protected internal set; get; }
    public int maxNum { protected internal set; get; }
    public int point { protected internal set; get; }
    public string description { protected internal set; get; }
}

/// <summary>
/// 精神的特徴
/// shellで使用
/// 例）几帳面：真面目：ドジっ子
/// </summary>
public class skill : Characteristic
{

}

/// <summary>
/// 肉体的特徴
/// 実体で使用
/// 例）強度：知識：性豪
/// </summary>
public class technic : Characteristic
{

}

/// <summary>
/// shell上の情報設定
/// </summary>
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