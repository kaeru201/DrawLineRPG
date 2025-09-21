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
        //最初にスタートステートに
        state = BattleState.Start;
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
        state = BattleState.Action;


        Debug.Log("コマンド選択");
        //コマンド選択UIを表示してコマンド選択

        //プレイヤーがコマンドを選択し終えたらResult
        
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
