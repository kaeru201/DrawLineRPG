using UnityEngine;
using UnityEngine.UI;

//HPBarにアタッチするスクリプト　
//HPBarとUnitのHPを連動させる
public class HPBar : MonoBehaviour
{
    
    [SerializeField] public Slider slider;    
    BattleUnit myUnit;

    int currentHP;

    void Start()
    {
        myUnit = transform.parent.GetComponent<BattleUnit>();
        slider.maxValue = myUnit.Unit.MaxHP;
        slider.value = myUnit.Unit.HP;
    }

    void Update()
    {
        if(currentHP != myUnit.Unit.HP)//HPが変動したら
        {
            currentHP = myUnit.Unit.HP;
            slider.value = myUnit.Unit.HP;//HPBarをHPの値する
        }
    }


}
