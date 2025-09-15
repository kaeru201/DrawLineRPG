using UnityEngine;

[CreateAssetMenu]
//技データを管理するためにScriptableObject

public class MoveBase : ScriptableObject
{
    //名前,詳細、威力、消費マナ、   効果はあと

    [SerializeField] new string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] int power;
    [SerializeField] int magicPoint;

}

