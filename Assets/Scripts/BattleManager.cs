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
        //最初にスタートステートに
        State = BattleState.StartTurn;
       SetupBattle();

    }

    public void SetupBattle()
    {

        Debug.Log("戦闘開始");

        //味方、敵を配置

        
        PlayerAction();
                 
    }

    void PlayerAction()
    {
        State = BattleState.ActionTurn;

        

        Debug.Log("コマンド選択");
        //コマンド選択UIを表示してコマンド選択

        //プレイヤーがコマンドを選択し終えたらResult
        
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
