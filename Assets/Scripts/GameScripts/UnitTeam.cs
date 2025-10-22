using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;


//インスペクター上で配置したPlayerUnitをUnitSelectのリストに追加する
public class UnitTeam : MonoBehaviour
{
    [SerializeField] Unit[] playerTeams = new Unit[3];
    

    public void SetPlayerUnit()
    {

        for (int i = 0; i < playerTeams.Length; i++)
        {
            //選んだPartyをstaticの実際に使うpalyerUnitsに代入
            UnitSelect.playerUnits[i] = playerTeams[i];
            //代入と同時に初期レベルに応じた経験値を代入
            UnitSelect.playerUnits[i].Exp = UnitSelect.playerUnits[i].UnitBase.GetExpForLevel(UnitSelect.playerUnits[i].Level);
        }
    }


    

}
