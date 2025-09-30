using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    //とりあえずインスペクター上でアタッチ
    [SerializeField] BattleUnit player1Unit;
    [SerializeField] BattleUnit player2Unit;
    [SerializeField] BattleUnit player3Unit;
    [SerializeField] BattleUnit Enemy1Unit;
    [SerializeField] BattleUnit Enemy2Unit;
    [SerializeField] BattleUnit Enemy3Unit;


    //とりあえずインスペクター上でアタッチ
    [SerializeField] PlayerHud player1Hud;
    [SerializeField] PlayerHud player2Hud;
    [SerializeField] PlayerHud player3Hud;
    [SerializeField] EnemyHud Enemy1Hud;
    [SerializeField] EnemyHud Enemy2Hud;
    [SerializeField] EnemyHud Enemy3Hud;



    private void Start()
    {
        player1Unit.SetUp();//モンスターの生成
        player2Unit.SetUp();
        player3Unit.SetUp();
        Enemy1Unit.SetUp();
        Enemy2Unit.SetUp();
        Enemy3Unit.SetUp();
       

        player1Hud.SetData(player1Unit.Unit);//プレイヤーのHudを出す
        player2Hud.SetData(player2Unit.Unit);
        player3Hud.SetData(player3Unit.Unit);
        Enemy1Hud.SetData(Enemy1Unit.Unit);
        Enemy2Hud.SetData(Enemy2Unit.Unit);
        Enemy3Hud.SetData(Enemy3Unit.Unit);
        
    }

}
