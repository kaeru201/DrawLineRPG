using Unity.VisualScripting;
using UnityEngine;

//���������X�N���v�g
public class DrawLine : MonoBehaviour
{
    BattleManager battleManager;
    MoveBase moveBase;
    

    

    void Start()
    {


    }


    void Update()
    {
        //���������^�[���ł͂Ȃ��̂Ȃ牽�����Ȃ�
        if (battleManager.State != BattleState.DrawLinTurn) return;

        //���������^�[���Ȃ�
        else
        {
            LineDrow();

        }


        //�ǂ����g���Ă���Z��LineRange�ƕR�Â��邩
        void LineDrow()
        {
            //���N���b�N������������
            if (Input.GetMouseButton(0))
            {
                //��������

                //�E�N���b�N��������
                if (Input.GetMouseButton(1))
                {
                �@�@�@//�����Œ肵�ĕ�����ύX�ł���

                }
                //�����E�N���b�N�𗣂� or �Z�͈̔͂�0�ɂȂ�@or �G��Point�ɐG�ꂽ��
                if(Input.GetMouseButtonUp(0) ||  moveBase.LineRange <= 0)//|| OnTriggerEnter2D(Collision collision
                {
                       //�܂����̃L�����N�^�[������Ȃ玟�̃L�����N�^�[�Ɉڂ�

                    �@
                }

            }

        }

    }
}
