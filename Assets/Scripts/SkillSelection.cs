using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillSelection : MonoBehaviour

{
    List<int> range;

    [SerializeField] GameObject[] skillNameObjs = new GameObject[6];
    [SerializeField] List<TextMeshProUGUI> skillNames;

    [SerializeField] SkillButton skillButton;
    [SerializeField] DrawIntelligence intelligence;


    //スキルの情報を入れるメソッド
    public void SetSkill(List<Skill> skills)
    {
        for (int j = 0; j < 6; j++)//一旦すべてのスキル名オブジェクトを停止
        {
            skillNameObjs[j].SetActive(false);
        }

        for (int i = 0; i < skills.Count; i++)//持ってるスキル分だけオブジェクトを起動して、スキル名変更
        {
            if (i < skills.Count)
            {
                skillNameObjs[i].SetActive(true);
                //スキル選択画面のテキストを対応したスキル名に変更
                skillNames[i].text = "・" + skills[i].Skillbase.Name;
            }
           
            //それぞれののi毎に記憶しておく
            intelligence.SkillRanges[i] = skills[i].Skillbase.MaxLineRange;

            intelligence.SkillDescriptions[i] = skills[i].Skillbase.Description;

            intelligence.SkillTypes[i] = skills[i].Skillbase.SkilType;

            intelligence.SkillPowers[i] = skills[i].Skillbase.Power;

            intelligence.SkillPenetionPowers[i] = skills[i].Skillbase.PenetrationPower;

            intelligence.SkillSpeed[i] = skills[i].Skillbase.Speed;

            intelligence.SkillNumAttacks[i] = skills[i].Skillbase.NumberAttacks;
        }
    }


}
