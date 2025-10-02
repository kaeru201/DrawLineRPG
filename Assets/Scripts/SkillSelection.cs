using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SkillSelection : MonoBehaviour

{
    

    [SerializeField] List<TextMeshProUGUI> skill;

    [SerializeField] SkillButton skillButton;
   

    //スキルの情報を入れるメソッド
    public void SetSkill(List<Skill> skills)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            skill[i].text = "・" + skills[i].Skillbase.Name;

            skillButton.Skill[i]  = skills[i].Skillbase.MaxLineRange; 

           

    



           
        }
    }

    


    void Start()
    {

    }




    void Update()
    {

    }
}
