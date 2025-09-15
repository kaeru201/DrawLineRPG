using UnityEngine;

public class Unit
{
    [SerializeField] UnitBase unitBase;
    int level;

    public Unit(UnitBase uBase, int uLevel)
    {
        unitBase = uBase;
        level = uLevel;
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
