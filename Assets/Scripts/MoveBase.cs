using UnityEngine;

[CreateAssetMenu]
//�Z�f�[�^���Ǘ����邽�߂�ScriptableObject

public class MoveBase : ScriptableObject
{
    //���O,�ڍׁA�З́A����}�i�A   ���ʂ͂���

    [SerializeField] new string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] int power;
    [SerializeField] int magicPoint;

}

