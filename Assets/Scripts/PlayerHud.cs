using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Slider hpSlider;
    [SerializeField] TextMeshProUGUI hpText;

    public void SetData(Unit unit)
    {

        nameText.text = unit.UnitBase.Name;//UnitのpublicにしたUnitBase型のunitBaseのnameを代入
        levelText.text = "LV" + unit.Level;//string + int型
        hpSlider.maxValue = unit.Hp;
        hpText.text = unit.Hp + "  /  ";

    }




}
