using UnityEngine;

//技データを管理するScriptableObject
[CreateAssetMenu]
public class SkillBase : ScriptableObject
{
    //技情報(名前、情報、技の種類、威力、貫通力、線の長さ、球の速さ、攻撃回数）
    [SerializeField] new string name;//名前  nameが被るから一応new
    [TextArea(3, 10)]
    [SerializeField] string description;//情報
    [SerializeField] SkillType skillType;//技の種類
    [SerializeField] int power;//威力
    [SerializeField] int penetrationPower;//貫通力
    [SerializeField] int maxLineRange;//線の長さ
    [SerializeField] int speed;//球の速さ
    [SerializeField] int numberAttacks;//攻撃回数

    public string Name { get => name; }
    public string Description { get => description; }
    public int Power { get => power; }
    public int PenetrationPower { get => penetrationPower; }
    public int MaxLineRange { get => maxLineRange; }
    public int Speed { get => speed; set => speed = value; }
    public int NumberAttacks { get => numberAttacks; set => numberAttacks = value; }
    internal SkillType SkillType { get => skillType; }
}



//技の種類
enum SkillType
{
    Attack,
    Heal,
    Support,
}


