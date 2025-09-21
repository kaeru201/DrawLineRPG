<<<<<<< HEAD
using System.Runtime.CompilerServices;
=======
>>>>>>> origin/master
using Unity.VisualScripting;
using UnityEngine;

//線を書くスクリプト
public class DrawLine : MonoBehaviour
{
    BattleManager battleManager;
    MoveBase moveBase;
<<<<<<< HEAD
    bool isTrigerPoint = false;



=======
    

    
>>>>>>> origin/master

    void Start()
    {


    }


    void Update()
    {
        //線を書くターンではないのなら何もしない
        if (battleManager.State != BattleState.DrawLinTurn) return;

        //線を書くターンなら
        else
        {
            LineDrow();

        }


        //どう今使っている技のLineRangeと紐づけるか
        void LineDrow()
        {
            //左クリックをし続けたら
            if (Input.GetMouseButton(0))
            {
                //線を引く

<<<<<<< HEAD

                //右クリックをしたら
                if (Input.GetMouseButton(1))
                {
                    //線を固定して方向を変更できる

                }
                //もし右クリックを離す or 技の範囲が0になる(moveBaseから引いてきてるけど現在の情報いれないと)　or 誰かのPointに触れたら
                if (Input.GetMouseButtonUp(0) || moveBase.LineRange <= 0 || isTrigerPoint)
                {
                    //まだ次のキャラクターがいるなら次のキャラクターに移る


=======
                //右クリックをしたら
                if (Input.GetMouseButton(1))
                {
                　　　//線を固定して方向を変更できる

                }
                //もし右クリックを離す or 技の範囲が0になる　or 敵のPointに触れたら
                if(Input.GetMouseButtonUp(0) ||  moveBase.LineRange <= 0)//|| OnTriggerEnter2D(Collision collision
                {
                       //まだ次のキャラクターがいるなら次のキャラクターに移る

                    　
>>>>>>> origin/master
                }

            }

        }
<<<<<<< HEAD
                     

    }

    //一旦ここに書いてるけど、プレハブの線を出すスクリプトに書く内容かも　あとタグで探したくない
    void OnCollisionEnter(Collision collision)
    {
        //自分以外のPointに触れたら　応急処置で始点をPointからずらす
        if (collision.gameObject.CompareTag("Point"))
        {
            isTrigerPoint = true;
        }
    }

=======

    }
>>>>>>> origin/master
}
