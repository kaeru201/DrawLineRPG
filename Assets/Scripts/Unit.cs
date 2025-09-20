using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Unit
{
    //���ۂɃQ�[���Ŏg��Unit�̃f�[�^

    //PlayerHud�̎���unitBase����Unit���Q�Ƃ��邽�߂�public (�v���o�e�B)
    [SerializeField] public UnitBase unitBase {get;set;}
    public int level { get; set; }

    public int hp { get; set; }
    //�g����Z
    public List<Move> Moves { get; set; }

    //�������̏����ݒ�
    public Unit(UnitBase uBase, int uLevel)
    {
        unitBase = uBase;
        level = uLevel;
        hp = MaxHP;

        Moves = new List<Move>();
        //�o����Z�̃��x���ȏ�Ȃ�AMoves�ɒǉ�
        foreach (LearnableMove learnableMove in uBase.Learnablemoves)
        {
            if(level >= learnableMove.Level)
            {
                //�Z���o����
                Moves.Add(new Move(learnableMove.MoveBase));
            }

        }

    }

    


    //���x���ɉ������X�e�[�^�X��Ԃ��v���p�e�B
    //UnitBase�̃v���p�e�B��level���|���ď����100������@5�͂悭�킩��Ȃ������������
    public int MaxHP
    {
        get => Mathf.FloorToInt((unitBase.MaxHP * level) / 100f) + 10;
    }
    public int Attack
    {
        get => Mathf.FloorToInt((unitBase.Attack * level) / 100f) + 5;
    }
    public int Defense
    {
        get => Mathf.FloorToInt((unitBase.Defense * level) / 100f) + 5;
    }
    public int Speed
    {
        get => Mathf.FloorToInt((unitBase.Speed * level) / 100f) + 5;
    }

}
