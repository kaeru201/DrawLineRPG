using UnityEngine;
using UnityEngine.EventSystems;

public class ReadyButton : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] BattleSystem battleSystem;

    public void OnPointerClick(PointerEventData eventData)
    {
        battleSystem.TurnCng(BattleState.EnemyTurn);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
