using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    //�Ƃ肠�����C���X�y�N�^�[��Ń����X�^�[���Z�b�g����
    [SerializeField] UnitBase unitBase;
    [SerializeField] int level;//���̑���̃��x��

    public Unit unit { get; set; }

    //�����X�^�[�̐������\�b�h
    public void SetUp()
    {
        unit = new Unit(unitBase, level);
        //����̉摜
        Image image = GetComponent<Image>();
        image.sprite =unit.unitBase.Sprite;
    }
}
