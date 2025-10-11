using System.Collections;
using UnityEngine;

//攻撃するボールにアタッチするクラス
//インスタンス化したら線にそって動く
//もしpointに当たったら攻撃メソッドを発動()
public class AttckBall : MonoBehaviour
{
    LineRenderer lineRenderer;
    
   [SerializeField]  BattleSystem battleSystem;

    Vector3 lastAddPos;//最後に加えて点
    float speed  = 75 ; //仮の変数。本当は技のデータから代入してくる
    //bool ok = true;

    void Start()
    {
        lineRenderer = transform.parent.GetComponent<LineRenderer>();
        // lastAddPos = lineRenderer.GetPosition(0);
        speed = 1 /speed ;//Speedが大きければ大きいほどボールを速く
        StartCoroutine(MoveBall());
    }

   
    void Update()
    {
       
        //if (battleSystem.CurrentBState != BattleState.BattleTurn) return;
        //if (ok)
        //{
           
        //}
        //else return;
    }

    IEnumerator MoveBall()
    {
       // ok = false;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            
            
            Vector3 nextPos = lineRenderer.GetPosition(i);
            transform.position = Vector3.Lerp(lastAddPos, nextPos, 0.5f);
            yield return new WaitForSeconds(speed);
            lastAddPos = nextPos;
            
        }
       
        yield break;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Point"))
        {
            //当たった相手にダメージ

            //pointに当たった後消える
            Destroy(gameObject);
                }
        else if(collision.gameObject.CompareTag("Ball"))
        {
            //お互いの貫通力を見て低い方は消える、同じ場合はどちらも消える
            //if(this.gameObject.penetionPower <= collision.gameObject.penetionPower)
            //{
            //    Destroy(gameObject);
            //}
        }
    }
    

}
