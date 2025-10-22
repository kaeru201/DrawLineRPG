using System.Collections.Generic;
using UnityEngine;

//PartySelectSceneで選ばれたpartyを負けるまで取得しているスクリプト
//AdventureSceneのUnitTeamからどの敵か情報を得て、Unitを配置するスクリプト
public class UnitSelect : MonoBehaviour
{
    public static Unit[] playerUnits = new Unit[3]; //Static化してPlayerUnitをここで保管
     public static List<Unit>  enemyUnits;//enemyを振り分ける前のlist (4体以上Listに入ってくる可能があるため振り分ける必要がある)
    
        
    Unit[] enemyParty = new Unit[3];
      
       
    public Unit[] EnemyParty { get => enemyParty; set => enemyParty = value; }


    private void Awake()
    {
        //enemyUnits = new List<Unit>();
              

       　//敵を3体埋まるまでenemyUnitsリストからランダムに配置
        for (int i = 0; i < 3; i++)
        {
            int enemyNum = Random.Range(0, enemyUnits.Count);
            EnemyParty[i] = enemyUnits[enemyNum];
            enemyUnits.RemoveAt(enemyNum);//配置したUnitはリストから削除
        }

        //Unitの初期設定
        playerUnits[0].Init();
        playerUnits[1].Init();
        playerUnits[2].Init();
        EnemyParty[0].Init();
        EnemyParty[1].Init();
        EnemyParty[2].Init();

        //振り分けが終わったらenemyUnitsの要素を全部リセット    
        enemyUnits.Clear();
    }
       
}
