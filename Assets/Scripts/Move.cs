using UnityEngine;

public class Move
{
    //�Z�̃}�X�^�[�f�[�^

   
    public MoveBase moveBase { get; set; }
    public int mPoint {  get; set; }

    //�����ݒ�
    public Move(MoveBase mBase)
    {
        moveBase = mBase;
       mPoint = mBase.MagicPoint;
    }

}
