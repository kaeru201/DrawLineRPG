using System.Collections;
using UnityEngine;



public enum BattleState //列挙型の現在どのターンなのか

{
    StartTurn,
    Player1Turn,
    Player2Turn,
    Player3Turn,
    //EnemyTimeTurn,　//後で消すかも
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

    [SerializeField] DrawIntelligence intelligence;
    [SerializeField] SkillSelection playerSkill;
    [SerializeField] EnemyDraw[] enemyDraw = new EnemyDraw[3];

    [SerializeField] BattleState currentBState;

    [SerializeField] GameObject readyButton;

    public bool next = false;//線を引き終わったかどうか 

    public bool Player1Alive { get; set; } = false;
    public bool Player2Alive { get; set; } = false;
    public bool Player3Alive { get; set; } = false;

    public bool Enemy1Alive { get; set; } = false;
    public bool Enemy2Alive { get; set; } = false;
    public bool Enemy3Alive { get; set; } = false;

    public BattleState CurrentBState { get => currentBState; set => currentBState = value; }


    //バトルが始まったら
    private void Start()
    {
        CurrentBState = BattleState.StartTurn;

        if (CurrentBState == BattleState.StartTurn)
        {


            if (player1Unit != null)
            {
                player1Unit.SetUp();//Unitの生成
                Player1Alive = true;//Player生存フラグをON
                player1Hud.SetData(player1Unit.Unit);//プレイヤーのHudを出す
            }
            if (player2Unit != null)
            {
                player2Unit.SetUp();
                Player2Alive = true;
                player2Hud.SetData(player2Unit.Unit);
            }
            if (player3Unit != null)
            {
                player3Unit.SetUp();
                Player3Alive = true;
                player3Hud.SetData(player3Unit.Unit);

            }
            if (enemy1Unit != null)
            {
                enemy1Unit.SetUp();
                Enemy1Alive = true;
                enemy1Hud.SetData(enemy1Unit.Unit);

            }
            if (enemy2Unit != null)
            {
                enemy2Unit.SetUp();
                Enemy2Alive = true;
                enemy2Hud.SetData(enemy2Unit.Unit);
            }
            if (enemy3Unit != null)
            {
                enemy3Unit.SetUp();
                Enemy3Alive = true;
                enemy3Hud.SetData(enemy3Unit.Unit);
            }


        }

        //もしplayer1が生きているなら
        //if(player1Suveivel)
        //{

        //}

        //いてもいなくても最初はplayer1Turnから
        TurnCng(BattleState.Player1Turn);

    }

    private void Update()
    {

        if (player1Unit.Unit.Hp <= 0) Player1Alive = false;
        else if (player2Unit.Unit.Hp <= 0) Player2Alive = false;
        else if (player3Unit.Unit.Hp <= 0) Player3Alive = false;
        else if (enemy1Unit.Unit.Hp <= 0) Enemy1Alive = false;
        else if (enemy2Unit.Unit.Hp <= 0) Enemy2Alive = false;
        else if (enemy3Unit.Unit.Hp <= 0) Enemy3Alive = false;
        else return;
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

            //引数がEnemyTurnならstateをEnemyTimeTurnに
            //case BattleState.EnemyTimeTurn:

            //    currentBState = BattleState.EnemyTimeTurn;
            //    readyButton.SetActive(true);

            //    break;
            //引数がEnemyTurnならstateをEnemyTurnに
            case BattleState.EnemyTurn:

                currentBState = BattleState.EnemyTurn;
                StartCoroutine(EnemyTurn());

                break;
            case BattleState.BattleTurn:

                currentBState = BattleState.BattleTurn;
                break;
        }


    }



    //線を描くのを待ってからEnemyターンにするコルーチン　後で消すかも
    IEnumerator EnemyTurn()
    {

        yield return new WaitUntil(() => next == true);//player3が描き終わる待ってから
        EnemyIntelligence();//Enemyの情報を代入
                            //TurnCng(BattleState.EnemyTurn);
        for (int i = 0; i < enemyDraw.Length; i++)//敵の数だけ線を引く(後で生きている敵だけに)
        {
            enemyDraw[i].DrawEnemy();
        }
        yield return new WaitForSeconds(1f);//ちょっと待ってから
        TurnCng(BattleState.BattleTurn);//BattaleTurnに
        yield break;
    }

    //一回挟まないと動かなかったから一旦
    //private void Update()
    //{
    //    if (currentBState != BattleState.EnemyTimeTurn) return;



    //    StartCoroutine(EnemyTurn());
    //}

    void EnemyIntelligence()
    {
        //Enemy1が生きているなら
        if (Enemy1Alive)
        {
            int nextSkill = Random.Range(0, enemy1Unit.Unit.Skills.Count);//Enemy1の持っているスキルの中からランダムに選ぶ


            //選んだスキルの情報を代入
            intelligence.Enemy1SkillType = enemy1Unit.Unit.Skills[nextSkill].Skillbase.SkillType;
            intelligence.enemyPowers[0] = enemy1Unit.Unit.Skills[nextSkill].Skillbase.Power;
            intelligence.enemyPenetionPowers[0] = enemy1Unit.Unit.Skills[nextSkill].Skillbase.PenetrationPower;
            intelligence.enemySpeeds[0] = enemy1Unit.Unit.Skills[nextSkill].Skillbase.Speed;
            intelligence.enemyNumAttacks[0] = enemy1Unit.Unit.Skills[nextSkill].Skillbase.NumberAttacks;


        }
        //Enemy2が生きているなら
        if (Enemy2Alive)
        {
            int nextSkill = Random.Range(0, enemy2Unit.Unit.Skills.Count);

            intelligence.Enemy2SkillType = enemy2Unit.Unit.Skills[nextSkill].Skillbase.SkillType;
            intelligence.enemyPowers[1] = enemy2Unit.Unit.Skills[nextSkill].Skillbase.Power;
            intelligence.enemyPenetionPowers[1] = enemy2Unit.Unit.Skills[nextSkill].Skillbase.PenetrationPower;
            intelligence.enemySpeeds[1] = enemy2Unit.Unit.Skills[nextSkill].Skillbase.Speed;
            intelligence.enemyNumAttacks[1] = enemy2Unit.Unit.Skills[nextSkill].Skillbase.NumberAttacks;
        }
        //Enemy3が生きているなら
        if (Enemy3Alive)
        {
            int nextSkill = Random.Range(0, enemy3Unit.Unit.Skills.Count);

            intelligence.Enemy3SkillType = enemy3Unit.Unit.Skills[nextSkill].Skillbase.SkillType;
            intelligence.enemyPowers[2] = enemy3Unit.Unit.Skills[nextSkill].Skillbase.Power;
            intelligence.enemyPenetionPowers[2] = enemy3Unit.Unit.Skills[nextSkill].Skillbase.PenetrationPower;
            intelligence.enemySpeeds[2] = enemy3Unit.Unit.Skills[nextSkill].Skillbase.Speed;
            intelligence.enemyNumAttacks[2] = enemy3Unit.Unit.Skills[nextSkill].Skillbase.NumberAttacks;


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
        else if(UnitNum == 3)//自分がPlaye3のボールだった時
        {
             damage = (myPower * player3Unit.Unit.Attack) / collisionUnit.Unit.Defense;
        }
        else if (UnitNum == 4)//自分がEnemy1のボールだった時
        {
             damage = (myPower * enemy1Unit.Unit.Attack) / collisionUnit.Unit.Defense;
        }
        else if(UnitNum ==  5)//自分がEnemy2のボールだった時
        {
             damage = (myPower * enemy2Unit.Unit.Attack) / collisionUnit.Unit.Defense;
        }
        else if(UnitNum == 6)//自分がEnemy3のボールだった時
        {
             damage = (myPower * enemy3Unit.Unit.Attack) / collisionUnit.Unit.Defense;
        }

        return damage;
            
    }


}
