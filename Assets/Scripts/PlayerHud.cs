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
        nameText.text = unit.unitBase.Name;//Unit��public�ɂ���UnitBase�^��unitBase��name����
        levelText.text = "LV"+unit.level;//string + int�^
        hpSlider.maxValue = unit.hp;
    }

   

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
