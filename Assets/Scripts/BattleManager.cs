using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

//バトルの状態を分ける列挙型
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

    
    

    //どのオブジェクトが線を引くか分ける変数
    [SerializeField] DrawLine plyaer1Point;
    [SerializeField] DrawLine plyaer2Point;
    [SerializeField] DrawLine plyaer3Point;

    public BattleState State { get => state; set => state = value; }
   

    //void Start()
    //{
    //    //最初にスタートステートに
    //    State = BattleState.StartTurn;
    //    SetupBattle();

    //}

    //public void SetupBattle()
    //{

    //    Debug.Log("戦闘開始");

    //    //味方、敵を配置


    //    StartCoroutine(PlayerAction());

    //}

    //IEnumerator PlayerAction()
    //{
    //    State = BattleState.ActionTurn;

    //    //if() もし全員が行動し終わったら
    //    //{
    //        //敵の行動　Debug.Log("敵の行動)
    //    //}

    //    //if(player) //行動していない生きているPlayerがいるなら

    //    if(clickSkill)
    //    {
    //        if (clickSkillCount == 0)
    //        {
    //            StartCoroutine(Draw(1));
    //            clickSkill = false;
    //            clickSkillCount++;
    //        }
    //        if(clickSkillCount == 1)
    //        {
    //            StartCoroutine(Draw(2));
    //            clickSkill = false;
    //            clickSkillCount++;
    //        }
    //        if (clickSkillCount == 2)
    //        {
    //            StartCoroutine (Draw(3));
    //            clickSkill = false;
    //            clickSkillCount++;
    //        }
            
    //    }

    //    //if() もしアイテムを押したら


    //     StartCoroutine(BattleResult());

    //    yield break;

    //}

    //IEnumerator BattleResult()
    //{
    //    State = BattleState.ResultTurn;

    //    //ボールが線を沿って行く

    //    //もし味方が全滅していたらStateをLoseに

    //    //もし敵が全滅していたらStateをWinに

    //    //もしどちらも全滅していなかったら
    //    //PlayAction()



    //    yield break;
    //}



    //　IEnumerator Draw(int player)
    //{
    //    if (player != null)
    //    {
    //        //skillがクリックされるまで待つ

    //        //線を書く
            
    //        yield break;
    //    }
    //    else yield break;

        
    //}

    //void Draw2()
    //{

    //}

    //void Draw3()
    //{

    //}


    //void Update()
    //{

    //}

}
