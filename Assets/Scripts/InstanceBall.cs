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

    bool e1Rdy = true;
    bool e2Rdy = true;
    bool e3Rdy = true;

    void Start()
    {

    }


    void Update()
    {
        if(battleSystem.CurrentBState == BattleState.Player1Turn) //リセット　本当にUPdataに書くかは疑問
        {
            p1Rdy=true;
            p2Rdy=true;
            p3Rdy=true;
            e1Rdy=true;
            e2Rdy=true;
            e3Rdy=true;
        }

        else if (battleSystem.CurrentBState == BattleState.BattleTurn)
        {

            switch (gameObject.name)
            {
                case "Player1Point":
                    if (p1Rdy)
                    {
                        //技の攻撃回数分インスタンス
                        for (int i = 0; i < intelligence.playerNumAttacks[0]; i++)
                        {
                            GameObject player1Ball = Instantiate(objPrefab, transform.position, Quaternion.identity);//インスタンス
                            player1Ball.transform.parent = gameObject.transform;//生成したオブジェクトをこのオブジェクトの子にする

                            //player1の情報を入れる
                            AttckBall script = player1Ball.GetComponent<AttckBall>();
                            script.Power = intelligence.playerPowers[0];
                            script.PenetionPower = intelligence.playerPenetionPowers[0];
                            script.Speed = intelligence.playerSpeeds[0];

                        }
                        p1Rdy = false;
                    }


                    break;
                case "Player2Point":
                    if (p2Rdy)
                    {
                        //攻撃回数分インスタンス
                        for (int i = 0; i < intelligence.playerNumAttacks[1]; i++)
                        {

                            GameObject player2Ball = Instantiate(objPrefab, transform.position, Quaternion.identity);
                            player2Ball.transform.parent = gameObject.transform;

                            //player2の情報を入れる
                            AttckBall script = player2Ball.GetComponent<AttckBall>();
                            script.Power = intelligence.playerPowers[1];
                            script.PenetionPower = intelligence.playerPenetionPowers[1];
                            script.Speed = intelligence.playerSpeeds[1];

                        }
                        p2Rdy = false;
                    }

                    break;
                case "Player3Point":


                    if (p3Rdy)
                    {
                        //攻撃回数分インスタンス
                        for (int i = 0; i < intelligence.playerNumAttacks[2]; i++)
                        {

                            GameObject player3Ball = Instantiate(objPrefab, transform.position, Quaternion.identity);
                            player3Ball.transform.parent = gameObject.transform;

                            //player3の情報を入れる
                            AttckBall script = player3Ball.GetComponent<AttckBall>();
                            script.Power = intelligence.playerPowers[2];
                            script.PenetionPower = intelligence.playerPenetionPowers[2];
                            script.Speed = intelligence.playerSpeeds[2];

                        }
                        p3Rdy = false;
                    }

                    break;
                case "Enemy1Point":

                    if (e1Rdy)
                    {
                        
                        for (int i = 0; i < intelligence.enemyNumAttacks[0]; i++)
                        {
                            GameObject enemy1Ball = Instantiate(objPrefab, transform.position, Quaternion.identity);
                            enemy1Ball.transform.parent = gameObject.transform;

                            EnemyBall script = enemy1Ball.GetComponent<EnemyBall>();
                            script.Power = intelligence.enemyPowers[0];
                            script.PenetionPower = intelligence.enemyPenetionPowers[0];
                            script.Speed = intelligence.enemySpeeds[0];
                        }
                    }
                    e1Rdy = false;
                    break;

                case "Enemy2Point":
                    if (e2Rdy)
                    {
                        for (int i = 0; i < intelligence.enemyNumAttacks[1]; i++)
                        {
                            GameObject enemy2Ball = Instantiate(objPrefab, transform.position, Quaternion.identity);
                            enemy2Ball.transform.parent = gameObject.transform;

                            EnemyBall script = enemy2Ball.GetComponent<EnemyBall>();
                            script.Power = intelligence.enemyPowers[1];
                            script.PenetionPower = intelligence.enemyPenetionPowers[1];
                            script.Speed = intelligence.enemySpeeds[1];
                        }
                    }
                    e2Rdy = false;
                    break;

                case "Enemy3Point":
                    if (e3Rdy)
                    {
                        for (int i = 0; i < intelligence.enemyNumAttacks[2]; i++)
                        {
                            GameObject enemy3Ball = Instantiate(objPrefab, transform.position, Quaternion.identity);
                            enemy3Ball.transform.parent = gameObject.transform;

                            EnemyBall script = enemy3Ball.GetComponent<EnemyBall>();
                            script.Power = intelligence.enemyPowers[2];
                            script.PenetionPower = intelligence.enemyPenetionPowers[2];
                            script.Speed = intelligence.enemySpeeds[2];
                        }
                    }
                    e3Rdy = false;
                    break;
            }
        }
        else return;



    }

    

}
