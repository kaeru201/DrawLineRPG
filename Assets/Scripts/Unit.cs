using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Unit
{
    //実際にゲームで使うUnitのデータ

    //PlayerHudの時にunitBaseからUnitを参照するためにpublic (プロバティ)
    [SerializeField] public UnitBase unitBase {get;set;}
    public int level { get; set; }

    public int hp { get; set; }
    //使える技
    public List<Move> Moves { get; set; }

    //生成時の初期設定
    public Unit(UnitBase uBase, int uLevel)
    {
        unitBase = uBase;
        level = uLevel;
        hp = MaxHP;

        Moves = new List<Move>();
        //覚える技のレベル以上なら、Movesに追加
        foreach (LearnableMove learnableMove in uBase.Learnablemoves)
        {
            if(level >= learnableMove.Level)
            {
                //技を覚える
                Moves.Add(new Move(learnableMove.MoveBase));
            }

        }

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
