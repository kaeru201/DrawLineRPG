using UnityEngine;

public class Unit
{
    [SerializeField] UnitBase unitBase;
    int level;

    public Unit(UnitBase uBase, int uLevel)
    {
        unitBase = uBase;
        level = uLevel;
    }

    //レベルに応じたステータスを返すプロパティ
    //UnitBaseのプロパティにlevelを掛けて上限の100を割る　5はよくわからないから消すかも
    public int MaxHP
    {
        get => Mathf.FloorToInt((unitBase.MaxHP * level) / 100f) + 10;
    }
    public int Attack
    {
        get => Mathf.FloorToInt((unitBase.Attack * level) / 100f) + 5;
    }
    public int Defense
    {
        get => Mathf.FloorToInt((unitBase.Defense * level) / 100f) + 5;
    }
    public int Speed
    {
        get => Mathf.FloorToInt((unitBase.Speed * level) / 100f) + 5;
    }

}
