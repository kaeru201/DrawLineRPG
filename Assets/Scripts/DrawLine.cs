using Unity.VisualScripting;
using UnityEngine;

//線を書くスクリプト
public class DrawLine : MonoBehaviour
{
    BattleManager battleManager;
    MoveBase moveBase;
    

    

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

                //右クリックをしたら
                if (Input.GetMouseButton(1))
                {
                　　　//線を固定して方向を変更できる

                }
                //もし右クリックを離す or 技の範囲が0になる　or 敵のPointに触れたら
                if(Input.GetMouseButtonUp(0) ||  moveBase.LineRange <= 0)//|| OnTriggerEnter2D(Collision collision
                {
                       //まだ次のキャラクターがいるなら次のキャラクターに移る

                    　
                }

            }

        }

    }
}
