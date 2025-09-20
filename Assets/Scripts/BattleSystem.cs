using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit battleUnit;
    [SerializeField] PlayerHud playerHud;

    private void Start()
    {
        battleUnit.SetUp();//モンスターの生成
        playerHud.SetData(battleUnit.unit);//プレイヤーのHudを出す
    }

}
