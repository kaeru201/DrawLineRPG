using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    Unit unit;
    [SerializeField] int currentHP;
    [SerializeField] public Slider slider;
    [SerializeField] public int damage = 1;

    public int CurrentHP { get => currentHP; set => currentHP = value; }

    void Start()
    {
        //生成したUnit毎の最大をmaxValueに代入する
        //slider.maxValue = unit.MaxHP;
        // slider.value = 1;


    }


    void Update()
    {
        //ここでやるかは置いといて現在のHPをvalueに代入
        slider.value = CurrentHP;
        //   OnDamage();   
    }

    //仮ダメージフラグメソッド
    //void OnDamage()
    //{
    //    if (CurrentHP > 0)
    //    {
    //        if(Input.GetKeyDown(KeyCode.Space) )
    //        {
    //            CurrentHP = CurrentHP - damage;
    //            Debug.Log(CurrentHP);
    //        }



    //    }



    //}

}
