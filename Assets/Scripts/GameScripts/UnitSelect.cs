using System.Collections.Generic;
using UnityEngine;

//Unitの情報を入れておいて　Unitを配置するスクリプト
public class UnitSelect : MonoBehaviour
{
    [SerializeField] List<BattleUnit> mob1Units = new List<BattleUnit>();
    [SerializeField] List<BattleUnit> mob2Units = new List<BattleUnit>();
    [SerializeField] List<BattleUnit> mob3Units = new List<BattleUnit>();
    [SerializeField] List<BattleUnit> boss1Units = new List<BattleUnit>();

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //選ばれたらリストをそれぞれのImageにあるBattleUnitに配置する

    }

    // Update is called once per frame
    void Update()
    {

    }
}
