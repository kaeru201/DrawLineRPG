using UnityEngine;

[CreateAssetMenu]
//�Z�f�[�^���Ǘ����邽�߂�ScriptableObject

public class MoveBase : ScriptableObject
{
    //���O,�ڍׁA�����A�З́A����}�i�A���̏�����͈�   ���ʂ͂���

    [SerializeField] new string name; //name��Object.name�Ɣ�邩��ꉞnew������

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Type type;
    [SerializeField] int power;
    [SerializeField] int magicPoint;
    [SerializeField] float lineRange;

    public string Name { get => name; }
    public string Description { get => description; }
    public Type Type { get => type; }
    public int Power { get => power; }
    public int MagicPoint { get => magicPoint; }
    public float LineRange { get => lineRange; }
}

