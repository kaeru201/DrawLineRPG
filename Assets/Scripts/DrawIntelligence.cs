using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections;


//線を描くための情報を持っておくスクリプト
//DrawLinePlaseにアタッチしておく
public class DrawIntelligence : MonoBehaviour
{


    [SerializeField] BattleSystem battleSystem;

    [SerializeField] DrawLine player1Point;
    [SerializeField] DrawLine player2Point;
    [SerializeField] DrawLine player3Point;

    //持っているスキルの情報を一旦保存しておく配列変数  
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


    }

    public void DrawIn(int pUnit)//引数にどのプレイヤーに対してか
    {
        //Unitがplayer1なら
        if (pUnit == 1)
        {
            PlayerPointON(player1Point);//プレイヤー1の線を引くスクリプトをつける

            WhoClick(player1Point, player1SkillType, player1Power, player1PenetionPower);//プレイヤー1が何のスキルを打ったか

            StartCoroutine(PlayerPointOFF(player1Point));//プレイヤー1のスクリプトを消す
        }
        //Unitがplayer2なら
        if (pUnit == 2)
        {
            PlayerPointON(player2Point);//プレイヤー2の線を引くスクリプトをつける

            WhoClick(player2Point, player2SkillType, player2Power, player2PenetionPower);//プレイヤー2が何のスキルを打ったか

            StartCoroutine(PlayerPointOFF(player2Point));//プレイヤー2のスクリプトを消す
        }
        //Unitがplayer3なら
        if (pUnit == 3)
        {
            PlayerPointON(player3Point);//プレイヤー3の線を引くスクリプトをつける

            WhoClick(player3Point, player3SkillType, player3Power, player3PenetionPower);//プレイヤー3が何のスキルを打ったか

            StartCoroutine(PlayerPointOFF(player3Point));//プレイヤー3のスクリプトを消す
        }



        else return;

    }

    //どのスキルをクリックしたか
    void WhoClick(DrawLine pPoint, SkillType pSkillType, int pPower, int pPenetion)
    {
        //クリックされたら対応する識別番号の変数を代入する
        switch (Number)
        {
            case 0:
                return;
            //スキルの情報
            case 1:
                pPoint.MaxLineRange = SkillRanges[0];
                pSkillType = SkillTypes[0];
                pPower = SkillPowers[0];
                pPenetion = SkillPenetionPowers[0];

                break;
            case 2:
                //
                pPoint.MaxLineRange = SkillRanges[1];
                pSkillType = SkillTypes[1];
                pPower = SkillPowers[1];
                pPenetion = SkillPenetionPowers[1];

                break;
            case 3:
                //
                pPoint.MaxLineRange = SkillRanges[2];
                pSkillType = SkillTypes[2];
                pPower = SkillPowers[2];
                pPenetion = SkillPenetionPowers[2];

                break;
            case 4:
                // 
                pPoint.MaxLineRange = SkillRanges[3];
                pSkillType = SkillTypes[3];
                pPower = SkillPowers[3];
                pPenetion = SkillPenetionPowers[4];

                break;
            case 5:
                //
                pPoint.MaxLineRange = SkillRanges[4];
                pSkillType = SkillTypes[4];
                pPower = SkillPowers[4];
                pPenetion = SkillPenetionPowers[4];

                break;
            case 6:

                pPoint.MaxLineRange = SkillRanges[5];
                pSkillType = SkillTypes[5];
                pPower = SkillPowers[5];
                pPenetion = SkillPenetionPowers[5];

                break;

        }
    }

    //対応したUnitの線を書き始めるスクリプトをONにするメソッド
    void PlayerPointON(DrawLine pPoint)
    {
        pPoint.enabled = true;

    }

    //対応したUnitの線を書くスクリプトをOFFにするメソッド
    IEnumerator PlayerPointOFF(DrawLine pPoint)
    {
        yield return new WaitUntil(() => battleSystem.Next == true);//書き終わるまで待つ
        pPoint.enabled = false;
        battleSystem.Next = false;
        yield break;
    }

}
