using UnityEngine;

[CreateAssetMenu]
//技データを管理するためにScriptableObject

public class MoveBase : ScriptableObject
{
    //名前,詳細、属性、威力、消費マナ、   効果はあと

    [SerializeField] new string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Type type;
    [SerializeField] int power;
    [SerializeField] int magicPoint;

    public string Name { get => name; }
    public string Description { get => description; }
    public Type Type { get => type; }
    public int Power { get => power; }
    public int MagicPoint { get => magicPoint; }
}

