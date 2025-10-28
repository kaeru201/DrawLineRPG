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
    float fixedDrawZ = 0f;
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
            newPoint = transform.position;
        }

    }


    //BattleSystenが発動　敵が線を描くメソッド
    public void DrawEnemy(SkillType skillType)
    {
        startPos = new Vector3(transform.position.x, transform.position.y - 0.5f, fixedDrawZ);//線の書き始める座標、少し下から(自分のPointに当たらないため)
        AddLine(startPos);//初期地点
        targetPoint = RandomPoint(skillType);//ランダムに選んだ相手をターゲットに
        Vector3 direction = (targetPoint - startPos).normalized;//ベクトル

        //もしスキルタイプがAttackなら
        if(skillType == SkillType.Attack)
        {
            while (newPoint.y >= targetPoint.y)//newPointのy座標がtargetPointのy座標より下回るまで
            {
                newPoint = lastAddPoint + direction * 0.1f;//最後に加えた点から0.1ベクトル分足した地点に次の点を
                AddLine(newPoint);
            }
        }
        //それ以外なら
        else
        {
            while (newPoint.y <= targetPoint.y)//newPointのy座標がtargetPointのy座標より上回るまで　
            {
                newPoint = lastAddPoint + direction * 0.1f;//最後に加えた点から0.1ベクトル分足した地点に次の点を
                AddLine(newPoint);
            }
        }
        
    }

    //ランダムに目標相手を選んで、座標を取得   
    Vector3 RandomPoint(SkillType skillType)
    {
        //もしスキルタイプがAttackならplayerのランダムな相手の座標を得る
        if(skillType == SkillType.Attack)
        {
            //生きているplayerのgameObjの要素のAlivePPoint
            int count = Random.Range(0, battleSystem.AlivePlayers.Count);//から要素数から0までの数字を取得   
            Transform point = battleSystem.AlivePlayers[count].transform;//ランダムに選ばれた要素番号のtrasformを取得
            Vector3 targetPos = new Vector3(point.position.x, point.position.y, fixedDrawZ);//それの座標取得
            return targetPos;
        }
        //もしスキルタイプがHealならenemyのランダムな相手の座標を得る
        else if (skillType == SkillType.Heal)
        {
            int count = Random.Range(0, battleSystem.AliveEnemies.Count);
            Transform point = battleSystem.AliveEnemies[count].transform;
            Vector3 targetPos = new Vector3(point.position.x, point.position.y, fixedDrawZ);
            return targetPos;
        }
        else
        {
            Debug.Log("supportは実装途中");
            return transform.position;
        }
               

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

    //打ったスキルによって線の色を変更メソッド(
   　public void LineColor(SkillType skillType)
    {
        if (skillType == SkillType.Attack)
        {
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.red;
        }
        else if (skillType == SkillType.Heal)
        {
            lineRenderer.startColor = Color.green;
            lineRenderer.endColor = Color.green;
        }
        else
        {
            lineRenderer.startColor = Color.blue;
            lineRenderer.endColor = Color.blue;
        }
    }

}
