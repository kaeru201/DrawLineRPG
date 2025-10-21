using UnityEngine;
using System.Collections.Generic;


//インスペクター上で配置したUnitをUnitSelectのリストに追加する
public class UnitTeam : MonoBehaviour
{
    [SerializeField] List<Unit> enemyTeams;

    public void SetUnit()
    {
        UnitSelect.enemyUnits = new List<Unit>();

        //ene
        for (int i = 0; i < enemyTeams.Count; i++)
        {
            UnitSelect.enemyUnits.Add(enemyTeams[i]);
        }

    }

}
