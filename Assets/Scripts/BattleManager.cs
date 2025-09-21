using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public enum BattleState

{
    StartTurn,
    ActionTurn,
    DrawLinTurn,
    ResultTurn,
    WinTurn,
    LoseTurn

}

public class BattleManager : MonoBehaviour
{

    [SerializeField] BattleState state;

    public BattleState State { get => state; set => state = value; }

    void Start()
    {
        //�ŏ��ɃX�^�[�g�X�e�[�g��
        State = BattleState.StartTurn;
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
        State = BattleState.ActionTurn;

        

        Debug.Log("�R�}���h�I��");
        //�R�}���h�I��UI��\�����ăR�}���h�I��

        //�v���C���[���R�}���h��I�����I������Result
        
        StartCoroutine(BattleResult());

    }

    IEnumerator BattleResult()
    {
        State = BattleState.ResultTurn;
        

        yield break;
    }
    

    



    void Update()
    {

    }

}
