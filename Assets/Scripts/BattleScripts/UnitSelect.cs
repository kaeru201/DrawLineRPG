using System.Collections.Generic;
using UnityEngine;

//AdventureSceneのUnitTeamからどの敵か情報を得て、Unitを配置するスクリプト
public class UnitSelect : MonoBehaviour
{
    [SerializeField] Unit[] playerUnits = new Unit[3]; //一旦playerUnitはここで設定(あとで違うところから)
     public static List<Unit>  enemyUnits;
    
        
    Unit[] enemyParty = new Unit[3];

   
    public Unit[] PlayerUnits { get => playerUnits; set => playerUnits = value; }
    public Unit[] EnemyParty { get => enemyParty; set => enemyParty = value; }


    private void Awake()
    {
       　//敵を3体埋まるまでenemyUnitsリストからランダムに配置
        for (int i = 0; i < 3; i++)
        {
            int enemyNum = Random.Range(0, enemyUnits.Count);
            EnemyParty[i] = enemyUnits[enemyNum];
            enemyUnits.RemoveAt(enemyNum);//配置したUnitはリストから削除
        }

        //Unitの初期設定
        PlayerUnits[0].Init();
        PlayerUnits[1].Init();
        PlayerUnits[2].Init();
        EnemyParty[0].Init();
        EnemyParty[1].Init();
        EnemyParty[2].Init();

        //戦闘が終わったらenemyUnitsの要素を全部リセット    
        enemyUnits.Clear();
    }
       
}
