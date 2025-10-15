using TMPro;
using UnityEngine;

//敵のユニットのHud
public class EnemyHud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI levelText;

    Unit myUnit;

public void SetData(Unit unit)
    {
        myUnit = unit;
        nameText.text = unit.UnitBase.Name;
        levelText.text = "LV" + unit.Level;
    }

   

}
