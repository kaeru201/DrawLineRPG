using UnityEngine;

//�f�[�^���Ǘ����邽�߂�ScriptableObject

[CreateAssetMenu]
public class UnitBase : ScriptableObject
{
    //���O�A�����A�摜�A�����A�X�e�[�^�X

    [SerializeField] new string name;
    [SerializeField] string description;
    [SerializeField] Sprite sprite;
    [SerializeField] Type type;

    //�X�e�[�^�X (�̗́A�U���́A�h��́A����)
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;

    //�l�̎擾�͂��������ǕύX�͂���Ȃ��v���p�e�B
    public int MaxHP { get => maxHP;}
    public int Attack { get => attack; }
    public int Defense { get => defense;}
    public int Speed { get => speed;}
}

public enum Type
{
    Fire,
    Water,
    Grass,
    Light,
    Darkness,
}
