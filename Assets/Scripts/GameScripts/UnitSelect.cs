using System.Collections.Generic;
using UnityEngine;

//Unit�̏������Ă����ā@Unit��z�u����X�N���v�g
public class UnitSelect : MonoBehaviour
{
    [SerializeField] List<BattleUnit> mob1Units = new List<BattleUnit>();
    [SerializeField] List<BattleUnit> mob2Units = new List<BattleUnit>();
    [SerializeField] List<BattleUnit> mob3Units = new List<BattleUnit>();
    [SerializeField] List<BattleUnit> boss1Units = new List<BattleUnit>();

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�I�΂ꂽ�烊�X�g�����ꂼ���Image�ɂ���BattleUnit�ɔz�u����

    }

    // Update is called once per frame
    void Update()
    {

    }
}
