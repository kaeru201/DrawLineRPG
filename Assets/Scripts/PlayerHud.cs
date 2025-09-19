using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Slider hpSlider;

    [SerializeField] void SetData(Unit unit)
    {
        nameText.text = unit.unitBase.Name;//Unit‚Ìpublic‚É‚µ‚½UnitBaseŒ^‚ÌunitBase‚Ìname‚ð‘ã“ü
        levelText.text = "LV"+unit.level;//string + intŒ^
        hpSlider.maxValue = unit.hp;
    }

   

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
