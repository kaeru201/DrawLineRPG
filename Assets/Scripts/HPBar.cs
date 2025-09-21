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
        //��������Unit���̍ő��maxValue�ɑ������
        //slider.maxValue = unit.MaxHP;
       // slider.value = 1;
        

    }

        
    void Update()
    {
        //�����ł�邩�͒u���Ƃ��Č��݂�HP��value�ɑ��
        slider.value = CurrentHP;
        OnDamage();   
    }

    //���_���[�W�t���O���\�b�h
    void OnDamage()
    {
        if (CurrentHP > 0)
        {
            if(Input.GetKeyDown(KeyCode.Space) )
            {
                CurrentHP = CurrentHP - damage;
                Debug.Log(CurrentHP);
            }



        }
        
           
        
    }

}
