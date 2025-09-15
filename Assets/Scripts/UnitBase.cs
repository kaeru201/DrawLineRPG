using UnityEngine;

//データを管理するためにScriptableObject

[CreateAssetMenu]
public class UnitBase : ScriptableObject
{
    //名前、説明、画像、属性、ステータス

    [SerializeField] new string name;
    [SerializeField] string description;
    [SerializeField] Sprite sprite;
    [SerializeField] Type type;

    //ステータス (体力、攻撃力、防御力、速さ)
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;

    //値の取得はしたいけど変更はされないプロパティ
    public int MaxHP { get => maxHP;}
    public int Attack { get => attack; }
    public int Defense { get => defense;}
    public int Speed { get => speed;}
}

public enum Type
{
    Fire,
    Water,
    Grass,
    Light,
    Darkness,
}
