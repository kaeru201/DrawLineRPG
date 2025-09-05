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
        //Å‰‚ÌHP‚ğÅ‘åHP‚É(‚ ‚Æ‚ÅÁ‚·‚©‚à?)
        currentHP = maxHP;
    }


   

   
    void Update()
    {
        
    }

    public void Damage(int value)
    {
        //ƒ_ƒ[ƒWˆ—
    }

    public void Death()
    {
        //€–Sˆ—
    }

}
