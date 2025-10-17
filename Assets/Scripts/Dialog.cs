using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Dialogにアタッチするスクリプト　ダイヤログで流すログを管理をする
//Listをテキストが発生するたびに追加してテキストを管理
public class Dialog : MonoBehaviour
{
    //[SerializeField] List<GameObject> diaLogGameObj;
    //[SerializeField] List<TextMeshProUGUI> diaLogText;
    [SerializeField] TextMeshProUGUI prefabText ;

   public  List<TextMeshProUGUI> dialogTexts = new List<TextMeshProUGUI>();

    Vector3 startPosition = new Vector3(0, 270, 0);
    Vector3 nextPosition = new Vector3();

    public int currentCount;

    void Start()
    {
        //nextPosition = startPosition;

        // nextPoint = startPoint;//これだと2週目以降がうまくいかないかも　newPointの位置がずれて
        AddDialog("test");
        
    }

    private void Awake()
    {
        AddDialog("test2");

    }

    void Update()
    {
        if(currentCount != dialogTexts.Count)
        {
            //順番に上から表示
            for (int i = 0; i < dialogTexts.Count; i++)
            {
                TextMeshProUGUI text = Instantiate(dialogTexts[i], transform.parent);//変数text使いまわせるのか?
                text.transform.SetParent(transform);
                text.transform.localPosition = nextPosition;
                text.transform.localScale = new Vector3(1, 1, 1);
                text.text = "test0";
                nextPosition.y -= 100;

                Debug.Log("6");

                currentCount++;
            }
        }
       
    }



    //ダイヤログで表示するものが出るたびに他のクラスから呼ばれて、ダイヤログを更新するメソッド
    public void AddDialog(string dialog)
    {
        //テキストが送られてくるたびにListにprefabを追加
       

        if (dialogTexts.Count == 0) nextPosition = startPosition;
        
        //dialogTextの要素数が6以下なら
        if (dialogTexts.Count <= 6)
        {
            dialogTexts.Add(prefabText);

            
           


            //TextMeshProUGUI text1 = Instantiate(prefabDialogText[0], new Vector3(0, 270, 0), Quaternion.identity);
            //text1.text = "player120ダメージ";

        }
        //dialogTextの要素数が7以上だったら
        else
        {
            //要素数が1番上のテキストを削除して

            //全員位置を上にずらして一番したに7番目以降の要素を表示 ←これは上の6個いかに任せてここでは削除するのに専念してもいいかも
            //多分処理が一気にきて消しきれないとか出てくる
        }
    }


}
