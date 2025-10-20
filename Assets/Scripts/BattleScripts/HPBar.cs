using UnityEngine;
using UnityEngine.UI;

//HPBarにアタッチするスクリプト　
//HPBarとUnitのHPを連動させる
public class HPBar : MonoBehaviour
{
    Unit unit;
    [SerializeField] int currentHP;
    [SerializeField] public Slider slider;
    [SerializeField] public int damage = 1;
    BattleUnit myUnit;


    void Start()
    {

        myUnit = transform.parent.GetComponent<BattleUnit>();
        slider.maxValue = myUnit.Unit.MaxHP;
    }

    void Update()
    {
        slider.value = myUnit.Unit.HP;
    }


}
