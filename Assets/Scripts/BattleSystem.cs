using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

//実際にバトルを進行させるスクリプト
public class BattleSystem : MonoBehaviour
{

    [SerializeField] DrawIntelligence drawIntelligence;
    [SerializeField] DrawLine drawLine;

    //とりあえずインスペクター上でアタッチ
    [SerializeField] BattleUnit player1Unit;
    [SerializeField] BattleUnit player2Unit;
    [SerializeField] BattleUnit player3Unit;
    [SerializeField] BattleUnit enemy1Unit;
    [SerializeField] BattleUnit enemy2Unit;
    [SerializeField] BattleUnit enemy3Unit;


    //とりあえずインスペクター上でアタッチ
    [SerializeField] PlayerHud player1Hud;
    [SerializeField] PlayerHud player2Hud;
    [SerializeField] PlayerHud player3Hud;
    [SerializeField] EnemyHud enemy1Hud;
    [SerializeField] EnemyHud enemy2Hud;
    [SerializeField] EnemyHud enemy3Hud;

    [SerializeField] SkillSelection playerSkill;

    BattleState battleState;


    bool clickSkill = false;//クリックした後か
    bool cliclItem = false;//アイテムをクリックしたかどうか
    [SerializeField] int clickSkillCount;//どのプレイヤーのスキルか



    public bool ClickSkill { get => clickSkill; set => clickSkill = value; }



    //バトルが始まったら
    private void Start()
    {
        player1Unit.SetUp();//モンスターの生成
        player2Unit.SetUp();
        player3Unit.SetUp();
        enemy1Unit.SetUp();
        enemy2Unit.SetUp();
        enemy3Unit.SetUp();


        player1Hud.SetData(player1Unit.Unit);//プレイヤーのHudを出す
        player2Hud.SetData(player2Unit.Unit);
        player3Hud.SetData(player3Unit.Unit);
        enemy1Hud.SetData(enemy1Unit.Unit);
        enemy2Hud.SetData(enemy2Unit.Unit);
        enemy3Hud.SetData(enemy3Unit.Unit);

        playerSkill.SetSkill(player1Unit.Unit.Skills);


        battleState = BattleState.ActionTurn;



    }

    private void Update()
    {
        //もしActionTurnなら
        if (battleState != BattleState.ActionTurn) return;
        
            if (clickSkill)
            {
                StartCoroutine(Draw());
            }
            if (cliclItem)
            {
                //アイテム欄を出す
            }
            else return;
        
    }


    IEnumerator Draw()
    {
        yield return StartCoroutine(Line(1));//プレイヤー1がいるか確かめていたら線を書く
        yield return new WaitUntil(() => drawLine.Next == true);//線を書き終わるまで待機
        drawLine.Next = false;//リセット
        playerSkill.SetSkill(player2Unit.Unit.Skills);//スキル欄をplayer2のものに変化

        yield return StartCoroutine(Line(2));
        yield return new WaitUntil(() => drawLine.Next == true);
        drawLine.Next = false;
        playerSkill.SetSkill(player3Unit.Unit.Skills);

        yield return StartCoroutine(Line(3));
        yield return new WaitUntil(() => drawLine.Next == true);
        drawLine.Next = false;

        //敵の線を引く

        yield break;
    }

    IEnumerator Line(int x)//引数にplayer1、2、3が入るように
    {
        //もしプレイヤー1，2，3がいるなら(メソッドの引数から)
        if ()
        {
            drawIntelligence.DrawIn(x);
            yield break;
        }
        else yield break;
    }

    //private void Update()
    //{

    //    ////UPDetaでやることではないかも
    //    ////やっぱコルーチンか
    //    //if (battleState == BattleState.ActionTurn)
    //    //{

    //    //    //if() もし全員が行動し終わったら
    //    //    //{
    //    //    //敵の行動　Debug.Log("敵の行動)
    //    //    //}

    //    //    //if(player) //行動していない生きているPlayerがいるなら

    //    //    if (clickSkill)
    //    //    {
    //    //        if (clickSkillCount == 0)
    //    //        {
    //    //            drawIntelligence.DrawIn(1);//仮に変数1をplayer1だということにしてplayer1が行動しているとしている
    //    //            clickSkill = false;
    //    //            clickSkillCount += 1;

    //    //            playerSkill.SetSkill(player2Unit.Unit.Skills);//プレイヤー2の情報を
    //    //        }
    //    //        if (clickSkillCount == 1)
    //    //        {
    //    //            drawIntelligence.DrawIn(2);
    //    //            clickSkill = false;
    //    //            clickSkillCount += 1;

    //    //            playerSkill.SetSkill(player3Unit.Unit.Skills);//プレイヤー3の情報を
    //    //        }
    //    //        if (clickSkillCount == 2)
    //    //        {
    //    //            drawIntelligence.DrawIn(3);
    //    //            clickSkill = false;
    //    //            clickSkillCount += 1;
    //    //        }

    //    //}

    //    //if() もしアイテムを押したら
    //    //}
    //    //}


    //}
}
