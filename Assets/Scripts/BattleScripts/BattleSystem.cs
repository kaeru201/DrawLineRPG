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

    [SerializeField] GameManager gameManager;
    [SerializeField] DrawIntelligence intelligence;
    [SerializeField] SkillSelection playerSkill;
    [SerializeField] EnemyDraw[] enemyDraw = new EnemyDraw[3];
    [SerializeField] GameObject dialogObj;//ダイヤログオブジェクト
    public Dialog dialog;
    [SerializeField] GameObject endDialogObj;//エンドダイヤログオブジェクト
    public Dialog endDialog;

    [SerializeField] public BattleState CurrentBState; //{ get; set; }

    [SerializeField] GameObject player1Point;
    [SerializeField] GameObject player2Point;
    [SerializeField] GameObject player3Point;
    [SerializeField] GameObject enemy1Point;
    [SerializeField] GameObject enemy2Point;
    [SerializeField] GameObject enemy3Point;

    [SerializeField] GameObject selectAction;
    [SerializeField] GameObject readyButton;
    [SerializeField] GameObject[] startPoints = new GameObject[3];//線を描き始めるPointのGameObject ターン開始時にオンにしてターン終了時オフ
    List<GameObject> alivePLayers = new List<GameObject>();　//生き残っているplayerPointを得るリスト
    List<GameObject> aliveEnemies = new List<GameObject>();
    [SerializeField] List<GameObject> aliveBalls = new List<GameObject>();//ballをインスタンス化するたびにリストに追加してボールがまだフィールドにいるか調べるリスト　
    [SerializeField] UnitSelect unitSelect;


    public bool next = false;//線を引き終わったかどうか 
    bool[] just1DeadUnits = new bool[6];//一回だけ死亡判定させる変数(player1=0,player2=1.enemy1=3)
    int cutExp = 1;//取得する経験値をどれだけ減らすかの変数　ポートフォリオ用に下げていますが、実際は8くらい想定
    int gainExp;


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
    private void Start()
    {

        CurrentBState = BattleState.StartTurn;

        if (CurrentBState == BattleState.StartTurn)
        {


            if (player1Unit != null)
            {
                player1Unit.SetUp(UnitSelect.playerUnits[0]);//Unitの生成
                Player1Alive = true;//Player生存フラグをON
                AlivePlayers.Add(player1Point);//敵の標的になるPointのオブジェクトをリストに
                player1Hud.SetData(player1Unit.Unit);//プレイヤーのHudを出す
            }
            if (player2Unit != null)
            {
                player2Unit.SetUp(UnitSelect.playerUnits[1]);
                Player2Alive = true;
                AlivePlayers.Add(player2Point);
                player2Hud.SetData(player2Unit.Unit);
            }
            if (player3Unit != null)
            {
                player3Unit.SetUp(UnitSelect.playerUnits[2]);
                Player3Alive = true;
                AlivePlayers.Add(player3Point);
                player3Hud.SetData(player3Unit.Unit);

            }
            if (enemy1Unit != null)
            {
                enemy1Unit.SetUp(unitSelect.EnemyParty[0]);
                Enemy1Alive = true;
                AliveEnemies.Add(enemy1Point);
                enemy1Hud.SetData(enemy1Unit.Unit);

            }
            if (enemy2Unit != null)
            {
                enemy2Unit.SetUp(unitSelect.EnemyParty[1]);
                Enemy2Alive = true;
                AliveEnemies.Add(enemy2Point);
                enemy2Hud.SetData(enemy2Unit.Unit);
            }
            if (enemy3Unit != null)
            {
                enemy3Unit.SetUp(unitSelect.EnemyParty[2]);
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
        if (!just1DeadUnits[1])
        {
            if (Death(player2Unit))
            {
                Player2Alive = false;
                AlivePlayers.Remove(player2Point);
                dialog.AddDialog(player2Unit.Unit.UnitBase.Name + "が戦闘不能");
                just1DeadUnits[1] = true;
            }
        }
        if (!just1DeadUnits[2])
        {
            if (Death(player3Unit))
            {
                Player3Alive = false;
                AlivePlayers.Remove(player3Point);
                dialog.AddDialog(player3Unit.Unit.UnitBase.Name + "が戦闘不能");
                just1DeadUnits[2] = true;
            }
        }
        if (!just1DeadUnits[3])
        {
            if (Death(enemy1Unit))
            {
                Enemy1Alive = false;
                AliveEnemies.Remove(enemy1Point);
                dialog.AddDialog(enemy1Unit.Unit.UnitBase.Name + "が戦闘不能");
                just1DeadUnits[3] = true;
            }
        }
        if (!just1DeadUnits[4])
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
                startPoints[0].SetActive(true);//player1のstartPointをつける

                break;

            //引数がplayer2TurnならStateをplayer2Turnにしてplayer2のスキル情報をセットする
            case BattleState.Player2Turn:

                CurrentBState = BattleState.Player2Turn;
                selectAction.SetActive(true);
                playerSkill.SetSkill(player2Unit.Unit.Skills);
                startPoints[1].SetActive(true);//player2のstartPointをつける

                break;

            //引数がplayer3TurnならStateをplayer3Turnにしてplayer3のスキル情報をセットする
            case BattleState.Player3Turn:

                CurrentBState = BattleState.Player3Turn;
                selectAction.SetActive(true);
                playerSkill.SetSkill(player3Unit.Unit.Skills);
                startPoints[2].SetActive(true);//player3のstartPointをつける

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
                if (GameManager.lastBattle) GameManager.lastBattle = false;//負けたらラストバトルフラグをオフ
                SceneManager.LoadScene("TitleScene");
                break;

            case BattleState.WinTurn:

                CurrentBState = BattleState.WinTurn;
                if (GameManager.lastBattle) gameManager.Clear();//もしラストバトルフラグがtrueならClearシーンに
                else gameManager.AdventureTurnStart();//それ以外なら敵選択画面に戻る
                
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
            startPoints[0].SetActive(false);//player1のstartPointを消す
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
            startPoints[1].SetActive(false);//player2のstartPointを消す
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
            startPoints[2].SetActive(false);//player3のstartPointを消す
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
            enemyDraw[0].LineColor(intelligence.enemySkillTypes[0]);//SkillTypeに応じた線を描く時の色を変える
            enemyDraw[0].DrawEnemy(intelligence.enemySkillTypes[0]);//線を描く時にSkillTypeの情報も渡す            
            dialog.AddDialog(enemy1Unit.Unit.UnitBase.Name + "は" + intelligence.enemySkillNames[0] + "を放った");//何のスキルを撃ったかをダイヤログで表示
            SoundManager.instance.PlaySE(SEType.Click);//選択音
            yield return new WaitForSeconds(1f);//少し待つ
        }
        if (Enemy2Alive)
        {
            enemyDraw[1].LineColor(intelligence.enemySkillTypes[1]);
            enemyDraw[1].DrawEnemy(intelligence.enemySkillTypes[1]);
            dialog.AddDialog(enemy2Unit.Unit.UnitBase.Name + "は" + intelligence.enemySkillNames[1] + "を放った");
            SoundManager.instance.PlaySE(SEType.Click);//選択音
            yield return new WaitForSeconds(1f);
        }
        if (Enemy3Alive)
        {
            enemyDraw[2].LineColor(intelligence.enemySkillTypes[2]);
            enemyDraw[2].DrawEnemy(intelligence.enemySkillTypes[2]);
            dialog.AddDialog(enemy3Unit.Unit.UnitBase.Name + "は" + intelligence.enemySkillNames[2] + "を放った");
            SoundManager.instance.PlaySE(SEType.Click);//選択音
            yield return new WaitForSeconds(1f);
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
                yield return StartCoroutine(EndDialog(BattleState.LoseTurn));

                TurnCng(BattleState.LoseTurn);


            }
            //敵が誰も生き残っていないのなら
            else if (!Enemy1Alive && !Enemy2Alive && !Enemy3Alive)
            {
                //勝ったらBGMを止めてvictorySEを流す
                SoundManager.instance.PlayBGM(BGMType.None);
                SoundManager.instance.PlaySE(SEType.BattleVictory);
                //playerUnitに経験値を配る
                GainExp();
                //ダイヤログメソッドを発動　終わるまで待機
                yield return StartCoroutine(EndDialog(BattleState.WinTurn));

                //少し待ってから
                //yield return new WaitForSeconds(1);
                //勝利処理
                TurnCng(BattleState.WinTurn);

            }
            //どちらの陣営にも誰かは生き残っている場合
            else
            {                
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

    //倒した敵に応じて経験値をPlayerに与えるメソッド
    void GainExp()
    {

        //plyaerUnit全員に倒した敵に対応する経験値
        int enemyEXP = enemy1Unit.Unit.MaxHP * enemy1Unit.Unit.Level + enemy2Unit.Unit.MaxHP * enemy2Unit.Unit.Level + enemy3Unit.Unit.MaxHP * enemy3Unit.Unit.Level;
        gainExp = Mathf.FloorToInt(enemyEXP / cutExp);
        //PlayerのExpに代入する
        player1Unit.Unit.Exp += gainExp;
        player2Unit.Unit.Exp += gainExp;
        player3Unit.Unit.Exp += gainExp;               
                       
    }

    //ゲームエンドダイヤログを表示して、Listの分だけ流す
    IEnumerator EndDialog(BattleState state)
    {
        endDialogObj.SetActive(true);//ダイヤログオブジェクトをON

        //もし勝ちだったら
        if (state == BattleState.WinTurn)
        {
            //ダイヤログに流れて欲しい順番でAddEndDiaLogListメソッドでリストに追加
            endDialog.AddEndDialogList("あなたのパーティーの勝利です!");
            endDialog.AddEndDialogList("あなたのパーティーはそれぞれ" + gainExp + "経験値を得た!");

            //もしレベルアップするなら
            if (player1Unit.Unit.LevelUP())//player1がレベルアップするかどうか
            {
                //本当はダイヤログではなく、終了ログに出す
                endDialog.AddEndDialogList(player1Unit.Unit.UnitBase.Name + "は" + player1Unit.Unit.Level + "レベルになった");
            }
            if (player2Unit.Unit.LevelUP())//player2がレベルアップするかどうか
            {
                //本当はダイヤログではなく、終了ログに出す
                endDialog.AddEndDialogList(player2Unit.Unit.UnitBase.Name + "は" + player2Unit.Unit.Level + "レベルになった");
            }
            if (player3Unit.Unit.LevelUP())//player3がレベルアップするかどうか
            {
                //本当はダイヤログではなく、終了ログに出す
                endDialog.AddEndDialogList(player3Unit.Unit.UnitBase.Name + "は" + player3Unit.Unit.Level + "レベルになった");
            }

        }
        //もし負けだったら
        else if (state == BattleState.LoseTurn)
        {
            endDialog.AddEndDialogList("あなたのパーティーは敗北しました…");
            endDialog.AddEndDialogList("新しいパーティーを選んでください");
        }

        //右クリックを押されるたびにendDialogsリストの中身全てを繰り返し終わるまでダイヤログにテキストを出す
        for (int i = 0; i < endDialog.endDialogs.Count; i++)
        {
            string dailog = endDialog.endDialogs[i];
            endDialog.AddDialog(dailog);
            while (!Input.GetMouseButtonDown(0))//右されていないのなら何もしない
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);
        //バトルが終わったらリストをリセット
        endDialog.endDialogs.Clear();
        endDialog.DialogReset();

        endDialogObj.SetActive(false);//終わったらオブジェクトをOFF
        yield break;
    }



    //ボールが誰かに当たった時のダメージ計算をするメソッド(AttackBallかRnemyBallで発動)
    public int Damage(int skillPower, int UnitNum, BattleUnit collisionUnit)
    {
        int damage = 0;

        if (UnitNum == 1)//自分がPlaye1のボールだった時
        {
            //damage = (skillPower * player1Unit.Unit.Attack) / collisionUnit.Unit.Defense;//スキル火力 * 自分の攻撃力 / 相手の防御力
            damage = (player1Unit.Unit.Level * 2 / 5 + 2) * skillPower * player1Unit.Unit.Attack / collisionUnit.Unit.Defense / 50 + 2;
        }
        else if (UnitNum == 2)//自分がPlayeのボールだった時
        {
            //damage = (skillPower * player2Unit.Unit.Attack) / collisionUnit.Unit.Defense;
            damage = (player2Unit.Unit.Level * 2 / 5 + 2) * skillPower * player2Unit.Unit.Attack / collisionUnit.Unit.Defense / 50 + 2;
        }
        else if (UnitNum == 3)//自分がPlaye3のボールだった時
        {
            //damage = (skillPower * player3Unit.Unit.Attack) / collisionUnit.Unit.Defense;
            damage = (player3Unit.Unit.Level * 2 / 5 + 2) * skillPower * player3Unit.Unit.Attack / collisionUnit.Unit.Defense / 50 + 2;
        }
        else if (UnitNum == 4)//自分がEnemy1のボールだった時
        {
            // damage = (skillPower * enemy1Unit.Unit.Attack) / collisionUnit.Unit.Defense;
            damage = (enemy1Unit.Unit.Level * 2 / 5 + 2) * skillPower * enemy1Unit.Unit.Attack / collisionUnit.Unit.Defense / 50 + 2;
        }
        else if (UnitNum == 5)//自分がEnemy2のボールだった時
        {
            //damage = (skillPower * enemy2Unit.Unit.Attack) / collisionUnit.Unit.Defense;
            damage = (enemy2Unit.Unit.Level * 2 / 5 + 2) * skillPower * enemy2Unit.Unit.Attack / collisionUnit.Unit.Defense / 50 + 2;
        }
        else if (UnitNum == 6)//自分がEnemy3のボールだった時
        {
            //damage = (skillPower * enemy3Unit.Unit.Attack) / collisionUnit.Unit.Defense;
            damage = (enemy3Unit.Unit.Level * 2 / 5 + 2) * skillPower * enemy3Unit.Unit.Attack / collisionUnit.Unit.Defense / 50 + 2;
        }

        return damage;

    }

}
