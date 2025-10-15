using UnityEngine;

//敵が線を引くメソッド(Pointにアタッチする)
public class EnemyDraw : MonoBehaviour
{
    [SerializeField] BattleSystem battleSystem;

    LineRenderer lineRenderer;
    //Transform startPosition;

    [SerializeField] Transform Enemy1Point; //絶対自分のTrasformを取得することになるから2回取得することになって
    [SerializeField] Transform Enemy2Point;//違う気がする
    [SerializeField] Transform Enemy3Point;

    //[SerializeField] Transform[] PlayerPoint = new Transform[3];

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

    private void Update()
    {
        //リセットするターンではないなら何もしない
        if (battleSystem.CurrentBState == BattleState.WaitNextTurn)
        {
            lineRenderer.positionCount = 0;
            posCount = 0;
        }

       
        

    }



    //死んでたら描かないという仕様にしないと
    public void DrawEnemy()
    {
        startPos = new Vector3(transform.position.x, transform.position.y - 0.4f, fixedDrawZ);//線の書き始める座標、少し下から
        AddLine(startPos);//初期地点
        targetPoint = RandomPoint();//ランダムに選んだ相手をターゲットに
        Vector3 direction = (targetPoint - startPos).normalized;//ベクトル

        while (newPoint.y >= targetPoint.y)//newPointのy座標がtargetPointのy座標より下回るまで
        {
            newPoint = lastAddPoint + direction * 0.1f;//最後に加えた点から0.1ベクトル分足した地点に次の点を
            AddLine(newPoint);
        }
    }

    //ランダムに目標相手を選んで、座標を取得   
    Vector3 RandomPoint()
    {
        //生きているplayerのgameObjの要素のAlivePPoint
        int count = Random.Range(0, battleSystem.AlivePPoint.Count);//から要素数から0までの数字を取得   
        Transform point = battleSystem.AlivePPoint[count].transform;//ランダムに選ばれた要素番号のtrasformを取得
        Vector3 targetPos = new Vector3( point.position.x,point.position.y,fixedDrawZ);//それの座標取得
        return targetPos;

        //int length = Random.Range(0, PlayerPoint.Length);
        //Transform Point = PlayerPoint[length];
        //Vector3 targetPos = new Vector3(Point.position.x, Point.position.y, fixedDrawZ);
        //return targetPos;
    }

    //線を引くメソッド(点)
    void AddLine(Vector3 point)
    {
        point.z = fixedDrawZ;
        lineRenderer.positionCount = posCount + 1;//繰り返す度に点を増やしていく
        lineRenderer.SetPosition(posCount, point); //引数に入れた座標に点を置く
        posCount++;
        lastAddPoint = point;//今加えた点を最後に加えた点に
    }



}
