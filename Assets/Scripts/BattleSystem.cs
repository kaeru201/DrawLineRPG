using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    //�Ƃ肠�����C���X�y�N�^�[��ŃA�^�b�`
    [SerializeField] BattleUnit player1Unit;
    [SerializeField] BattleUnit player2Unit;
    [SerializeField] BattleUnit player3Unit;
    [SerializeField] BattleUnit Enemy1Unit;
    [SerializeField] BattleUnit Enemy2Unit;
    [SerializeField] BattleUnit Enemy3Unit;


    //�Ƃ肠�����C���X�y�N�^�[��ŃA�^�b�`
    [SerializeField] PlayerHud player1Hud;
    [SerializeField] PlayerHud player2Hud;
    [SerializeField] PlayerHud player3Hud;
    [SerializeField] EnemyHud Enemy1Hud;
    [SerializeField] EnemyHud Enemy2Hud;
    [SerializeField] EnemyHud Enemy3Hud;



    private void Start()
    {
        player1Unit.SetUp();//�����X�^�[�̐���
        player2Unit.SetUp();
        player3Unit.SetUp();
        Enemy1Unit.SetUp();
        Enemy2Unit.SetUp();
        Enemy3Unit.SetUp();
       

        player1Hud.SetData(player1Unit.unit);//�v���C���[��Hud���o��
        player2Hud.SetData(player2Unit.unit);
        player3Hud.SetData(player3Unit.unit);
        Enemy1Hud.SetData(Enemy1Unit.unit);
        Enemy2Hud.SetData(Enemy2Unit.unit);
        Enemy3Hud.SetData(Enemy3Unit.unit);
        
    }

}
