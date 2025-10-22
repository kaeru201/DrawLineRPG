using System.Collections.Generic;
using UnityEngine;

//AdventureSceneのUnitTeamからどの敵か情報を得て、Unitを配置するスクリプト
public class UnitSelect : MonoBehaviour
{
    [SerializeField] Unit[] playerUnits = new Unit[3]; //一旦playerUnitはここで設定(あとで違うところから)
     public static List<Unit>  enemyUnits;
    
        
    Unit[] enemyParty = new Unit[3];


    [SerializeField] Unit[] TestEnemy = new Unit[3];//BattleSceneからでも戦えるように一時的に配置する敵　あとで消してください
   
    public Unit[] PlayerUnits { get => playerUnits; set => playerUnits = value; }
    public Unit[] EnemyParty { get => enemyParty; set => enemyParty = value; }


    private void Awake()
    {
        enemyUnits = new List<Unit>();

        //テスト用に追加　☆あとで消してください☆
        for (int i = 0; i < TestEnemy.Length; i++)
        {
            enemyUnits.Add(TestEnemy[i]);
        }


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
