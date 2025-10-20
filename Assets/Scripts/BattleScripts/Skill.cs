using UnityEngine;

public class Skill
{
    //技のマスターデータをもつ

    //Unitから参照するためプロパティ
    SkillBase skillbase;

    public Skill(SkillBase sBase)
    {
        Skillbase = sBase;
    }

    public SkillBase Skillbase { get => skillbase; set => skillbase = value; }
}