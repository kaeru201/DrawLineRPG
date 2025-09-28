using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

//pointにアタッチするスクリプト
//線を書くスクリプト
public class DrawLine : MonoBehaviour
{
    BattleManager battleManager;
    MoveBase moveBase;
    LineRenderer lineRenderer;
    CircleCollider2D circleCollider;
    Transform startPosition;

   // bool isTrigerPoint = false;//プレバフ化した攻撃Bollでつける変数を一旦つけてる
    float maxLineRange;//本当はskillから参照してくる変数
    int posCount;//
    bool isDrawing = false;
    bool ready;
    float currentLineRange;//現在の書ける長さ
    Vector2 lastAddPoint;//最後に追加した点を記憶しておく変数






    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        startPosition = GetComponent<Transform>();

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f; 

    }


    void Update()
    {
        //線を書くターンではないのなら何もしない
       // if (battleManager.State != BattleState.DrawLinTurn) return;

        //マウスのスクリーン座標をワールド座標に変換する
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        if (Input.GetMouseButtonDown(0))
        {
            //押した時範囲外なら書かない
            if (circleCollider.bounds.Contains(mousePos)) return;


            isDrawing = true;
            //初期化
            posCount = 0;
            lineRenderer.positionCount = 0;
            currentLineRange = 0;

            AddLine(startPosition.position);

        }

        //左クリック押し続けている間かつisDrawがtrueなら
        if (Input.GetMouseButton(0) && isDrawing)
        {
            if(currentLineRange >= maxLineRange)
                {

                isDrawing = false;
                return;
            }

            //最後点と今のマウスの位置の差
            float distanceMouse = Vector2.Distance(lastAddPoint, mousePos);

            //もししきい値よりマウスが離れたら
            if (distanceMouse > 0.1f)
            { 
            　　　//ベクトル
               Vector2 direction = (mousePos - lastAddPoint).normalized;

                //
                Vector2 newPoint = lastAddPoint + direction * 0.1f;

                //
                float lengthToAdd = Vector2.Distance(lastAddPoint, newPoint);


                //if(currentLineRange + lengthToAdd > maxLineRange){}
                
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
        if(Input.GetMouseButtonDown(1))
        {
            ready = true;
            isDrawing=false;
            //次のキャラSkillに移動
            //いないならREADYのUIを出して行けるなら敵の線を引くターンに移動
        }



    }

    //線を引くメソッド(点)
    void AddLine(Vector2 point)
    {
        lineRenderer.positionCount = posCount + 1;//繰り返す度に点を増やしていく
        lineRenderer.SetPosition(posCount, point);//一つ前の点から次の点に線を書く
        posCount++;
    }


    //一旦ここに書いてるけど、プレハブの線を出すスクリプトに書く内容かも　あとタグで探したくない
    //void OnCollisionEnter(Collision collision)
    //{
    //    //自分以外のPointに触れたら　応急処置で始点をPointからずらす
    //    if (collision.gameObject.CompareTag("Point"))
    //    {
    //        isTrigerPoint = true;
    //    }
    //}

}