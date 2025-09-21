using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public enum BattleState

{
    Start,
    Action,
    Result,
    Win,
    Lose,

}

public class BattleManager : MonoBehaviour
{
   
   public BattleState state;

   

   


    void Start()
    {
        //�ŏ��ɃX�^�[�g�X�e�[�g��
        state = BattleState.Start;
       SetupBattle();

    }

    public void SetupBattle()
    {

        Debug.Log("�퓬�J�n");

        //�����A�G��z�u

        
        PlayerAction();
                 
    }

    void PlayerAction()
    {
        state = BattleState.Action;


        Debug.Log("�R�}���h�I��");
        //�R�}���h�I��UI��\�����ăR�}���h�I��

        //�v���C���[���R�}���h��I�����I������Result
        
        StartCoroutine(BattleResult());

    }

    IEnumerator BattleResult()
    {
        state = BattleState.Result;
        

        yield break;
    }
    

    



    void Update()
    {

    }

}
