using UnityEngine;

//敵が線を引くメソッド(Pointにアタッチする)
public class EnemyDraw : MonoBehaviour
{
    [SerializeField] BattleSystem battleSystem;//いらんかも

    LineRenderer lineRenderer;
    //Transform startPosition;

    [SerializeField] Transform Enemy1Point; //絶対自分のTrasformを取得することになるから2回取得することになって
    [SerializeField] Transform Enemy2Point;//違う気がする
    [SerializeField] Transform Enemy3Point;

    [SerializeField] Transform[] PlayerPoint = new Transform[3];

    int posCount;
    float fixedDrawZ = 8f;
    Vector3 startPos;

    Vector3 lastAddPoint;
    Vector3 newPoint;

    Vector3 targetPoint;         //仮

    //Transform[] test = new Transform[3];

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        //startPosition = GetComponent<Transform>();

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        


    }




    //死んでたら描かないという仕様にしないと
    public void DrawEnemy()
    {
        startPos = new Vector3(transform.position.x, transform.position.y - 0.3f, fixedDrawZ);//線の書き始める座標、少し下から
        lastAddPoint = startPos;
        AddLine(lastAddPoint);
        targetPoint = RandomPoint();

        Vector3 direction = (targetPoint - startPos).normalized;



        while ( newPoint.y >= targetPoint.y)//newPointのy座標がtargetPointのy座標より下回るまで
        {

            newPoint = lastAddPoint + direction * 0.1f;
            AddLine(newPoint);

        }
        
    }

    //ランダムに目標相手を選んで、座標を取得
    Vector3 RandomPoint()
    {
        int length = Random.Range(0, PlayerPoint.Length);
        Transform Point = PlayerPoint[length];
        Vector3 targetPos =new Vector3( Point.position.x,Point.position.y,fixedDrawZ);
        return targetPos;
    }

    //線を引くメソッド(点)
    void AddLine(Vector3 point)
    {
        point.z = fixedDrawZ;
        lineRenderer.positionCount = posCount + 1;//繰り返す度に点を増やしていく
        lineRenderer.SetPosition(posCount, point);//一つ前の点から次の点に線を書く
        posCount++;
        lastAddPoint = point;
    }



}
