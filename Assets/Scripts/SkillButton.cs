using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

//実際に押すSkillのスクリプト
public class SkillButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{


    TextMeshProUGUI text;

    [SerializeField] BattleSystem battleSystem;
    [SerializeField] DrawLine player1;
    [SerializeField] DrawIntelligence intelligence;
    [SerializeField] TextMeshProUGUI instruction;





    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    //Skillにマウスが触れたら
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.yellow;//文字を黄色に

        //Skillの内容をInstructionに出す
        Set();



    }

    //Skillからマウスが離れたら
    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.black;//文字を黒に戻す

        //スキルの内容を空白にする

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DrawLine();
    }

    //引数になにか
    public void DrawLine()//あとでメソッド名変更
    {


        //player1のDrowLineを起動
        player1.enabled = true;

        //どのスキルをクリックしたかによって識別変数を変えて、クリックしたスキルの情報を覚えておく。
        switch (gameObject.name)
        {
            case ("Skill (1)"):
                intelligence.Number = 1;
                break;
            case ("Skill (2)"):
                intelligence.Number = 2;
                break;
            case ("Skill (3)"):
                intelligence.Number = 3;
                break;
            case ("Skill (4)"):
                intelligence.Number = 4;
                break;
            case ("Skill (5)"):
                intelligence.Number = 5;
                break;
            case ("Skill (6)"):
                intelligence.Number = 6;
                break;

        }


    }

    //カーソルを合わせると対応したスキルの情報を出すメソッド
    void Set()
    {
        switch (gameObject.name)
        {
            case ("Skill (1)"):
                instruction.text = intelligence.SkillDescriptions[0];
                break;
            case ("Skill (2)"):
                instruction.text = intelligence.SkillDescriptions[1];
                break;
            case ("Skill (3)"):
                instruction.text = intelligence.SkillDescriptions[2];
                break;
            case ("Skill (4)"):
                instruction.text = intelligence.SkillDescriptions[3];
                break;
            case ("Skill (5)"):
                instruction.text = intelligence.SkillDescriptions[4];
                break;
            case ("Skill (6)"):
                instruction.text = intelligence.SkillDescriptions[5];
                break;

        }
    }





}








