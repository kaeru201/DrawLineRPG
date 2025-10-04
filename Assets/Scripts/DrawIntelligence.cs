using UnityEngine;
using System.Collections.Generic;


//線を描くための情報を持っておくスクリプト
//DrawLinePlaseにアタッチしておく
public class DrawIntelligence : MonoBehaviour
{
    //[SerializeField] SkillButton skillButton;

    [SerializeField] DrawLine player1;

    //持っているスキルの情報を一旦保存しておく配列変数  sをつけて
     int[] skillRanges = new int[6];
     string[] skillDescriptions = new string[6];
    SkillType[] skillTypes = new SkillType[6];
    int[] skillPowers = new int[6];
    int[] skillPenetionPowers = new int[6];

    int number = 0;//どのスキルを打ったか識別する変数　　

    //打つスキルの情報を覚えておく変数
    SkillType player1SkillType;
    SkillType player2SkillType;
    SkillType player3SkillType;

    int player1Power;
    int player2Power;
    int player3Power;

    int player1PenetionPower;
    int player2PenetionPower;
    int player3PenetionPower;


    public int Number { get => number; set => number = value; }
    public int[] SkillRanges { get => skillRanges; set => skillRanges = value; }
    public string[] SkillDescriptions { get => skillDescriptions; set => skillDescriptions = value; }
    public int[] SkillPowers { get => skillPowers; set => skillPowers = value; }
    public int[] SkillPenetionPowers { get => skillPenetionPowers; set => skillPenetionPowers = value; }
    internal SkillType[] SkillTypes { get => skillTypes; set => skillTypes = value; }

    void Start()
    {

    }


    void Update()
    {
        //Skill[]の数値はここに置いてといてPlayer1、Player2の変数として代入するのは別の場所の方がいいかも？
        //クリックされたら対応する識別番号の変数を代入する
        switch (Number)
        {
            case 0:
                return;
            //スキルの情報
            case 1:
                //playerPower = SkillPower[0]
                player1.MaxLineRange = SkillRanges[0];
                break;
            case 2:
                //
                player1.MaxLineRange = SkillRanges[1];
                player1SkillType = SkillTypes[1];

                break;
            case 3:
                //
                player1.MaxLineRange = SkillRanges[2];

                break;
            case 4:
                // 
                player1.MaxLineRange = SkillRanges[3];

                break;
            case 5:
                //
                player1.MaxLineRange = SkillRanges[4];

                break;
            case 6:

                player1.MaxLineRange = SkillRanges[5];

                break;

        }

    }
}
