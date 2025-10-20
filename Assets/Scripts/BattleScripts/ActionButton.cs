using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//ActionButtonにアタッチしてボタンを押したときのスクリプト
public class ActionButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    GameObject actionButton;
    GameObject serectAction;
    Image image;
    RectTransform textTransform;

    [SerializeField] Sprite enterButtonImage;
    [SerializeField] Sprite defaultImage;
    [SerializeField] GameObject nextUI;


    void Start()
    {
        actionButton = GetComponent<GameObject>();
        image = GetComponent<Image>();
        textTransform = transform.GetChild(0).GetComponent<RectTransform>();
        serectAction = transform.parent.gameObject;
    }


    //ボタンをクリックしたとき
    public void OnPointerClick(PointerEventData eventData)
    {
        nextUI.SetActive(true);//対応した次のUIを起動
        serectAction.SetActive(false);//自分の親ごと停止

        Invoke("DefaultReset", 200f * Time.deltaTime);//クリックした時も少し待って画像をリセット
    }

    //マウスがボタンを触れたとき
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = enterButtonImage; //画像を押されたときのに変える
        textTransform.localPosition = new Vector2(0, -13);//画像変更に合わせてテキストの場所を下げる
    }

    //マウスがボタンから離れたとき
    public void OnPointerExit(PointerEventData eventData)
    {
        DefaultReset();
    }

    //リセット
    void DefaultReset()
    {
        image.sprite = defaultImage; //デフォルト画像に戻す
        textTransform.localPosition = new Vector2(0, 0);//テキストをデフォルトの場所に戻す
    }

}
