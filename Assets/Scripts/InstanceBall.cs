using UnityEngine;

//player、enemyどちらもアタッチする、ballをインスタンスするクラス　　どうやって生きてやつだけうつか
public class InstanceBall : MonoBehaviour
{
    [SerializeField] GameObject objPrefab;

    [SerializeField] BattleSystem battleSystem;
    [SerializeField] DrawIntelligence intelligence;

    bool p1Rdy = true;
    bool p2Rdy = true;
    bool p3Rdy = true;

    void Start()
    {

    }


    void Update()
    {
        if (battleSystem.CurrentBState != BattleState.BattleTurn) return;

        switch (gameObject.name)
        {
            case "Player1Point":
                if (p1Rdy)
                {
                    //技の攻撃回数分インスタンス
                    for (int i = 0; i < intelligence.player1NumAttacks; i++)
                    {
                        GameObject player1Ball = Instantiate(objPrefab, transform.position, Quaternion.identity);//インスタンス
                        player1Ball.transform.parent = gameObject.transform;

                        //player1の情報を入れる
                        AttckBall script = player1Ball.GetComponent<AttckBall>();
                        script.Power = intelligence.player1Power;
                        script.PenetionPower = intelligence.player1PenetionPower;
                        script.Speed = intelligence.player1Speed;

                    }
                    p1Rdy = false;
                }


                break;
            case "Player2Point":
                if (p2Rdy)
                {
                    //攻撃回数分インスタンス
                    for (int i = 0; i < intelligence.player2NumAttacks; i++)
                    {

                        GameObject player2Ball = Instantiate(objPrefab, transform.position, Quaternion.identity);
                        player2Ball.transform.parent = gameObject.transform;

                        //player2の情報を入れる
                        AttckBall script = player2Ball.GetComponent<AttckBall>();
                        script.Power = intelligence.player2Power;
                        script.PenetionPower = intelligence.player2PenetionPower;
                        script.Speed = intelligence.player2Speed;

                    }
                    p2Rdy = false;
                }

                break;
            case "Player3Point":


                if (p3Rdy)
                {
                    //攻撃回数分インスタンス
                    for (int i = 0; i < intelligence.player3NumAttacks; i++)
                    {

                        GameObject player3Ball = Instantiate(objPrefab, transform.position, Quaternion.identity);
                        player3Ball.transform.parent = gameObject.transform;

                        //player3の情報を入れる
                        AttckBall script = player3Ball.GetComponent<AttckBall>();
                        script.Power = intelligence.player3Power;
                        script.PenetionPower = intelligence.player3PenetionPower;
                        script.Speed = intelligence.player3Speed;

                    }
                    p3Rdy = false;
                }

                break;


        }



    }

    //ボールをインスタンス化するメソッド
    void Attack()
    {

    }

}
