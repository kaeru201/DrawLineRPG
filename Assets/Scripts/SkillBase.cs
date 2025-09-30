using UnityEngine;

//技データを管理するScriptableObject
[CreateAssetMenu]
public class SkillBase : ScriptableObject
{
    //技情報(名前、情報、技の種類、威力、貫通力、線の長さ）
    [SerializeField] new string name;//nameが被るから一応new
    [TextArea(3, 10)]
    [SerializeField] string description;
    [SerializeField] SkillType skilType;
    [SerializeField] int power;
    [SerializeField] int penetrationPower;
    [SerializeField] int maxLineRange;

    public string Name { get => name; }
    public string Description { get => description; }
    public int Power { get => power; }
    public int PenetrationPower { get => penetrationPower; }
    public int MaxLineRange { get => maxLineRange; }
    internal SkillType SkilType { get => skilType; }
}



//技の種類
enum SkillType
{
    Attack,
    Heal,
    Support,
}


