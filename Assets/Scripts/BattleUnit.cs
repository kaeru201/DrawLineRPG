using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    //モンスターをセットする
    [SerializeField] UnitBase unitBase;
    [SerializeField] int level;//今の相手のレベル

    public Unit unit { get; set; }

    //モンスターの生成メソッド
    [SerializeField]public void SetUp()
    {
        unit = new Unit(unitBase, level);
        //相手の画像
        Image image = GetComponent<Image>();
        image.sprite =unit.unitBase.Sprite;
    }
}
