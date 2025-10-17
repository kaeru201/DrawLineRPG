using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Slider hpSlider;
    [SerializeField] TextMeshProUGUI hpText;

    Unit myUnit;

    int lastHp;

    public void SetData(Unit unit)
    {
        myUnit = unit;
        nameText.text = unit.UnitBase.Name;//UnitのpublicにしたUnitBase型のunitBaseのnameを代入
        levelText.text = "LV" + unit.Level;//string + int型
        hpSlider.maxValue = unit.Hp;
        hpText.text = unit.Hp + "  /  " + unit.MaxHP;

        lastHp = unit.Hp;

    }


    private void Update()
    {
        myUnit.Hp = Mathf.Clamp(myUnit.Hp, 0, myUnit.MaxHP);//Hpの最小値と最大値を固定

        //もしHPが減ったら
        if (lastHp != myUnit.Hp)
        {
            hpText.text = myUnit.Hp + "/" + myUnit.MaxHP;//Hpテキストを更新

            lastHp = myUnit.Hp;//変更したHpを記憶しておく

        }
        else return;
    }


}
