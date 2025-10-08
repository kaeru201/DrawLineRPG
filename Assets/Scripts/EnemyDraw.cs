using UnityEngine;

//敵が線を引くメソッド(Pointにアタッチする)
public class EnemyDraw : MonoBehaviour
{
    [SerializeField] BattleSystem battleSystem;//いらんかも

    LineRenderer lineRenderer;
    Transform startPosition;

    [SerializeField] Transform Player1Point;
    [SerializeField] Transform Player2Point;
    [SerializeField] Transform Player3Point;

    [SerializeField] Transform Enemy1Point; //絶対自分のTrasformを取得することになるから2回取得することになって
    [SerializeField] Transform Enemy2Point;//違う気がする
    [SerializeField] Transform Enemy3Point;



    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        startPosition = GetComponent<Transform>();

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

       
    }

   
    void Update()
    {
        if (battleSystem.CurrentBState == BattleState.EnemyTurn)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, Player1Point.position);
        }
    }
}
