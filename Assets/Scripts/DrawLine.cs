<<<<<<< HEAD
using System.Runtime.CompilerServices;
=======
>>>>>>> origin/master
using Unity.VisualScripting;
using UnityEngine;

//���������X�N���v�g
public class DrawLine : MonoBehaviour
{
    BattleManager battleManager;
    MoveBase moveBase;
<<<<<<< HEAD
    bool isTrigerPoint = false;



=======
    

    
>>>>>>> origin/master

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

<<<<<<< HEAD

                //�E�N���b�N��������
                if (Input.GetMouseButton(1))
                {
                    //�����Œ肵�ĕ�����ύX�ł���

                }
                //�����E�N���b�N�𗣂� or �Z�͈̔͂�0�ɂȂ�(moveBase��������Ă��Ă邯�ǌ��݂̏�񂢂�Ȃ���)�@or �N����Point�ɐG�ꂽ��
                if (Input.GetMouseButtonUp(0) || moveBase.LineRange <= 0 || isTrigerPoint)
                {
                    //�܂����̃L�����N�^�[������Ȃ玟�̃L�����N�^�[�Ɉڂ�


=======
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
>>>>>>> origin/master
                }

            }

        }
<<<<<<< HEAD
                     

    }

    //��U�����ɏ����Ă邯�ǁA�v���n�u�̐����o���X�N���v�g�ɏ������e�����@���ƃ^�O�ŒT�������Ȃ�
    void OnCollisionEnter(Collision collision)
    {
        //�����ȊO��Point�ɐG�ꂽ��@���}���u�Ŏn�_��Point���炸�炷
        if (collision.gameObject.CompareTag("Point"))
        {
            isTrigerPoint = true;
        }
    }

=======

    }
>>>>>>> origin/master
}
