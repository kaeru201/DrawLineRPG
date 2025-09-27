using UnityEngine;

public class Move
{
    //技のマスターデータをもつ

    //Unitが参照するからプロパティ
    private MoveBase moveBase;
    // public int mPoint {  get; set; }

    //初期設定

    public Move(MoveBase mBase)
    {
        MoveBase = mBase;
      // mPoint = mBase.MagicPoint;
    }

    public MoveBase MoveBase { get => moveBase; set => moveBase = value; }
}
