using UnityEngine;

//buttonを押したら次の項目に行くスクリプト(汎用)
public class NextButton : MonoBehaviour
{
   public void Next()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Back()
    {
        //親を消す
        transform.parent.gameObject.SetActive(false);
    }
}
