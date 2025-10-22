using System.Collections.Generic;
using UnityEngine;

//インスペクター上で配置したPlayerUnitをUnitSelectのリストに追加する
public class EnemyTeam : MonoBehaviour
{
    [SerializeField] List<Unit> enemyTeams;

    //enemyTeamsリストに入っている要素をすべてUnit.SelectのenemyUnitsリストに追加
    public void SetEnemyUnit()
    {
        UnitSelect.enemyUnits = new List<Unit>();


        for (int i = 0; i < enemyTeams.Count; i++)
        {
            UnitSelect.enemyUnits.Add(enemyTeams[i]);
        }

    }
}
