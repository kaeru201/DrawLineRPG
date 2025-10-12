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

    int posCount;

    //Transform[] test = new Transform[3];

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        startPosition = GetComponent<Transform>();

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;


    }


    //死んでたら描かないという仕様にしないと
    public void DrawEnemy()
    {
        Transform targetPos = RandomPoint();
        lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y -0.3f, 8f));
        lineRenderer.SetPosition(1, new Vector3(targetPos.position.x, targetPos.position.y, 8f));
    }

    Transform RandomPoint()//ｘ、ｙを適切な名前に治す
    {
        int length = Random.Range(0, PlayerPoint.Length);
        Transform Point = PlayerPoint[length];
        return Point;
    }


}
