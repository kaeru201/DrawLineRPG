using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Dialogにアタッチするスクリプト　ダイヤログで流すログを管理をする
//Listをテキストが発生するたびに追加してテキストを管理
public class Dialog : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI prefabText;

    public List<TextMeshProUGUI> dialogTextObjs = new List<TextMeshProUGUI>();

    Vector3 startPosition = new Vector3(0, 260, 0);//初期地点
    Vector3 nextPosition = new Vector3();//次の出現地点
    float dialogSpece　=　110f;//ダイヤログの間隔


    //ダイヤログで表示するものが出るたびに他のクラスから呼ばれて、ダイヤログを更新するメソッド
    public void AddDialog(string dialog)
    {
      
        //まだListに要素がないなら次の出現地点を初期地点に
        if (dialogTextObjs.Count == 0) nextPosition = startPosition;

        //dialogTextの要素数が6以上だったら
        if (dialogTextObjs.Count >= 6)
        {
            //要素数が1番上のオブジェクトごとテキストとListを削除して           
            Destroy(dialogTextObjs[0].gameObject);
            dialogTextObjs.RemoveAt(0);

            //残っているすべてListのオブジェクトを上にずらす
            foreach (TextMeshProUGUI textObj in dialogTextObjs)
            {
                Vector3 textPos = textObj.gameObject.transform.localPosition;

                textPos.y += dialogSpece;

                textObj.gameObject.transform.localPosition = textPos;
            }

            nextPosition.y += dialogSpece;//次の出現地点を上にずらす(枠から出ないように)

        }

        //ダイヤログテキストをインスタンス化
        TextMeshProUGUI text = Instantiate(prefabText);
        dialogTextObjs.Add(text);//dialogTextリストに追加
        text.transform.SetParent(transform);//親をこのオブジェクトに
        text.transform.localPosition = nextPosition;//出現地点
        text.transform.localScale = new Vector3(1, 1, 1);
        text.text = dialog;//テキストをメソッドの引数に変更

        nextPosition.y -= dialogSpece;//次の出現地点を下にずらす

    }

    //ダイヤログをリセットするメソッド(battleSystemから呼ばれる)
    public void DialogReset()
    {
        foreach (TextMeshProUGUI textObj in dialogTextObjs)
        {
            Destroy(textObj);
        }

            dialogTextObjs.Clear();
    }

}
