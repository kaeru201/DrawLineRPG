using System.Collections;
using UnityEngine;



public enum BattleState //列挙型の現在どのターンなのか

{
    StartTurn,
    Player1Turn,
    Player2Turn,
    Player3Turn,
    EnemyTimeTurn,　//後で消すかも
    EnemyTurn,
    BattleTurn,
    WinTurn,
    LoseTurn

}

//実際にバトルを進行させるクラス
public class BattleSystem : MonoBehaviour
{




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
    [SerializeField] EnemyDraw[] enemyDraw = new EnemyDraw[3];

    [SerializeField] BattleState currentBState;

    bool next = false;//線を引き終わったかどうか 



    public BattleState CurrentBState { get => currentBState; set => currentBState = value; }
    public bool Next { get => next; set => next = value; }




    //バトルが始まったら
    private void Start()
    {
        CurrentBState = BattleState.StartTurn;

        if (CurrentBState == BattleState.StartTurn)
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
        }

        //もしplayer1が生きているなら
        //if(player1Suveivel)
        //{

        //}

        //いてもいなくても最初はplayer1Turnから
        TurnCng(BattleState.Player1Turn);

    }



    //currentBstateのplayerTurnのどれかに変更するメソッド
    //引数に変える先のBattleStateを入れる
    public void TurnCng(BattleState battleState)
    {
        switch (battleState)
        {
            //引数がplayer1TurnならStateをplayer1Turnにしてplayer1のスキル情報をセットする
            case BattleState.Player1Turn:

                CurrentBState = BattleState.Player1Turn;
                playerSkill.SetSkill(player1Unit.Unit.Skills);
                break;

            //引数がplayer2TurnならStateをplayer2Turnにしてplayer2のスキル情報をセットする
            case BattleState.Player2Turn:

                CurrentBState = BattleState.Player2Turn;
                playerSkill.SetSkill(player2Unit.Unit.Skills);
                break;

            //引数がplayer3TurnならStateをplayer3Turnにしてplayer3のスキル情報をセットする
            case BattleState.Player3Turn:

                CurrentBState = BattleState.Player3Turn;
                playerSkill.SetSkill(player3Unit.Unit.Skills);
                break;

            //引数がEnemyTurnならstateをEnemyTurnに
            case BattleState.EnemyTurn:

                currentBState = BattleState.EnemyTurn;

                break;
            case BattleState.BattleTurn:

                currentBState = BattleState.BattleTurn;
                break;
        }


    }

    //線を描くのを待ってからEnemyターンにするコルーチン　後で消すかも
    IEnumerator WaitEnemyTurn()
    {
        yield return new WaitUntil(() => Next == true);
        TurnCng(BattleState.EnemyTurn);
        for (int i = 0; i < enemyDraw.Length; i++)
        {
            enemyDraw[i].DrawEnemy();
        }
        TurnCng(BattleState.BattleTurn);//うーん、どこでゲームを進行しているのかが分かりにくい
        yield break;
    }

    //一回挟まないと動かなかったから一旦
    private void Update()
    {
        if (currentBState != BattleState.EnemyTimeTurn) return;

        StartCoroutine(WaitEnemyTurn());
    }

}
