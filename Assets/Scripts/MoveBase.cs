using UnityEngine;

[CreateAssetMenu]
//技データを管理するためにScriptableObject

public class MoveBase : ScriptableObject
{
    //名前,詳細、属性、威力、消費マナ、線の書ける範囲   効果はあと

    [SerializeField] new string name; //nameがObject.nameと被るから一応newをつける

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Type type;
    [SerializeField] int power;
    [SerializeField] int magicPoint;
    [SerializeField] float lineRange;

    public string Name { get => name; }
    public string Description { get => description; }
    public Type Type { get => type; }
    public int Power { get => power; }
    public int MagicPoint { get => magicPoint; }
    public float LineRange { get => lineRange; }
}

