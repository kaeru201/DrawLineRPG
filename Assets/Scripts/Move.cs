using UnityEngine;

public class Move
{
    //技のマスターデータ

   
    public MoveBase moveBase { get; set; }
    public int mPoint {  get; set; }

    //初期設定
    public Move(MoveBase mBase)
    {
        moveBase = mBase;
       mPoint = mBase.MagicPoint;
    }

}
