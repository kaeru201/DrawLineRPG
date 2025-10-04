using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SkillSelection : MonoBehaviour

{
    List<int> range;

    [SerializeField] List<TextMeshProUGUI> skill;

    [SerializeField] SkillButton skillButton;

    [SerializeField] DrawIntelligence intelligence;
   

    //スキルの情報を入れるメソッド
    public void SetSkill(List<Skill> skills)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            
            
                skill[i].text = "・" + skills[i].Skillbase.Name;

            // skillButton.skill[i]  = skills[i].Skillbase.MaxLineRange; 

            intelligence.SkillRange[i] = skills[i].Skillbase.MaxLineRange;

            intelligence.SkillDescription[i] = skills[i].Skillbase.Description;    
            

        }
    }

    


    void Start()
    {

    }




    void Update()
    {

    }
}
