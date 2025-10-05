using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

//実際にバトルを進行させるスクリプト
public class BattleSystem : MonoBehaviour
{
    
    [SerializeField] DrawIntelligence drawIntelligence;

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

        //UPDetaでやることではないかも
        if (battleState == BattleState.ActionTurn)
        {

            //if() もし全員が行動し終わったら
            //{
            //敵の行動　Debug.Log("敵の行動)
            //}

            //if(player) //行動していない生きているPlayerがいるなら

            if (clickSkill)
            {
                if (clickSkillCount == 0)
                {
                    drawIntelligence.DrawIn(1);//仮に変数1をplayer1だということにしてplayer1が行動しているとしている
                    clickSkill = false;
                    clickSkillCount += 1;

                    playerSkill.SetSkill(player2Unit.Unit.Skills);//プレイヤー2の情報を
                }
                if (clickSkillCount == 1)
                {
                    drawIntelligence.DrawIn(2);
                    clickSkill = false;
                    clickSkillCount += 1;

                    playerSkill.SetSkill(player3Unit.Unit.Skills);//プレイヤー3の情報を
                }
                if (clickSkillCount == 2)
                {
                    drawIntelligence.DrawIn(3);
                    clickSkill = false;
                    clickSkillCount += 1;
                }

                //}

                //if() もしアイテムを押したら
            }
        }


    }
}
