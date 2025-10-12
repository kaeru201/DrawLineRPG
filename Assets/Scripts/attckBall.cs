using System.Collections;
using UnityEngine;

//攻撃するボールにアタッチするクラス
//インスタンス化したら線にそって動く
public class AttckBall : MonoBehaviour
{
    LineRenderer lineRenderer;

    //[SerializeField]  BattleSystem battleSystem;

    Vector3 lastAddPos;//最後に加えた点

    public int Power { get; set; }
    public int PenetionPower { get; set; }
    public float Speed { get; set; }




    void Start()
    {
        lineRenderer = transform.parent.GetComponent<LineRenderer>();
        lastAddPos = lineRenderer.GetPosition(0);
        Speed = 0.5f / Speed;//Speedが大きければ大きいほどボールを速く
        StartCoroutine(MoveBall());
    }
       

    IEnumerator MoveBall()
    {
        // ok = false;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {

            Vector3 nextPos = lineRenderer.GetPosition(i);
            transform.position = Vector3.Lerp(lastAddPos, nextPos, 0.5f);//徐々に次の点から最後に加えた点に移動
            yield return new WaitForSeconds(Speed);//スピード秒だけ待つ
            lastAddPos = nextPos;//現在地点を最後に加えた点に

            //最後まで何もぶつからなかったら消える
            if (i == lineRenderer.positionCount - 1)
            {
                Destroy(gameObject);
            }
        }

        yield break;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //もし当たった相手がPointだったら
        if (collision.gameObject.CompareTag("Point"))
        {
            //当たった相手にダメージ

            //pointに当たった後消える
            Destroy(gameObject);
        }

        //もし相手がEnemyのBallだったら
        else if (collision.gameObject.CompareTag("EnemyBall"))
        {
           
            EnemyBall enemyPenetion = collision.gameObject.GetComponent<EnemyBall>();

            //ぶつかった相手より貫通力が低いなら自分を消す
            if (PenetionPower < enemyPenetion.PenetionPower)
            {
                Destroy(gameObject);
            }
            //ぶつかった相手より貫通力が高いなら相手を消す
            else if(PenetionPower > enemyPenetion.PenetionPower)
            {
                Destroy(collision.gameObject);
            }
            //ぶつかった相手と貫通力が一緒ならどちらも消す
            else if (PenetionPower == enemyPenetion.PenetionPower)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }


}
