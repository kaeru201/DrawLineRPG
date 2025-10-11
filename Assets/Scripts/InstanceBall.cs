using UnityEngine;

//player、enemyどちらもアタッチする、ballをインスタンスするクラス　　どうやって生きてやつだけうつか
public class InstanceBall : MonoBehaviour
{
    [SerializeField] GameObject objPrefab;

    [SerializeField] BattleSystem battleSystem;

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
                    
                    GameObject test = Instantiate(objPrefab, transform.position, Quaternion.identity);//インスタンス
                    test.transform.parent = gameObject.transform;

                    //player1の情報を入れる

                    p1Rdy = false;
                }


                break;
            case "Player2Point":
                if(p2Rdy)
                {
                    GameObject test2 = Instantiate(objPrefab, transform.position, Quaternion.identity);
                    test2.transform.parent = gameObject.transform;

                    //player2の情報を入れる

                    p2Rdy = false;
                }

                break;
            case "Player3Point":
               

                if (p3Rdy)
                {
                    
                    GameObject test3 = Instantiate(objPrefab, transform.position, Quaternion.identity);
                    test3.transform.parent = gameObject.transform;

                    //player3の情報を入れる

                    p3Rdy = false;
                }

                break;


        }



    }
}
