using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections;


//線を描くための情報を持っておき、描く命令をするスクリプト
//DrawLinePlaseにアタッチしておく
public class DrawIntelligence : MonoBehaviour
{
    [SerializeField] GameObject selectAction;

    [SerializeField] BattleSystem battleSystem;

    [SerializeField] DrawLine player1Point;
    [SerializeField] DrawLine player2Point;
    [SerializeField] DrawLine player3Point;

    //持っているスキルの情報を一旦保存しておく配列変数  SkillSelection.csで値を代入
    string[] skillNames = new string[6];
    int[] skillRanges = new int[6];
    string[] skillDescriptions = new string[6];
    SkillType[] skillTypes = new SkillType[6];
    int[] skillPowers = new int[6];
    int[] skillPenetionPowers = new int[6];
    int[] skillSpeed = new int[6];
    int[] skillNumAttacks = new int[6];

    int number = 0;//どのスキルを打ったか識別する変数　　

    //打つスキルの情報を覚えておく変数 (InstanceBallに渡してBallに反映させる)
    // 0:player1、1:player2、2:player3
    public string[] playerSkillNames = new string[3];
    public SkillType[] playerSkillTypes = new SkillType[3];
    public int[] playerPowers = new int[3];
    public int[] playerPenetionPowers = new int[3];
    public float[] playerSpeeds = new float[3];
    public int[] playerNumAttacks = new int[3];

    public string[] enemySkillNames = new string[3];
    public SkillType[] enemySkillTypes = new SkillType[3];
    public int[] enemyPowers = new int[3];
    public int[] enemyPenetionPowers = new int[3];
    public int[] enemySpeeds = new int[3];
    public int[] enemyNumAttacks = new int[3];



    public string[] SkillNames { get => skillNames; set => skillNames = value; }
    public int Number { get => number; set => number = value; }
    public int[] SkillRanges { get => skillRanges; set => skillRanges = value; }
    public string[] SkillDescriptions { get => skillDescriptions; set => skillDescriptions = value; }
    public int[] SkillPowers { get => skillPowers; set => skillPowers = value; }
    public int[] SkillPenetionPowers { get => skillPenetionPowers; set => skillPenetionPowers = value; }
    public SkillType[] SkillTypes { get => skillTypes; set => skillTypes = value; }
    public int[] SkillSpeed { get => skillSpeed; set => skillSpeed = value; }
    public int[] SkillNumAttacks { get => skillNumAttacks; set => skillNumAttacks = value; }


    //線を描くメソッド
    public void DrawIn(int pUnit)//引数にどのプレイヤーに対してか
    {
        //Unitがplayer1なら
        if (pUnit == 1)
        {
            PlayerPointON(player1Point);//プレイヤー1の線を引くスクリプトをつける

            WhoClick(ref playerSkillNames[0],player1Point, ref playerSkillTypes[0], ref playerPowers[0], ref playerPenetionPowers[0], ref playerSpeeds[0], ref playerNumAttacks[0]);//プレイヤー1が何のスキルを打ったか

            StartCoroutine(PlayerPointOFF(player1Point));//プレイヤー1のスクリプトを消す
        }
        //Unitがplayer2なら
        if (pUnit == 2)
        {
            PlayerPointON(player2Point);//プレイヤー2の線を引くスクリプトをつける

            WhoClick(ref playerSkillNames[1],player2Point, ref playerSkillTypes[1], ref playerPowers[1], ref playerPenetionPowers[1], ref playerSpeeds[1], ref playerNumAttacks[1]);//プレイヤー2が何のスキルを打ったか

            StartCoroutine(PlayerPointOFF(player2Point));//プレイヤー2のスクリプトを消す
        }
        //Unitがplayer3なら
        if (pUnit == 3)
        {
            PlayerPointON(player3Point);//プレイヤー3の線を引くスクリプトをつける

            WhoClick(ref playerSkillNames[2], player3Point, ref playerSkillTypes[2], ref playerPowers[2], ref playerPenetionPowers[2], ref playerSpeeds[2], ref playerNumAttacks[2]);//プレイヤー3が何のスキルを打ったか

            StartCoroutine(PlayerPointOFF(player3Point));//プレイヤー3のスクリプトを消す
        }



        else return;

    }

    //どのスキルをクリックしたか
    void WhoClick(ref string pSkillName, DrawLine pPoint, ref SkillType pSkillType, ref int pPower, ref int pPenetion, ref float pSpeed, ref int pNumATK)
    {
        //クリックされたら対応する識別番号の変数を代入する
        switch (Number)
        {
            case 0:
                return;
            //スキルの情報
            case 1:
                pSkillName = SkillNames[0];
                pPoint.MaxLineRange = SkillRanges[0];//距離
                pSkillType = SkillTypes[0];//スキルタイプ
                pPower = SkillPowers[0];//攻撃力
                pPenetion = SkillPenetionPowers[0];//貫通力
                pSpeed = skillSpeed[0];//速度
                pNumATK = skillNumAttacks[0];//攻撃回数

                break;
            case 2:
                pSkillName = SkillNames[1];
                pPoint.MaxLineRange = SkillRanges[1];
                pSkillType = SkillTypes[1];
                pPower = SkillPowers[1];
                pPenetion = SkillPenetionPowers[1];
                pSpeed = skillSpeed[1];
                pNumATK = skillNumAttacks[1];

                break;
            case 3:
                pSkillName= SkillNames[2];
                pPoint.MaxLineRange = SkillRanges[2];
                pSkillType = SkillTypes[2];
                pPower = SkillPowers[2];
                pPenetion = SkillPenetionPowers[2];
                pSpeed = skillSpeed[2];
                pNumATK = skillNumAttacks[2];

                break;
            case 4:
                pSkillName = skillNames[3];
                pPoint.MaxLineRange = SkillRanges[3];
                pSkillType = SkillTypes[3];
                pPower = SkillPowers[3];
                pPenetion = SkillPenetionPowers[3];
                pSpeed = skillSpeed[3];
                pNumATK = skillNumAttacks[3];

                break;
            case 5:
                pSkillName = SkillNames[4];
                pPoint.MaxLineRange = SkillRanges[4];
                pSkillType = SkillTypes[4];
                pPower = SkillPowers[4];
                pPenetion = SkillPenetionPowers[4];
                pSpeed = skillSpeed[4];
                pNumATK = skillNumAttacks[4];

                break;
            case 6:
                pSkillName = SkillNames[5];
                pPoint.MaxLineRange = SkillRanges[5];
                pSkillType = SkillTypes[5];
                pPower = SkillPowers[5];
                pPenetion = SkillPenetionPowers[5];
                pSpeed = skillSpeed[5];
                pNumATK = skillNumAttacks[5];

                break;

        }
    }

    //対応したUnitの線を書き始めるスクリプトをONにするメソッド
    void PlayerPointON(DrawLine pPoint)
    {
        pPoint.Draw = true;


    }

    //対応したUnitの線を書くスクリプトをOFFにするメソッド
    IEnumerator PlayerPointOFF(DrawLine pPoint)
    {
        yield return new WaitUntil(() => battleSystem.next == true);//描き終わるまで待つ
        pPoint.Draw = false;//描いたPointのDrawスクリプトを停止
        yield return new WaitForSeconds(0.1f);//一瞬待ってから
        battleSystem.next = false;//描き終わるフラグをリセット
        yield break;
    }

}
