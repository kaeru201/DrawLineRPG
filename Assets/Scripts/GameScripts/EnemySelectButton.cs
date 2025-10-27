using UnityEngine;
using UnityEngine.EventSystems;

public class EnemySelectButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameManager gameManager;

    [SerializeField] EnemyTeam enemyTeam;

    [SerializeField] bool lastBoss = false; //クリア条件の敵かどうか

    //敵に応じてBGMを変えるようの変数
    [SerializeField] bool enemy1 = false;
    [SerializeField] bool boss1 = false;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (lastBoss) GameManager.LastBattle = true;//ラスボスならGameManagerのLastBattle変数をtrueに
        SoundManager.instance.PlaySE(SEType.Click);//クリック音
        SoundManager.instance.PlaySE(SEType.BattleStart);
        enemyTeam.SetEnemyUnit();//戦う敵を設定

        if(enemy1)
        {
            
            SoundManager.instance.PlayBGM(BGMType.Enemy1);
        }
        else if(boss1)
        {
            SoundManager.instance.PlayBGM(BGMType.Boss1);
        }
                
        gameManager.BattleStart();
    }

}
   
