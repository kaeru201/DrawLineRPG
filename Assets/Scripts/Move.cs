using UnityEngine;

public class Move
{
    //�Z�̃}�X�^�[�f�[�^

    //getset�����܂����킩��Ȃ�����u�t�ɕ���
    public MoveBase moveBase { get; set; }
    public int mPoint {  get; set; }

    //�����ݒ�
    public Move(MoveBase mBase)
    {
        moveBase = mBase;
       mPoint = mBase.MagicPoint;
    }

}
