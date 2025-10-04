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

    int number;//なんの技が選ばれたかを判別する変数

    public int Number { get => number; set => number = value; }

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
    public void DrawLine()
    {
        //player1のDrowLineを起動
        player1.enabled = true;

        switch (gameObject.name)
        {
            case ("Skill (1)"):
                player1.MaxLineRange = intelligence.SkillRange[0];
                //攻撃力、貫通力も持っていたい。
                number = 1;
                
                break;
            case ("Skill (2)"):
                player1.MaxLineRange = intelligence.SkillRange[1];

                number = 2;
                break;
            case ("Skill (3)"):
                player1.MaxLineRange = intelligence.SkillRange[2];
                break;
            case ("Skill (4)"):
                player1.MaxLineRange = intelligence.SkillRange[3];
                break;
            case ("Skill (5)"):
                player1.MaxLineRange = intelligence.SkillRange[4];
                break;
            case ("Skill (6)"):
                player1.MaxLineRange = intelligence.SkillRange[5];
                break;

        }


    }

    void Set()
    {
        switch (gameObject.name)
        {
            case ("Skill (1)"):
                instruction.text = intelligence.SkillDescription[0];
                break;
            case ("Skill (2)"):
                instruction.text = intelligence.SkillDescription[1];
                break;
            case ("Skill (3)"):
                instruction.text = intelligence.SkillDescription[2];
                break;
            case ("Skill (4)"):
                instruction.text = intelligence.SkillDescription[3];
                break;
            case ("Skill (5)"):
                instruction.text = intelligence.SkillDescription[4];
                break;
            case ("Skill (6)"):
                instruction.text = intelligence.SkillDescription[5];
                break;

        }
    }





}








