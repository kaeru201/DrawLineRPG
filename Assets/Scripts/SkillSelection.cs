using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillSelection : MonoBehaviour

{
    [SerializeField] Unit aunit;


    [SerializeField] TextMeshProUGUI skill1;
    //[SerializeField] TextMeshProUGUI skill2;
    //[SerializeField] TextMeshProUGUI skill3;
    //[SerializeField] TextMeshProUGUI skill4;
    //[SerializeField] TextMeshProUGUI skill5;
    //[SerializeField] TextMeshProUGUI skill6;

    //[SerializeField] PlayerHud player1Hud;

    public void SetSkillName(List<Skill> skills)
    {

        skill1.text = skills[0].Skillbase.Name;
        

    }



    void Start()
    {

    }




    void Update()
    {

    }
}
