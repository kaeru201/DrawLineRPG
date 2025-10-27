using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
//レベルに応じたステータスを扱うクラス
public class Unit
{

    //PlayerHudの時にunitBaseからUnitを参照するためにpublic (プロバティ)
    [SerializeField] UnitBase unitBase;
    [SerializeField] int level;

    private int hp;
    private List<Skill> skills;//使える技
    int exp;//経験値

    public UnitBase UnitBase { get => unitBase; }
    public int Level { get => level; set => level = value; }
    public int HP { get => hp; set => hp = value; }
    public List<Skill> Skills { get => skills; set => skills = value; }
    public int Exp { get => exp; set => exp = value; }



    //生成時の初期設定
    public void Init()
    {
        
        HP = MaxHP; 

        Skills = new List<Skill>();


        foreach (LearnableSkill learnableSkill in UnitBase.LearnableSkills)
        {
            if (Level >= learnableSkill.Level)
            {
                Skills.Add(new Skill(learnableSkill.SkillBase));
            }
        }
              

    }

    //レベルアップするかどうか
    public bool LevelUP()
    {
        if (Exp > UnitBase.GetExpForLevel(Level + 1))//もしレベルアップするなら
        {
            Level++;//レベルを+1
            if(Exp >UnitBase.GetExpForLevel(Level+ 1)) Level++;
                               

            return true;
        }

        return false;
    }

    //レベルに応じたステータスを返すプロパティ
    //UnitBaseのプロパティにlevelを掛けて上限の100を割る
    public int MaxHP
    {
        get => Mathf.FloorToInt((UnitBase.MaxHP * Level) / 100f) + 10;
    }
    public int Attack
    {
        get => Mathf.FloorToInt((UnitBase.Attack * Level) / 100f) + 5;
    }
    public int Defense
    {
        get => Mathf.FloorToInt((UnitBase.Defense * Level) / 100f) + 5;
    }


    //public int Speed
    //{
    //    get => Mathf.FloorToInt((UnitBase.Speed * Level) / 100f) + 5;
    //}
}
