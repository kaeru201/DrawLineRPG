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
        hpSlider.maxValue = unit.HP;
        hpText.text = unit.HP + "  /  " + unit.MaxHP;

        lastHp = unit.HP;

    }


    private void Update()
    {
        myUnit.HP = Mathf.Clamp(myUnit.HP, 0, myUnit.MaxHP);//Hpの最小値と最大値を固定

        //もしHPが減ったら
        if (lastHp != myUnit.HP)
        {
            hpText.text = myUnit.HP + "/" + myUnit.MaxHP;//Hpテキストを更新

            lastHp = myUnit.HP;//変更したHpを記憶しておく

        }
        else return;
    }


}
