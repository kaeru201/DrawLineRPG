using System.Collections;
using UnityEngine;


//敵のプレハブ化されたBallにアタッチするクラス
public class EnemyBall : MonoBehaviour
{

    BattleSystem battleSystem;
    LineRenderer lineRenderer;

    Vector3 lastAddPos;//最後に加えた点

    public string SkillName { get; set; }
    public SkillType SkillType { get; set; }
    public int Power { get; set; }
    public int PenetionPower { get; set; }
    public float Speed { get; set; }

    public int UnitNum { get; set; }


    void Start()
    {
        lineRenderer = transform.parent.GetComponent<LineRenderer>();
        lastAddPos = lineRenderer.GetPosition(0);//初期配置
        Speed = 0.5f / Speed;//Speedが大きければ大きいほどボールを速く
        StartCoroutine(MoveBall());
        battleSystem.AliveBalls.Add(gameObject);//AliveBallリストにこのオブジェクトを追加
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

            if (i == lineRenderer.positionCount - 1)//一応最後まで何にも当たらなかったら削除
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

            //当たった相手が生きていたら
            if (battleUnit.Unit.HP > 0)
            {
                //もしスキルタイプがAttackなら
                if (SkillType == SkillType.Attack)
                {
                    //当たった相手にダメージ                
                    int damage = battleSystem.Damage(Power, UnitNum, battleUnit);//battleSystemのDamageメソッドを発動させてダメージ計算をする
                    battleUnit.Unit.HP -= damage;//計算した値分Hpをマイナス
                    battleUnit.TakeDamage(damage);//何ダメ―ジだったかを当たった敵の場所に表示
                    battleSystem.dialog.AddDialog(battleUnit.Unit.UnitBase.Name + "は" + damage + " ダメージ受けた");//ダイヤログで何ダメ与えたかを流す
                    SoundManager.instance.PlaySE(SEType.Damage);//ダメージ音

                }
                //もしスキルタイプがHealなら
                else if (SkillType == SkillType.Heal)
                {
                    //当たった相手に回復
                    int heal = Power;
                    battleUnit.Unit.HP += heal;//Hpをプラス
                    battleUnit.TakeHeal(heal);//何回復だったかを当たった敵の場所に表示
                    battleSystem.dialog.AddDialog(battleUnit.Unit.UnitBase.Name + "は" + heal + "回復した");//ダイヤログでどれだけ回復したかを流す
                    SoundManager.instance.PlaySE(SEType.Heal);//回復音                                                                                 
                }
                //もしスキルタイプがSupportなら
                else if (SkillType == SkillType.Support)
                {
                    Debug.Log("今後追加予定!!");
                }

                battleSystem.AliveBalls.Remove(gameObject);//AliveBallsリストからこのオブジェクトの要素を削除

                Destroy(gameObject);//pointに当たった後消える
            }
        }


    }

    public void SetBattleSystem(BattleSystem system)
    {
        battleSystem = system;
    }

}



