using UnityEngine;

public class Move
{
    //�Z�̃}�X�^�[�f�[�^������

    //Unit���Q�Ƃ��邩��public
    public MoveBase moveBase { get; set; }
   // public int mPoint {  get; set; }

    //�����ݒ�
  
    public Move(MoveBase mBase)
    {
        moveBase = mBase;
      // mPoint = mBase.MagicPoint;
    }

}
