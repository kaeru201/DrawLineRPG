using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit battleUnit;
    [SerializeField] PlayerHud playerHud;

    private void Start()
    {
        battleUnit.SetUp();//�����X�^�[�̐���
        playerHud.SetData(battleUnit.unit);//�v���C���[��Hud���o��
    }

}
