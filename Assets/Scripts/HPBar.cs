using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    Unit unit;
    int currentHP;
    [SerializeField] public Slider slider;
    [SerializeField] public int damage = 1;

   
    void Start()
    {
        //生成したUnit毎の最大をmaxValueに代入する
        //slider.maxValue = unit.MaxHP;
       // slider.value = 1;
        

    }

        
    void Update()
    {
        //ここでやるかは置いといて現在のHPをvalueに代入
        slider.value = currentHP;
        OnDamage();   
    }

    //仮ダメージフラグメソッド
    void OnDamage()
    {
        if (currentHP > 0)
        {
            if(Input.GetKeyDown(KeyCode.Space) )
            {
                currentHP = currentHP - damage;
                Debug.Log(currentHP);
            }



        }
        
           
        
    }

}
