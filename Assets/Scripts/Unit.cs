using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

//レベルに応じたステータスを扱うクラス
public class Unit
{

    //PlayerHudの時にunitBaseからUnitを参照するためにpublic (プロバティ)
    [SerializeField] private UnitBase unitBase;
    private int level;

    private int hp;
    //使える技
    private List<Skill> skills;

    public UnitBase UnitBase { get => unitBase; set => unitBase = value; }
    public int Level { get => level; set => level = value; }
    public int Hp { get => hp; set => hp = value; }
    public List<Skill> Skills { get => skills; set => skills = value; }



    //生成時の初期設定
    public Unit(UnitBase uBase, int uLevel)
    {
        UnitBase = uBase;
        Level = uLevel;
        Hp = MaxHP; //参考にした資料だとuBase.MaxHPにしていたよくわからないし、バグってたのでそのままこのクラスのMaxHPを参照している

        Skills = new List<Skill>();


        foreach (LearnableSkill learnableSkill in uBase.LearnableSkills)
        {
            if (Level >= learnableSkill.Level)
            {
                Skills.Add(new Skill(learnableSkill.SkillBase));
            }
        }

    }

    //レベルに応じたステータスを返すプロパティ
    //UnitBaseのプロパティにlevelを掛けて上限の100を割る　5はよくわからないから消すかも
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
