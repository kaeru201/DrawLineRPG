using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameStartButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Sprite enterButtonImage;
    [SerializeField] Sprite defaultImage;

    [SerializeField] Image image;
    [SerializeField] RectTransform textTransform;

    void Start()
    {
        image = GetComponent<Image>();

    }


    void Update()
    {

    }

    //ボタンをクリックしたとき
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("PartySelectScene"); 
        Invoke("DefaultReset", 100f * Time.deltaTime);//クリックした時も少し待って画像をリセット

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
        textTransform.localPosition = new Vector2(0,0);//テキストをデフォルトの場所に戻す
    }
}
