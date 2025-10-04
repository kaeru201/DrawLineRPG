using UnityEngine;
using System.Collections.Generic;


//線を描くための情報を扱っているスクリプト
//DrawLinePlaseにアタッチしておく
public class DrawIntelligence : MonoBehaviour
{
    [SerializeField] int[] skill = new int[6];

    public int[] Skill { get => skill; set => skill = value; }

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
