using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public enum BattleState //列挙型の現在どのターンなのか

{
    StartTurn,
    Player1Turn,
    Player2Turn,
    Player3Turn,
    //EnemyTimeTurn,　//後で消すかも
    EnemyTurn,
    BattleTurn,
    WaitNextTurn,
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

    [SerializeField] DrawIntelligence intelligence;
    [SerializeField] SkillSelection playerSkill;
    [SerializeField] EnemyDraw[] enemyDraw = new EnemyDraw[3];
    [SerializeField] GameObject dialogObj;
    public Dialog dialog;

    [SerializeField] public BattleState CurrentBState; //{ get; set; }

    [SerializeField] GameObject player1Point;
    [SerializeField] GameObject player2Point;
    [SerializeField] GameObject player3Point;
    [SerializeField] GameObject enemy1Point;
    [SerializeField] GameObject enemy2Point;
    [SerializeField] GameObject enemy3Point;

    [SerializeField] GameObject selectAction;
    [SerializeField] GameObject readyButton;

    List<GameObject> alivePLayers = new List<GameObject>();　//生き残っているplayerPointを得るリスト
    List<GameObject> aliveEnemies = new List<GameObject>();
    [SerializeField] List<GameObject> aliveBalls = new List<GameObject>();//ballをインスタンス化するたびにリストに追加してボールがまだフィールドにいるか調べるリスト　


    public bool next = false;//線を引き終わったかどうか 
    bool[] just1DeadUnits = new bool[6];//一回だけ死亡判定させる変数(player1=0,player2=1.enemy1=3)


    public bool Player1Alive { get; set; } = false;
    public bool Player2Alive { get; set; } = false;
    public bool Player3Alive { get; set; } = false;

    public bool Enemy1Alive { get; set; } = false;
    public bool Enemy2Alive { get; set; } = false;
    public bool Enemy3Alive { get; set; } = false;



    public List<GameObject> AlivePlayers { get => alivePLayers; set => alivePLayers = value; }
    public List<GameObject> AliveEnemies { get => aliveEnemies; set => aliveEnemies = value; }
    public List<GameObject> AliveBalls { get => aliveBalls; set => aliveBalls = value; }
   




    //バトルが始まったら
    private void Awake()
    {
        CurrentBState = BattleState.StartTurn;

        if (CurrentBState == BattleState.StartTurn)
        {


            if (player1Unit != null)
            {
                player1Unit.SetUp();//Unitの生成
                Player1Alive = true;//Player生存フラグをON
                AlivePlayers.Add(player1Point);//敵の標的になるPointのオブジェクトをリストに
                player1Hud.SetData(player1Unit.Unit);//プレイヤーのHudを出す
            }
            if (player2Unit != null)
            {
                player2Unit.SetUp();
                Player2Alive = true;
                AlivePlayers.Add(player2Point);
                player2Hud.SetData(player2Unit.Unit);
            }
            if (player3Unit != null)
            {
                player3Unit.SetUp();
                Player3Alive = true;
                AlivePlayers.Add(player3Point);
                player3Hud.SetData(player3Unit.Unit);

            }
            if (enemy1Unit != null)
            {
                enemy1Unit.SetUp();
                Enemy1Alive = true;
                AliveEnemies.Add(enemy1Point);
                enemy1Hud.SetData(enemy1Unit.Unit);

            }
            if (enemy2Unit != null)
            {
                enemy2Unit.SetUp();
                Enemy2Alive = true;
                AliveEnemies.Add(enemy2Point);
                enemy2Hud.SetData(enemy2Unit.Unit);
            }
            if (enemy3Unit != null)
            {
                enemy3Unit.SetUp();
                Enemy3Alive = true;
                AliveEnemies.Add(enemy3Point);
                enemy3Hud.SetData(enemy3Unit.Unit);
            }


        }

        //生成したプレイヤーユニットの中で若い数のplayerUnitターンからスタート
        if (Player1Alive) TurnCng(BattleState.Player1Turn);
        else if (Player2Alive) TurnCng(BattleState.Player2Turn);
        else if (Player3Alive) TurnCng(BattleState.Player3Turn);
    }



    private void Update()
    {
        //player1の死亡がまだ行われていないなら
        if (!just1DeadUnits[0])
        { 
            //もしUnitが死んでしまったら
            if (Death(player1Unit))
            {
                Player1Alive = false;//UnitAliveをfalse
                AlivePlayers.Remove(player1Point);//死んだ時にAlivePPointからplayer1のリストを消す
                dialog.AddDialog(player1Unit.Unit.UnitBase.Name + "が戦闘不能");//死亡時アナウンスをダイヤログで流す
                just1DeadUnits[0] = true;
            }
        }
        if(!just1DeadUnits[1])
        {
            if (Death(player2Unit))
            {
                Player2Alive = false;
                AlivePlayers.Remove(player2Point);
                dialog.AddDialog(player2Unit.Unit.UnitBase.Name + "が戦闘不能");
                just1DeadUnits[1] = true;
            }
        }
        if(!just1DeadUnits[2])
        {
            if (Death(player3Unit))
            {
                Player3Alive = false;
                AlivePlayers.Remove(player3Point);
                dialog.AddDialog(player3Unit.Unit.UnitBase.Name + "が戦闘不能");
                just1DeadUnits[2] = true;
            }
        }
       if(!just1DeadUnits[3])
        {
            if (Death(enemy1Unit))
            {
                Enemy1Alive = false;
                AliveEnemies.Remove(enemy1Point);
                dialog.AddDialog(enemy1Unit.Unit.UnitBase.Name + "が戦闘不能");
                just1DeadUnits[3] = true;
            }
        }
        if(!just1DeadUnits[4])
        {
            if (Death(enemy2Unit))
            {
                Enemy2Alive = false;
                AlivePlayers.Remove(enemy2Point);
                dialog.AddDialog(enemy2Unit.Unit.UnitBase.Name + "が戦闘不能");
                just1DeadUnits[4] = true;
            }
        }
        if (!just1DeadUnits[5])
        {
            if (Death(enemy3Unit))
            {
                Enemy3Alive = false;
                AlivePlayers.Remove(enemy3Point);
                dialog.AddDialog(enemy3Unit.Unit.UnitBase.Name + "が戦闘不能");
                just1DeadUnits[5] = true;
            }
        }
       






    }

    //Unitが死んでしまったかを確認するメソッド
    bool Death(BattleUnit battleUnit)
    {       

        bool death = battleUnit.Unit.HP <= 0;//UnitのHpが0以下になったらdeathをtrue        
        if (death) battleUnit.gameObject.GetComponent<Image>().enabled = false;

        return death;
    }


    //currentBstateのplayerTurnのどれかに変更するメソッド
    //引数に変える先のBattleStateを入れる
    public void TurnCng(BattleState battleState)
    {
        switch (battleState)
        {
            //引数がplayer1Turnなら
            case BattleState.Player1Turn:

                CurrentBState = BattleState.Player1Turn;// Stateをplayer1Turnにして
                selectAction.SetActive(true);//selectActionを起動
                playerSkill.SetSkill(player1Unit.Unit.Skills);//player1のスキル情報をセットする
                break;

            //引数がplayer2TurnならStateをplayer2Turnにしてplayer2のスキル情報をセットする
            case BattleState.Player2Turn:

                CurrentBState = BattleState.Player2Turn;
                selectAction.SetActive(true);
                playerSkill.SetSkill(player2Unit.Unit.Skills);
                break;

            //引数がplayer3TurnならStateをplayer3Turnにしてplayer3のスキル情報をセットする
            case BattleState.Player3Turn:

                CurrentBState = BattleState.Player3Turn;
                selectAction.SetActive(true);
                playerSkill.SetSkill(player3Unit.Unit.Skills);
                break;

            //引数がEnemyTurnならstateをEnemyTimeTurnに
            //case BattleState.EnemyTimeTurn:

            //    currentBState = BattleState.EnemyTimeTurn;
            //    readyButton.SetActive(true);

            //    break;
            //引数がEnemyTurnならstateをEnemyTurnに
            case BattleState.EnemyTurn:

                CurrentBState = BattleState.EnemyTurn;
                StartCoroutine(EnemyTurn());

                break;
            case BattleState.BattleTurn:

                CurrentBState = BattleState.BattleTurn;
                StartCoroutine(EndOrContinue());//バトルが終了したら、つづくならWaitNext、負けならLoseTurn、勝っていたらWinTurnへ
                break;
            case BattleState.WaitNextTurn:
                CurrentBState = BattleState.WaitNextTurn;
                dialogObj.SetActive(false);//ダイヤログを非表示
                dialog.DialogReset();//ダイヤログをリセットするメソッド
                break;

            case BattleState.LoseTurn:

                CurrentBState = BattleState.LoseTurn;
                Debug.Log("負けたよ");
                SceneManager.LoadScene("TitleScene");
                break;

            case BattleState.WinTurn:

                CurrentBState = BattleState.WinTurn;
                Debug.Log("勝ったよ");
                SceneManager.LoadScene("AdventureScene");
                break;

        }


    }


    //skillButtonが押されたときに発動　　SkillButtonがSetActive=falseになってしまうから代わりにコルーチンを発動するためのメソッド
    public void PushButton(int player)
    {
        StartCoroutine(PlayerTunrNext(player));//PlayerTurnNextコルーチン発動
    }

    //playerのターンが終わった時次はどのターンになるか決めるコルーチン
    public IEnumerator PlayerTunrNext(int player)
    {
        yield return new WaitUntil(() => next == true);//線を描き終わったら
        if (player == 1)//終わったのがplayer1Turnだったら
        {
            //player2が生きているなら
            if (Player2Alive)
            {
                TurnCng(BattleState.Player2Turn);//BattleStetaをplayer2Turnに
            }
            //Player3が生きているなら
            else if (Player3Alive)
            {
                TurnCng(BattleState.Player3Turn);
            }
            //誰も生き残っていないなら
            else
            {
                TurnCng(BattleState.EnemyTurn);
            }
        }
        else if (player == 2)//終わったのがplayer2Turnだったら
        {
            //Player3が生きているなら
            if (Player3Alive)
            {
                TurnCng(BattleState.Player3Turn);

            }
            //生き残っていないのなら
            else TurnCng(BattleState.EnemyTurn);

        }
        else if (player == 3)//終わったのがplayer3Turnだったら
        {
            //EnemyTurnに
            TurnCng(BattleState.EnemyTurn);
        }


    }

    





    //線を描いてそれを待ってからEnemyターンにするコルーチン　後で消すかも
    IEnumerator EnemyTurn()
    {
        yield return new WaitUntil(() => next == true);//playerが描き終わる待ってから
        EnemyIntelligence();//Enemyの情報を代入
        dialogObj.SetActive(true);//ダイヤログを表示

        if (Enemy1Alive)
        {
            enemyDraw[0].DrawEnemy(intelligence.enemySkillTypes[0]);//線を書く時にSkillTypeの情報も渡す

        }
        if (Enemy2Alive)
        {
            enemyDraw[1].DrawEnemy(intelligence.enemySkillTypes[1]);
        }
        if (Enemy3Alive)
        {
            enemyDraw[2].DrawEnemy(intelligence.enemySkillTypes[2]);
        }
        yield return new WaitForSeconds(1f);//ちょっと待ってから
        TurnCng(BattleState.BattleTurn);//BattaleTurnに
        yield break;



    }


    void EnemyIntelligence()
    {
        //Enemy1が生きているなら
        if (Enemy1Alive)
        {
            int nextSkill = Random.Range(0, enemy1Unit.Unit.Skills.Count);//Enemy1の持っているスキルの中からランダムに選ぶ


            //選んだスキルの情報を代入
            intelligence.enemySkillNames[0] = enemy1Unit.Unit.Skills[nextSkill].Skillbase.Name;
            intelligence.enemySkillTypes[0] = enemy1Unit.Unit.Skills[nextSkill].Skillbase.SkillType;
            intelligence.enemyPowers[0] = enemy1Unit.Unit.Skills[nextSkill].Skillbase.Power;
            intelligence.enemyPenetionPowers[0] = enemy1Unit.Unit.Skills[nextSkill].Skillbase.PenetrationPower;
            intelligence.enemySpeeds[0] = enemy1Unit.Unit.Skills[nextSkill].Skillbase.Speed;
            intelligence.enemyNumAttacks[0] = enemy1Unit.Unit.Skills[nextSkill].Skillbase.NumberAttacks;

            //一旦ここで選んだスキルをダイヤログで流す(演出を変える時に変更)
            dialog.AddDialog(enemy1Unit.Unit.UnitBase.Name + "は" + intelligence.enemySkillNames[0] + "を放った");
        }
        //Enemy2が生きているなら
        if (Enemy2Alive)
        {
            int nextSkill = Random.Range(0, enemy2Unit.Unit.Skills.Count);

            intelligence.enemySkillNames[1] = enemy2Unit.Unit.Skills[nextSkill].Skillbase.Name;
            intelligence.enemySkillTypes[1] = enemy2Unit.Unit.Skills[nextSkill].Skillbase.SkillType;
            intelligence.enemyPowers[1] = enemy2Unit.Unit.Skills[nextSkill].Skillbase.Power;
            intelligence.enemyPenetionPowers[1] = enemy2Unit.Unit.Skills[nextSkill].Skillbase.PenetrationPower;
            intelligence.enemySpeeds[1] = enemy2Unit.Unit.Skills[nextSkill].Skillbase.Speed;
            intelligence.enemyNumAttacks[1] = enemy2Unit.Unit.Skills[nextSkill].Skillbase.NumberAttacks;

            dialog.AddDialog(enemy2Unit.Unit.UnitBase.Name + "は" + intelligence.enemySkillNames[0] + "を放った");
        }
        //Enemy3が生きているなら
        if (Enemy3Alive)
        {
            int nextSkill = Random.Range(0, enemy3Unit.Unit.Skills.Count);

            intelligence.enemySkillNames[2] = enemy3Unit.Unit.Skills[nextSkill].Skillbase.Name;
            intelligence.enemySkillTypes[2] = enemy3Unit.Unit.Skills[nextSkill].Skillbase.SkillType;
            intelligence.enemyPowers[2] = enemy3Unit.Unit.Skills[nextSkill].Skillbase.Power;
            intelligence.enemyPenetionPowers[2] = enemy3Unit.Unit.Skills[nextSkill].Skillbase.PenetrationPower;
            intelligence.enemySpeeds[2] = enemy3Unit.Unit.Skills[nextSkill].Skillbase.Speed;
            intelligence.enemyNumAttacks[2] = enemy3Unit.Unit.Skills[nextSkill].Skillbase.NumberAttacks;

            dialog.AddDialog(enemy3Unit.Unit.UnitBase.Name + "は" + intelligence.enemySkillNames[0] + "を放った");
        }

    }

    //ターン終了時にまだゲームを続けるか終わるかを判断して先の処理を行うコルーチン
    IEnumerator EndOrContinue()
    {

        //Ballが全部ヒエラルキー上から消えたら
        {
            yield return new WaitUntil(() => AliveBalls.Count > 0);//一度カウントが1異常になるまで待ってから
            yield return new WaitUntil(() => AliveBalls.Count <= 0);//ListのAliveBallsのカウントが0なるまで待つ            
            yield return new WaitForSeconds(1);//一秒待ってから

            //プレイヤーが誰も生き残っていないのなら(誰もいない場合も)
            if (!Player1Alive && !Player2Alive && !Player3Alive)
            {
                yield return new WaitForSeconds(1);
                //敗北処理
                TurnCng(BattleState.LoseTurn);
            }
            //敵が誰も生き残っていないのなら
            else if (!Enemy1Alive && !Enemy2Alive && !Enemy3Alive)
            {
                //playerUnitに経験値を配る

                //勝利画面

                //少し待ってから
                yield return new WaitForSeconds(1); 
                //勝利処理
                TurnCng(BattleState.WinTurn);
            }
            //どちらの陣営にも誰かは生き残っている場合
            else
            {
                Debug.Log("もっかい!");
                TurnCng(BattleState.WaitNextTurn);//リセットするターン
                yield return new WaitForSeconds(1);//
                //もう一巡
                //生き残っている中で若い順番のプレイヤーから
                if (Player1Alive) TurnCng(BattleState.Player1Turn);
                else if (Player2Alive) TurnCng(BattleState.Player2Turn);
                else if (Player3Alive) TurnCng(BattleState.Player3Turn);

            }


        }

    }

    //ボールが誰かに当たった時のダメージ計算をするメソッド(AttackBallかRnemyBallで発動)
    public int Damage(int myPower, int UnitNum, BattleUnit collisionUnit)
    {
        int damage = 0;

        if (UnitNum == 1)//自分がPlaye1のボールだった時
        {
            damage = (myPower * player1Unit.Unit.Attack) / collisionUnit.Unit.Defense;//スキル火力 * 自分の攻撃力 / 相手の防御力
        }
        else if (UnitNum == 2)//自分がPlayeのボールだった時
        {
            damage = (myPower * player2Unit.Unit.Attack) / collisionUnit.Unit.Defense;
        }
        else if (UnitNum == 3)//自分がPlaye3のボールだった時
        {
            damage = (myPower * player3Unit.Unit.Attack) / collisionUnit.Unit.Defense;
        }
        else if (UnitNum == 4)//自分がEnemy1のボールだった時
        {
            damage = (myPower * enemy1Unit.Unit.Attack) / collisionUnit.Unit.Defense;
        }
        else if (UnitNum == 5)//自分がEnemy2のボールだった時
        {
            damage = (myPower * enemy2Unit.Unit.Attack) / collisionUnit.Unit.Defense;
        }
        else if (UnitNum == 6)//自分がEnemy3のボールだった時
        {
            damage = (myPower * enemy3Unit.Unit.Attack) / collisionUnit.Unit.Defense;
        }

        Debug.Log(damage + "ダメージだったよ");
        return damage;

    }




}
