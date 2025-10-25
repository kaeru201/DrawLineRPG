using System.Collections;
using UnityEngine;

//BGMタイプ
public enum BGMType
{
    None,
    Title,
    Enemy1,
    Boss1
}

public enum SEType
{
    Click,
    BattleStart,    
    Damage,
    Heal,
    BattleVictory
}




//音を管理するスクリプト
//テスト用にどのシーンにも配置して、タイトルシーンから順番にきた場合はすでにあるこのオブジェクトを消す
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;//このオブジェクトがすでに生成されているかを確かめる変数

    [SerializeField] AudioSource audioIntro;
    [SerializeField] AudioSource audioLoop;
    [SerializeField] AudioSource audioSE;

    [SerializeField] AudioClip bgm_titleIntro;
    [SerializeField] AudioClip bgm_titleLoop;
    [SerializeField] AudioClip bgm_enemy1Intro;
    [SerializeField] AudioClip bgm_enemy1Loop;
    [SerializeField] AudioClip bgm_boss1Intro;
    [SerializeField] AudioClip bgm_boss1Loop;

    [SerializeField] AudioClip se_click;
    [SerializeField] AudioClip se_battleStart;    
    [SerializeField] AudioClip se_damage;
    [SerializeField] AudioClip se_heal;
    [SerializeField] AudioClip se_battleVictory;


    private void Awake()
    {
        if (instance == null)//存在していないなら
        {
            instance = this;
            DontDestroyOnLoad(gameObject);//シーンが切り替わっても削除されないように
        }
        else//存在しているなら
        {
            Destroy(gameObject);//このオブジェクトを削除
            return;
        }

        PlayBGM(BGMType.Title);
    }

    public void PlayBGM(BGMType bgmType)
    {
        switch (bgmType)
        {
            case BGMType.Title:

                //イントロからループに移る際に無音時間をなくすため予めBGMをロードしておく
                bgm_titleIntro.LoadAudioData();
                bgm_titleLoop.LoadAudioData();

                //PlayScheduledでイントロを再生
                audioIntro.clip = bgm_titleIntro;
                audioIntro.loop = false;
                audioIntro.PlayScheduled(AudioSettings.dspTime);

                //PlayScheduledでループを遅延して再生
                audioLoop.clip = bgm_titleLoop;
                audioLoop.loop = true;
                audioLoop.PlayScheduled(AudioSettings.dspTime + (bgm_titleIntro.length / audioIntro.pitch));

                break;
            case BGMType.Enemy1:

                //イントロからループに移る際に無音時間をなくすため予めBGMをロードしておく
                bgm_enemy1Intro.LoadAudioData();
                bgm_enemy1Loop.LoadAudioData();

                //PlayScheduledでイントロを再生
                audioIntro.clip = bgm_enemy1Intro;
                audioIntro.loop = false;
                audioIntro.PlayScheduled(AudioSettings.dspTime);

                //PlayScheduledでループを遅延して再生
                audioLoop.clip = bgm_enemy1Loop;
                audioLoop.loop = true;
                audioLoop.PlayScheduled(AudioSettings.dspTime + (bgm_enemy1Intro.length / audioIntro.pitch));

                break;
            case BGMType.Boss1:

                //イントロからループに移る際に無音時間をなくすため予めBGMをロードしておく
                bgm_boss1Intro.LoadAudioData();
                bgm_boss1Loop.LoadAudioData();

                //PlayScheduledでイントロを再生
                audioIntro.clip = bgm_boss1Intro;
                audioIntro.loop = false;
                audioIntro.PlayScheduled(AudioSettings.dspTime);

                //PlayScheduledでループを遅延して再生
                audioLoop.clip = bgm_boss1Loop;
                audioLoop.loop = true;
                audioLoop.PlayScheduled(AudioSettings.dspTime + (bgm_boss1Intro.length / audioIntro.pitch));

                break;

            case BGMType.None:
                audioIntro.clip = null;
                audioLoop.clip = null;
                break;
        }
    }

    public void PlaySE(SEType type)
    {
        switch (type)
        {
            case SEType.Click:
                audioSE.PlayOneShot(se_click);
                break;
            case SEType.BattleStart:
                audioSE.PlayOneShot(se_battleStart);
                break;
            case SEType.Damage:
                audioSE.PlayOneShot(se_damage);
                break;
            case SEType.Heal:
                audioSE.PlayOneShot(se_heal);
                break;
            case SEType.BattleVictory:
                audioIntro.PlayOneShot(se_battleVictory);
                break;
        }
    }

}
