using UnityEngine;

//ダメージ表記オブジェクトにアタッチするスクリプト
public class DamagePrefab : MonoBehaviour
{
    
    //生成されたら0.5f秒後に消える
    void Start()
    {
        Destroy(gameObject,20f* Time.deltaTime);

    }
       
}
