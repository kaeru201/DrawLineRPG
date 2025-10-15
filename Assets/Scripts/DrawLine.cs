using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


//pointにアタッチするスクリプト
//線を書くスクリプト
public class DrawLine : MonoBehaviour
{
    SkillBase skillBase;
    [SerializeField] BattleSystem battleSystem;

    [SerializeField] LineRenderer lineRenderer;
    Transform startPosition;

    [SerializeField] float maxLineRange;//DrawIntelligenceから値を代入
    int posCount;//
    float minMouseMove;
    [SerializeField] bool isDrawing = false;
    [SerializeField] bool ready = false;



    float currentLineRange;//現在の書いた長さ
    Vector3 lastAddPoint;//最後に追加した点を記憶しておく変数

    float fixedDrawZ = 8f; //z軸を固定

    public float MaxLineRange { get => maxLineRange; set => maxLineRange = value; }


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        startPosition = GetComponent<Transform>();

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

    }


    void Update()
    {
        if(battleSystem.CurrentBState == BattleState.WaitNextTurn)//できない
        {
            posCount = 0;
            lineRenderer.positionCount = 0;
        }

        //マウスのスクリーン座標をワールド座標に変換する
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, fixedDrawZ));

        //mousePosを枠から出ないように
        mousePos.x = Mathf.Clamp(mousePos.x, -28.28f, -14.733f);
        mousePos.y = Mathf.Clamp(mousePos.y, -2.279f, 2.307f);



        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;
            //初期化
            posCount = 0;
            lineRenderer.positionCount = 0;
            currentLineRange = 0;
            ready = false;
            //y軸は少し上からZ軸は適当
            AddLine(new Vector3(startPosition.position.x, startPosition.position.y + 0.5f, fixedDrawZ));

        }

        //左クリック押し続けている間かつisDrawがtrueなら
        if (Input.GetMouseButton(0) && isDrawing)
        {
            if (currentLineRange >= MaxLineRange)
            {

                isDrawing = false;
                return;
            }

            //最後点と今のマウスの位置の差
            float distanceMouse = Vector2.Distance(lastAddPoint, mousePos);

            if (distanceMouse < minMouseMove) return;//しきい値より動かなかったら線を描かない

            //もししきい値よりマウスが離れたら
            if (distanceMouse > 0.1f)
            {
                //ベクトル
                Vector3 direction = (mousePos - lastAddPoint).normalized;

                //しきい値の大きさのベクトル分の最後の点を記憶して代わりにそこに点を引く
                Vector3 newPoint = lastAddPoint + direction * 0.1f;

                float lengthToAdd = Vector3.Distance(lastAddPoint, newPoint);

               

                AddLine(newPoint);
                 
                currentLineRange += lengthToAdd;
            }

        }

        //左クリックを離した時かつREADYがfalseなら
        if (Input.GetMouseButtonUp(0) && !ready)
        {
            isDrawing = false;
            lineRenderer.positionCount = 0;//やりなおし
        }

        //右クリックを押した時
        if (Input.GetMouseButtonDown(1))
        {
            ready = true;
            isDrawing = false;
            
            //もう一度右クリックを押したら

            battleSystem.next = true;

        }

    }

    //線を引くメソッド(点)
    void AddLine(Vector3 point)
    {
        point.z = fixedDrawZ;//z軸を固定
        lineRenderer.positionCount = posCount + 1;//繰り返す度に点を増やしていく
        lineRenderer.SetPosition(posCount, point);//一つ前の点から次の点に線を書く
        posCount++;
        lastAddPoint = point;
    }

}