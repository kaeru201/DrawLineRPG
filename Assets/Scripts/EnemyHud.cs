using TMPro;
using UnityEngine;

//敵のユニットのHud
public class EnemyHud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI levelText;

public void SetData(Unit unit)
    {
        nameText.text = unit.UnitBase.Name;
        levelText.text = "LV" + unit.Level;
    }
    
    
}
