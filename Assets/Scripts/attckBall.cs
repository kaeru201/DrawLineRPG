using System.Collections;
using UnityEngine;

//攻撃するボールにアタッチするクラス
//インスタンス化したら線にそって動く
public class AttckBall : MonoBehaviour
{
    LineRenderer lineRenderer;

    //[SerializeField]  BattleSystem battleSystem;

    Vector3 lastAddPos;//最後に加えて点

    public int Power { get; set; }
    public int PenetionPower { get; set; }
    public float Speed { get; set; }




    void Start()
    {
        lineRenderer = transform.parent.GetComponent<LineRenderer>();
        lastAddPos = lineRenderer.GetPosition(0);
        Speed = 1 / Speed;//Speedが大きければ大きいほどボールを速く
        StartCoroutine(MoveBall());
    }


    void Update()
    {


    }

    IEnumerator MoveBall()
    {
        // ok = false;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {

            Vector3 nextPos = lineRenderer.GetPosition(i);
            transform.position = Vector3.Lerp(lastAddPos, nextPos, 0.5f);
            yield return new WaitForSeconds(Speed);
            lastAddPos = nextPos;

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

        //もし相手が敵のBallだったら
        else if (collision.gameObject.CompareTag("EnemyBall"))
        {
            EnemyBall enemyPenetion = collision.gameObject.GetComponent<EnemyBall>();

            //お互いの貫通力を見て低い方は消える、同じ場合はどちらも消える
            if (PenetionPower <= enemyPenetion.PenetionPower)
            {
                Destroy(gameObject);
            }
        }
    }


}
