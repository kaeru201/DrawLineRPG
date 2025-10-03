using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
   

    public List<int> skill;
    

    [SerializeField] BattleSystem battleSystem;
    [SerializeField] DrawLine player1;

   
    public void DrowLine()
    {
        //player1のDrowLineを起動
        player1.enabled = true;
        player1.MaxLineRange = skill[1];
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
    //}



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //iを押したらiのレンジを参照して線を引く(DrawLineクラス起動)
       
        
    }
}
