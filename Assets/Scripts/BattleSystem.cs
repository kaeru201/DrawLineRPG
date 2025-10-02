using UnityEngine;

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

    [SerializeField] SkillSelection player1Skill;

    public int skill1Range;

    //public int Skill1Range { get => skill1Range; }

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

         player1Skill.SetSkill(player1Unit.Unit.Skills);

       




    }

    private void Update()
    {
       // Debug.Log(skill1Range);

    }

}
