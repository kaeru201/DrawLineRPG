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
        //��������Unit���̍ő��maxValue�ɑ������
        //slider.maxValue = unit.MaxHP;
       // slider.value = 1;
        

    }

        
    void Update()
    {
        //�����ł�邩�͒u���Ƃ��Č��݂�HP��value�ɑ��
        slider.value = currentHP;
        OnDamage();   
    }

    //���_���[�W�t���O���\�b�h
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
