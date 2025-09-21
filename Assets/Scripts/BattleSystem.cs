using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit player1Unit;
    [SerializeField] BattleUnit player2Unit;
    [SerializeField] BattleUnit player3Unit;
    [SerializeField] BattleUnit player4Unit;

    [SerializeField] PlayerHud player1Hud;
    [SerializeField] PlayerHud player2Hud;
    [SerializeField] PlayerHud player3Hud;
    [SerializeField] PlayerHud player4Hud;

    private void Start()
    {
        player1Unit.SetUp();//モンスターの生成
        player2Unit.SetUp();
        player3Unit.SetUp();
        player4Unit.SetUp();

        player1Hud.SetData(player1Unit.unit);//プレイヤーのHudを出す
        player2Hud.SetData(player2Unit.unit);
        player3Hud.SetData(player3Unit.unit);
        player4Hud.SetData(player4Unit.unit);
    }

}
