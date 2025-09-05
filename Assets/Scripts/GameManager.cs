using UnityEngine;
using System;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

    public static string turn;

    void Awake()
    {
        //Pleyerを配置

        //Enemyを配置

        //初期状態をplayerTurn
        turn = "playerTurn";
    }

    void Start()
    {
        
    }

    private void Update()
    {
        

    }



}

