using System.Collections;
using UnityEngine;

//攻撃するボールにアタッチするクラス
//インスタンス化したら線にそって動く
public class AttckBall : MonoBehaviour
{
    BattleSystem battleSystem;

    LineRenderer lineRenderer;

    //[SerializeField]  BattleSystem battleSystem;

    Vector3 lastAddPos;//最後に加えた点

    internal SkillType SkillType { get; set; }
    public int Power { get; set; }
    public int PenetionPower { get; set; }
    public float Speed { get; set; }

    public int UnitNum { get; set; }


    void Start()
    {
        lineRenderer = transform.parent.GetComponent<LineRenderer>();
        lastAddPos = lineRenderer.GetPosition(0);
        Speed = 0.5f / Speed;//Speedが大きければ大きいほどボールを速く
        battleSystem.AliveBalls.Add(gameObject);//AliveBallリストにこのオブジェクトを追加
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
                battleSystem.AliveBalls.Remove(gameObject);//AliveBallsリストからこのオブジェクトの要素を削除
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
            GameObject parentObj = collision.transform.parent.gameObject;//当たった相手の親オブジェクト
            BattleUnit battleUnit = parentObj.GetComponent<BattleUnit>();//のBattleUnitスクリプトを取得

            //当たった相手の体力が0以上なら(復活魔法などを使いたくなったらどうするか)
            if (battleUnit.Unit.Hp > 0)
            {
                //もしスキルタイプがAttackなら
                if (SkillType == SkillType.Attack)
                {
                    //当たった相手にダメージ               
                    int damage = battleSystem.Damage(Power, UnitNum, battleUnit);//battleSystemのDamageメソッドを発動させてダメージ計算をする
                    battleUnit.Unit.Hp = battleUnit.Unit.Hp - damage;//計算した値分Hpをマイナス
                }

                //もしスキルタイプがHealなら
                else if (SkillType == SkillType.Heal)
                {
                    //当たった相手に回復
                    battleUnit.Unit.Hp = battleUnit.Unit.Hp + Power;//Hpをプラス
                }

                // もしスキルタイプがSupportなら
                else if (SkillType == SkillType.Support)
                {
                    Debug.Log("今後追加予定!!");
                }
                //pointに当たった後消える
                battleSystem.AliveBalls.Remove(gameObject);//AliveBallsリストからこのオブジェクトの要素を削除
                Destroy(gameObject);
            }
            
        }

        //もし相手がEnemyのBallだったら
        else if (collision.gameObject.CompareTag("EnemyBall"))
        {

            EnemyBall enemyPenetion = collision.gameObject.GetComponent<EnemyBall>();

            //ぶつかった相手より貫通力が低いなら自分を消す
            if (PenetionPower < enemyPenetion.PenetionPower)
            {
                battleSystem.AliveBalls.Remove(gameObject);//AliveBallsリストからこのオブジェクトの要素を削除
                Destroy(gameObject);
            }
            //ぶつかった相手より貫通力が高いなら相手を消す
            else if (PenetionPower > enemyPenetion.PenetionPower)
            {
                battleSystem.AliveBalls.Remove(collision.gameObject);//AliveBallsリストから当たった相手のオブジェクトの要素を削除
                Destroy(collision.gameObject);
            }
            //ぶつかった相手と貫通力が一緒ならどちらも消す
            else if (PenetionPower == enemyPenetion.PenetionPower)
            {
                battleSystem.AliveBalls.Remove(gameObject);//AliveBallsリストからこのオブジェクトの要素を削除
                Destroy(gameObject);

                battleSystem.AliveBalls.Remove(collision.gameObject);//AliveBallsリストから当たった相手のオブジェクトの要素を削除
                Destroy(collision.gameObject);
            }
        }
    }

    //インスタンス化した時にBattaleSystemを参照させるメソッド(InstanceBallで発動させる）
    public void SetBattleSystem(BattleSystem system)
    {
        battleSystem = system;
    }


}
