using UnityEngine;

//敵が線を引くメソッド(Pointにアタッチする)
public class EnemyDraw : MonoBehaviour
{
    [SerializeField] BattleSystem battleSystem;//いらんかも

    LineRenderer lineRenderer;
    Transform startPosition;

    [SerializeField] Transform Enemy1Point; //絶対自分のTrasformを取得することになるから2回取得することになって
    [SerializeField] Transform Enemy2Point;//違う気がする
    [SerializeField] Transform Enemy3Point;

    [SerializeField] Transform[] PlayerPoint = new Transform[3];

    //Transform[] test = new Transform[3];

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
       startPosition = GetComponent<Transform>();

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;


    }

    //線を一気に描くのではなく、プレイヤーのように徐々に描いてほしい
    //DrawLineと違って最終目的地がPlayerPointで決まっている
    void Update()
    {
        if (battleSystem.CurrentBState != BattleState.EnemyTurn) return;

        //Transform y = RandomPoint();
        //lineRenderer.SetPosition(0, transform.position);
        //lineRenderer.SetPosition(1, y.position);
        battleSystem.CurrentBState = BattleState.BattleTurn;//これだと一人しかかけないから用調整

    }
    //死んでたら描かないという仕様にしないと
    public void DrawEnemy()
    {
        Transform y = RandomPoint();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, y.position);
    }

    Transform RandomPoint()//ｘ、ｙを適切な名前に治す
    {
        int x = Random.Range(0, PlayerPoint.Length);
        Transform Point = PlayerPoint[x];
        return Point;
    }

    //Transform Test()
    //{
    //    int length = Random.Range(0, test.Length);
    //    Transform ttest = test[length];
    //    return ttest;
    //}

}
