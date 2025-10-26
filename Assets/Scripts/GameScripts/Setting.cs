using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider masterSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider seSlider;

    
    private void Start()
    {
        audioMixer.GetFloat("Master", out float masterVolume);
        masterSlider.value = masterVolume;

        audioMixer.GetFloat("BGM",out float bgmVolume);
        bgmSlider.value = bgmVolume;

        audioMixer.GetFloat("SE",out float  seVolume);
        seSlider.value = seVolume;
    }


    public void SetMaster(float volume)
    {
        audioMixer.SetFloat("Master", volume);
    }


    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }


    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE", volume);
    }


    public void Next()
    {
        //他のsetting項目があれば他の項目を消してから
        //対応したUIを出す
        transform.GetChild(0).gameObject.SetActive(true);  
    }

    

}
