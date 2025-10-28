using UnityEngine;
using UnityEngine.SceneManagement;

//ゲーム全体を管理するスクリプト

public enum GameState
{
    SelectParty,
    Adventure,
    InBattle,
    GemeOver,
    GameClear
}

public class GameManager : MonoBehaviour
{
    static GameState currentState;

    public static bool lastBattle = false;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "TitleScene")
        {
            SoundManager.instance.PlayBGM(BGMType.Title);
        }

    }




    //battleSceneで勝ったら呼び出されるメソッド
    //敵選択画面シーンに移行するメソッド
    public void AdventureTurnStart()
    {

        currentState = GameState.Adventure;
        SoundManager.instance.PlayBGM(BGMType.Title);//BGMをTitleに
        SceneManager.LoadScene("AdventureScene");//シーンをアドベンチャーシーンに

    }
    //勝った後にそれがラストバトルだったらクリアシーンに移行するメソッド
    public void Clear()
    {
        currentState = GameState.GameClear;
        Debug.Log("ゲームクリア!");
        SceneManager.LoadScene("ClearScene");
        SoundManager.instance.PlaySE(SEType.BattleVictory);
        lastBattle = false;
    }

    //何かをきっかけに発動(一旦ボタン)
    //stateをInBattleにしてBattleSceneに移動
    public void BattleStart()
    {
        currentState = GameState.InBattle;
        SceneManager.LoadScene("BattleScene");//シーンをバトルシーンに

    }

}
