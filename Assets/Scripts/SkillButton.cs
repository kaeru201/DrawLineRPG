using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;

public class SkillButton : MonoBehaviour
{


    //public List<int> skill;

  

    [SerializeField] BattleSystem battleSystem;
    [SerializeField] DrawLine player1;
    [SerializeField] DrawIntelligence intelligence;


    

    //引数になにか
    public void DrowLine()
    {
        //player1のDrowLineを起動
        player1.enabled = true;

        switch (gameObject.name)
        {
            case ("Skill (1)"):
                player1.MaxLineRange = intelligence.Skill[0];
                break;
            case ("Skill (2)"):
                player1.MaxLineRange = intelligence.Skill[1];
                break;
            case ("Skill (3)"):
                player1.MaxLineRange = intelligence.Skill[2];
                break;
            case ("Skill (4)"):
                player1.MaxLineRange = intelligence.Skill[3];
                break;
            case ("Skill (5)"):
                player1.MaxLineRange = intelligence.Skill[4];
                break;
            case ("Skill (6)"):
                player1.MaxLineRange = intelligence.Skill[5];
                break;

        }




        //player1.MaxLineRange = skill[1];
    }

    //合ってるか分からないけど
    //もし押したのがスキルボタン1なら配列0番目のMaxLineRageの値を代入
    //private void OnMouseDown()
    //{
    //   if(skillButton1)
    //    {
    //        int x = Skill[0];
    //    }
    //    if (skillButton2)
    //    {
    //        int x = skill[1];
    //    }





}
