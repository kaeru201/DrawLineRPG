using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    //とりあえずインスペクター上でモンスターをセットする
    [SerializeField] UnitBase unitBase;
    [SerializeField] int level;//今の相手のレベル

    private Unit unit;
public Unit Unit { get => unit; set => unit = value; }

    //モンスターの生成メソッド
    public void SetUp()
    {
        Unit = new Unit(unitBase, level);
        //相手の画像
        Image image = GetComponent<Image>();
        image.sprite =Unit.UnitBase.Sprite;
    }
}
