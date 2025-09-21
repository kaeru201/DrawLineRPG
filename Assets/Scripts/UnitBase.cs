using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

//データを管理するためにScriptableObject
//Unitの基本的な設定
[CreateAssetMenu]
public class UnitBase : ScriptableObject
{
    //Unitの基本的な情報を入れる変数
    //名前、説明、画像、属性、ステータス

    [SerializeField] new string name; //nameがObject.nameと被るから一応newをつける
    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite sprite;
    [SerializeField] Type type; //列挙Type型のtype変数

    //ステータス (体力、攻撃力、防御力、速さ)
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;

    //覚える技 list
    [SerializeField] List<LearnableMove> learnablemoves;

    //値の取得はしたいけど変更はされないプロパティ
    public string Name { get => name; }
    public string Description { get => description; }
    public Sprite Sprite { get => sprite; }
    public Type Type { get => type; }


    public int MaxHP { get => maxHP; }
    public int Attack { get => attack; }
    public int Defense { get => defense; }
    public int Speed { get => speed; }

    public List<LearnableMove> Learnablemoves { get => learnablemoves; }

}


//列挙型の属性(属性無し、火、水、草、光、闇)
public enum Type
{
    none,
    Fire,
    Water,
    Grass,
    Light,
    Darkness,
}

//どのレベルでどの技を覚えるのか
[Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase MoveBase { get => moveBase; }
    public int Level { get => level; }
}
