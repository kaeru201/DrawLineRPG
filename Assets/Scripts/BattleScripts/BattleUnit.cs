using TMPro;
using UnityEngine;
using UnityEngine.UI;

//実際にオブジェクト毎にユニットを生成するクラス
public class BattleUnit : MonoBehaviour
{   
    private Unit unit;
    [SerializeField] TextMeshProUGUI prefabDamage;
    [SerializeField] TextMeshProUGUI prefabHeal;


    public Unit Unit { get => unit; set => unit = value; }

    //モンスターの生成メソッド
    public void SetUp(Unit unit)
    {
        Unit = unit; //new Unit(unitBase, level);
        //相手の画像
        Image image = GetComponent<Image>();
        image.sprite = Unit.UnitBase.Sprite;
    }


    //ダメージを受けた時にダメージ表記を出すメソッド
    public void TakeDamage(int damage)
    {
       TextMeshProUGUI textObj = Instantiate(prefabDamage);
        textObj.transform.SetParent(transform);
        textObj.transform.localPosition = new Vector3(80,60,0);
        textObj.transform.localScale = new Vector3(1,1,1);
        textObj.text = damage + "!";
    }
    //回復を受けた時に回復表記を出すメソッド
    public void TakeHeal(int heal)
    {
        TextMeshProUGUI textObj = Instantiate(prefabHeal);
        textObj.transform.SetParent(transform);
        textObj.transform.localPosition = new Vector3(80, 60, 0);
        textObj.transform.localScale = new Vector3(1, 1, 1);
        textObj.text = heal + "!";
    }

}
