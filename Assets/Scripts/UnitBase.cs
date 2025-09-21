using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

//�f�[�^���Ǘ����邽�߂�ScriptableObject
//Unit�̊�{�I�Ȑݒ�
[CreateAssetMenu]
public class UnitBase : ScriptableObject
{
    //Unit�̊�{�I�ȏ�������ϐ�
    //���O�A�����A�摜�A�����A�X�e�[�^�X

    [SerializeField] new string name; //name��Object.name�Ɣ�邩��ꉞnew������
    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite sprite;
    [SerializeField] Type type; //��Type�^��type�ϐ�

    //�X�e�[�^�X (�̗́A�U���́A�h��́A����)
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;

    //�o����Z list
    [SerializeField] List<LearnableMove> learnablemoves;

    //�l�̎擾�͂��������ǕύX�͂���Ȃ��v���p�e�B
    public string Name { get => name; }
    public string Description { get => description; }
    public Sprite Sprite { get => sprite; }
    public Type Type { get => type; }


    public int MaxHP { get => maxHP; }
    public int Attack { get => attack; }
    public int Defense { get => defense; }
    public int Speed { get => speed; }

    public List<LearnableMove> Learnablemoves { get => learnablemoves; }

}


//�񋓌^�̑���(���������A�΁A���A���A���A��)
public enum Type
{
    none,
    Fire,
    Water,
    Grass,
    Light,
    Darkness,
}

//�ǂ̃��x���łǂ̋Z���o����̂�
[Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase MoveBase { get => moveBase; }
    public int Level { get => level; }
}
