using System.Collections;
using UnityEngine;


//敵のプレハブ化されたBallにアタッチするクラス
public class EnemyBall : MonoBehaviour
{
    LineRenderer lineRenderer;

    Vector3 lastAddPos;//最後に加えた点

    internal SkillType SkillType{ get; set; }
    public int Power { get; set; }
    public int PenetionPower { get; set; }
    public float Speed { get; set; }
    

    void Start()
    {
        lineRenderer = transform.parent.GetComponent<LineRenderer>();
        lastAddPos = lineRenderer.GetPosition(0);//初期配置
        Speed = 0.5f / Speed;//Speedが大きければ大きいほどボールを速く
        StartCoroutine(MoveBall());
    }

    IEnumerator MoveBall()
    {
        //lineRendererが置いた点の数だけ繰り返す
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 nextPos = lineRenderer.GetPosition(i);
            transform.position = Vector3.Lerp(lastAddPos, nextPos, 0.5f);//徐々に次の点から最後に加えた点に移動
            yield return new WaitForSeconds(Speed);//スピード秒だけ待つ
            lastAddPos = nextPos;//現在地点を最後に加えた点に

            if (i == lineRenderer.positionCount - 1) 
            {
               // Destroy(gameObject);

            }
        }
        yield break;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //もし当たった相手がPointだったら
        if (collision.gameObject.CompareTag("Point"))
        {
            //もしスキルタイプがAttackなら
            if(SkillType == SkillType.Attack)
            {
                //当たった相手にダメージ
                GameObject parentObj = collision.transform.parent.gameObject;
                BattleUnit battleUnit = parentObj.GetComponent<BattleUnit>();
                battleUnit.Unit.Hp = battleUnit.Unit.Hp - Power;
            }
            //もしスキルタイプがHealなら
            else if (SkillType == SkillType.Heal)
            {
                //当たった相手に回復
                GameObject parentObj = collision.transform.parent.gameObject;
                BattleUnit battleUnit = parentObj.GetComponent<BattleUnit>();
                battleUnit.Unit.Hp = battleUnit.Unit.Hp + Power;
            }
            //もしスキルタイプがSupportなら
            else if (SkillType == SkillType.Support)
            {
                Debug.Log("今後追加予定!!");
            }

            //pointに当たった後消える
            Destroy(gameObject);
        }

        //playerのボールが当たった時の処理はAttackBall側で行うためこちらには無し

        //もし相手がPlayerのBallだったら
        //else if (collision.gameObject.CompareTag("PlayerBall"))
        //{
        //   AttckBall enemyPenetion = collision.gameObject.GetComponent<AttckBall>();

        //    //お互いの貫通力を見て低い方は消える、同じ場合はどちらも消える
        //    if (PenetionPower <= enemyPenetion.PenetionPower)
        //    {
        //       // Destroy(gameObject);
        //    }
        //}

    }

}



