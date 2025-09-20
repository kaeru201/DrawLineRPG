using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    //�����X�^�[���Z�b�g����
    [SerializeField] UnitBase unitBase;
    [SerializeField] int level;//���̑���̃��x��

    public Unit unit { get; set; }

    //�����X�^�[�̐������\�b�h
    [SerializeField]public void SetUp()
    {
        unit = new Unit(unitBase, level);
        //����̉摜
        Image image = GetComponent<Image>();
        image.sprite =unit.unitBase.Sprite;
    }
}
