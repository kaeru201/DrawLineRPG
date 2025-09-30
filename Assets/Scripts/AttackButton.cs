using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;



public class AttackButton : MonoBehaviour
   
{
   [SerializeField] GameObject attackButton;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick(GameObject obj)
    {
        attackButton.SetActive(true);
    }
}
