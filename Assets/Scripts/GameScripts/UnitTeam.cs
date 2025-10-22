using UnityEngine;
using System.Collections.Generic;


//インスペクター上で配置したUnitをUnitSelectのリストに追加する
public class UnitTeam : MonoBehaviour
{
    [SerializeField] Unit[] playerTeams = new Unit[3];
    [SerializeField] List<Unit> enemyTeams;

    public void  SetPlayerUnit()
    {

    }


    public void SetEnemyUnit()
    {
        UnitSelect.enemyUnits = new List<Unit>();

        
        for (int i = 0; i < enemyTeams.Count; i++)
        {
            UnitSelect.enemyUnits.Add(enemyTeams[i]);
        }

    }

}
