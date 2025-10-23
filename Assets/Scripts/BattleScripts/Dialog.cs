using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Dialogにアタッチするスクリプト　ダイヤログで流すログを管理をする
//Listをテキストが発生するたびに追加してテキストを管理
public class Dialog : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI prefabText;

    public List<TextMeshProUGUI> dialogTextObjs = new List<TextMeshProUGUI>();//ダイヤログにテキストプレハブを管理するリスト

    public List<string> endDialogs = new List<string>();//エンドダイヤログを決まった順番に出すためのリスト

    [SerializeField] Vector3 startPosition;//初期地点
    Vector3 nextPosition = new Vector3();//次の出現地点
   [SerializeField] float dialogSpece;//ダイヤログの間隔
    [SerializeField] int dialogLimit;//ダイヤログを表示できる上限

    //ダイヤログで表示するものが出るたびに他のクラスから呼ばれて、ダイヤログを更新するメソッド
    public void AddDialog(string dialog)
    {
      
        //まだListに要素がないなら次の出現地点を初期地点に
        if (dialogTextObjs.Count == 0) nextPosition = startPosition;

        //dialogTextの要素数がdialogLimit以上だったら
        if (dialogTextObjs.Count >= dialogLimit)
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

    //エンドダイヤログリストに引数のstringを追加するメソッド
    public void AddEndDialogList(string dailog)
    {
        endDialogs.Add(dailog);
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
