using UnityEngine;
using System;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

    public static string turn;

    void Awake()
    {
        //Pleyer��z�u

        //Enemy��z�u

        //������Ԃ�playerTurn
        turn = "playerTurn";
    }

    void Start()
    {
        
    }

    private void Update()
    {
        

    }



}

