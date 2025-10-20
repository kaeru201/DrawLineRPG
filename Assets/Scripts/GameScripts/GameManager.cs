using UnityEngine;
using UnityEngine.SceneManagement;

//ゲーム全体を管理するスクリプト

public  enum GameState
{ 
    Adventure,
    InBattle,
    GemeOver,
    GameClear
}

public class GameManager : MonoBehaviour
{
    static GameState currentState;

    void Start()
    {
        currentState = GameState.Adventure;//まず現在のstetaをアドベンチャーに
    }

    
    void Update()
    {
        
    }

    //何かをきっかけに発動(一旦ボタン)
    //stateをInBattleにしてBattleSceneに移動
    public void BattleStart()
    {
        currentState = GameState.InBattle;
        SceneManager.LoadScene("BattleScene");//シーンをバトルシーンに

        //バトルするUnitをBattleSceneに
    }

}
