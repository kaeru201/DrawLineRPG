using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;


//実際に押すSkillのスクリプト
public class SkillButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{


    TextMeshProUGUI text;

    [SerializeField] BattleSystem battleSystem;
    [SerializeField] DrawIntelligence intelligence;
    [SerializeField] TextMeshProUGUI instruction;
    GameObject skillSelection;

    //bool player1Select = false;
    //bool player2Select = false;
    //bool player3Select = false;

    //bool player1Survival = true;  //とりあえずバグらないために置いてるけど、多分違う場所で宣言します
    //bool player2Survival = true;  //どうやって判別するかも一旦保留
    //bool player3Survival = true;　//でもSetUpでtrue + 戦闘中死んだらfalseにするのは確定


    void Start()
    {
        skillSelection = transform.parent.gameObject;

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
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        //もしplayer1Tuneなら
        if (battleSystem.CurrentBState == BattleState.Player1Turn)
        {

            skillSelection.SetActive(false);//SkillSelectionを停止
            DrawNumberSet();//どれを押したか
            intelligence.DrawIn(1);//線を描く
            //player2が生きているなら
            if (battleSystem.Player2Alive)
            {
                battleSystem.TurnCng(BattleState.Player2Turn);//BattleStetaをplayer2Turnに
            }
            //Player3が生きているなら
            else if (battleSystem.Player3Alive)
            {
                battleSystem.TurnCng(BattleState.Player3Turn);
            }
            //誰も生き残っていないなら
            else
            {
                battleSystem.TurnCng(BattleState.EnemyTurn);
            }


        }
        //もしplayer2Turnなら
        else if (battleSystem.CurrentBState == BattleState.Player2Turn)
        {


            skillSelection.SetActive(false);
            DrawNumberSet();
            intelligence.DrawIn(2);
            //Player3が生きているなら
            if (battleSystem.Player3Alive)
            {
                battleSystem.TurnCng(BattleState.Player3Turn);

            }
            //生き残っていないのなら
            else battleSystem.TurnCng(BattleState.EnemyTurn);


        }
        //もしplayer3Tuneなら
        else if (battleSystem.CurrentBState == BattleState.Player3Turn)
        {

            skillSelection.SetActive(false);
            DrawNumberSet();
            intelligence.DrawIn(3);
            //EnemyTurnに
            battleSystem.TurnCng(BattleState.EnemyTurn);

        }

    }



    //どのスキルをクリックしたかによって識別変数を変えて、クリックしたスキルの情報を覚えておメソッド
    public void DrawNumberSet()
    {
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








