using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseBttn;
    public GameObject resumeBttn;

    public GameObject GameOverMenu;

    public GameObject MenuUI;
    public GameObject PlayBttn;
    public GameObject SettBttn;
    public GameObject BackBttn;

    public GameObject GameUI;

    public TextMeshProUGUI BestScore;

    public GameObject SettingsMenu;
    public Image MusicImg;
    public Sprite MusicOn;
    public Sprite MusicOff;
    public Image Sounds;
    public Sprite SoundsOn;
    public Sprite SoundsOff;

    public AudioSource MusicSource;

    public bool _music, _sound;
    public InterAd interAd;
    // Start is called before the first frame update
    void Start()
    {
        StopGame();
        Settings(false);

    }

    public void StartGame()
    {
        MenuUI.SetActive(false);
        GameUI.SetActive(true);
    }
    public void StopGame()
    {
        MenuUI.SetActive(true);
        GameUI.SetActive(false);
        Pause(false);
        GameOverMenu.SetActive(false);
        BestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
        if (PlayerPrefs.GetInt("AdCounter") % 3 == 0)
            interAd.ShowAd();

    }
    public void Pause(bool isPause)
    {
        if(isPause)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            pauseBttn.SetActive(false);
            resumeBttn.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            pauseBttn.SetActive(true);
            resumeBttn.SetActive(false);
        }

    }
    public void Settings(bool isOpen)
    {
        if(isOpen)
        {
            PlayBttn.SetActive(false);
            SettBttn.SetActive(false);
            SettingsMenu.SetActive(true);

        }
        else
        {

            PlayBttn.SetActive(true);
            SettBttn.SetActive(true);
            SettingsMenu.SetActive(false);
        }
    }
    public void MusicCheck()
    {
        if (!_music)
            MusicImg.sprite = MusicOff;
        else
            MusicImg.sprite = MusicOn;

        _music = !_music;
        MusicSource.mute = _music;
    }
    public void SoundsCheck()
    {
        if (!_sound)
            Sounds.sprite = SoundsOff;
        else
            Sounds.sprite = SoundsOn;
        _sound = !_sound;
    }
}
