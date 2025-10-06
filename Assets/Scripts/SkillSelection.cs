using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SkillSelection : MonoBehaviour

{
    List<int> range;

    [SerializeField] List<TextMeshProUGUI> skillNames;

    [SerializeField] SkillButton skillButton;

    [SerializeField] DrawIntelligence intelligence;


    //スキルの情報を入れるメソッド
    public void SetSkill(List<Skill> skills)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            if (i < skills.Count)
            {
                //スキル選択画面のテキストを対応したスキル名に変更
                skillNames[i].text = "・" + skills[i].Skillbase.Name;
            }
            else
            {
                skillNames[i].text = ".";
            }

            // スキルの情報をDrawIntelligenceの配列の変数に代入
            intelligence.SkillRanges[i] = skills[i].Skillbase.MaxLineRange;

            intelligence.SkillDescriptions[i] = skills[i].Skillbase.Description;

            intelligence.SkillTypes[i] = skills[i].Skillbase.SkilType;

            intelligence.SkillPowers[i] = skills[i].Skillbase.Power;

            intelligence.SkillPenetionPowers[i] = skills[i].Skillbase.PenetrationPower;
        }
    }




    void Start()
    {

    }




    void Update()
    {

    }
}
