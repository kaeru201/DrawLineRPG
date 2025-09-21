using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    //とりあえずインスペクター上でモンスターをセットする
    [SerializeField] UnitBase unitBase;
    [SerializeField] int level;//今の相手のレベル

    public Unit unit { get; set; }

    //モンスターの生成メソッド
    public void SetUp()
    {
        unit = new Unit(unitBase, level);
        //相手の画像
        Image image = GetComponent<Image>();
        image.sprite =unit.unitBase.Sprite;
    }
}
