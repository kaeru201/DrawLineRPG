using UnityEngine;

public class Unit : MonoBehaviour, IDamageable
{
    [Header("Unit Stats")]
    [SerializeField] private string unitName;
    [SerializeField] private int maxHP;
    [SerializeField] private int currentHP;
    [SerializeField] private int attackPower;
    [SerializeField] private int defensePower;


    void Start()
    {
        //�ŏ���HP���ő�HP��(���Ƃŏ�������?)
        currentHP = maxHP;
    }


   

   
    void Update()
    {
        
    }

    public void Damage(int value)
    {
        //�_���[�W����
    }

    public void Death()
    {
        //���S����
    }

}
