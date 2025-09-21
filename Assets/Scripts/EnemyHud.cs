using TMPro;
using UnityEngine;

//�G�̃��j�b�g��Hud
public class EnemyHud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI levelText;

public void SetData(Unit unit)
    {
        nameText.text = unit.unitBase.Name;
        levelText.text = "LV" + unit.level;
    }
    
    
}
