using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField] GameObject skillSelection;
    [SerializeField] GameObject itemSelection;
    [SerializeField] GameObject escape;
   // [SerializeField] GameObject attackButton;

    void Start()
    {

        // skillSelection.SetActive(true);
    }


    void Update()
    {
        //攻撃ボタンを押したらそのキャラが持っているSkillが表示されているSkillUI表示して一番最初のUIを消す
        // Instantiate(skillSelection);

    }

    public void OnSkillButtonClick()
    {
        skillSelection.SetActive(true);
    }

    public void OnItemButtonClick()
    {
        itemSelection.SetActive(true);
    }
}
