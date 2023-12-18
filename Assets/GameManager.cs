using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public double Hp = 3;
    public int HpIndex = 2;
    public int Score;
    public TextMeshProUGUI ScoreText;
    public Image[] HpImage;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public Sprite HalfHeart;


    public TextMeshProUGUI CounterText;

    public BallConroller BallConroller;
    public UIManager UIManager;

    private bool _lastChance;
    private bool _game;
    private bool _counterAllowed;

    public void StartGame()
    {
        _game = true;
        _lastChance = true;

        _counterAllowed = true;
        BallConroller.StartTheGame();
        Score = 0;
        ScoreText.text = Score.ToString();
        Hp = 3;
        HpIndex = 2;
        for (int i = 0; i < HpImage.Length; i++)
            HpImage[i].sprite = FullHeart;
    }




    public void ScoreAdd()
    {
        Score++;
        ScoreText.text = Score.ToString();
    }

    public void LostHealth(int way)
    {
        if (_game)
        {
            if(way == 0)
            {
                Hp--;
                if (Hp == 3 || Hp == 2 || Hp == 1)
                {
                    HpImage[HpIndex].sprite = EmptyHeart;
                    HpIndex--;

                }
                else if (Hp == 0 || Hp < 0)
                {
                    HpImage[HpIndex].sprite = EmptyHeart;
                    if (_lastChance)
                        PreGameOver();
                    else
                    {
                        GameOver();

                    }
                }
                else
                {
                    HpImage[HpIndex].sprite = EmptyHeart;

                    HpIndex--;
                    HpImage[HpIndex].sprite = HalfHeart;
                }
            }
            else
            {
                Hp -= 0.5;
                if(Hp==3||Hp==2||Hp==1)
                {
                    HpImage[HpIndex].sprite = EmptyHeart;
                    HpIndex--;
                }
                else if (Hp == 0)
                {
                    HpImage[HpIndex].sprite = EmptyHeart;
                    if (_lastChance)
                        PreGameOver();
                    else
                    {
                        GameOver();

                    }
                }
                else
                    HpImage[HpIndex].sprite = HalfHeart;

            }

        }
        
    }
    public void GameOver()
    {
        print("GAME OVER");
        BallConroller.StopAllCoroutines();
        if (Score > PlayerPrefs.GetInt("BestScore"))
            PlayerPrefs.SetInt("BestScore", Score);
        _lastChance = true;
        _game = false;
        DestroyPrefs();
        PlayerPrefs.SetInt("AdCounter", PlayerPrefs.GetInt("AdCounter") + 1);
        UIManager.StopGame();


    }
    public void PreGameOver()
    {
        print("GAME OVER");
        BallConroller.StopAllCoroutines();
        if (Score > PlayerPrefs.GetInt("BestScore"))
            PlayerPrefs.SetInt("BestScore", Score);
        UIManager.GameOverMenu.SetActive(true);
        StartCoroutine(Counter());
        _game = false;

    }
    public void ContinueGame()
    {
        DestroyPrefs();
        _counterAllowed = false;
        StopCoroutine(Counter());
        UIManager.GameOverMenu.SetActive(false);
        Hp++;
        HpImage[0].sprite = FullHeart;
        BallConroller.StartCoroutine("BallSpawning");
        BallConroller.StartCoroutine("BallSpeadIncrise");
        _lastChance = false;
        _game = true;
    }

    private void DestroyPrefs()
    {
        GameObject[] prefabs = GameObject.FindGameObjectsWithTag("Basketball");
        foreach (GameObject prefab in prefabs)
        {
            Destroy(prefab);
        }
        prefabs = GameObject.FindGameObjectsWithTag("FootBall");
        foreach (GameObject prefab in prefabs)
        {
            Destroy(prefab);
        }
        prefabs = GameObject.FindGameObjectsWithTag("TennisBall");
        foreach (GameObject prefab in prefabs)
        {
            Destroy(prefab);
        }
        prefabs = GameObject.FindGameObjectsWithTag("VolleyBall");
        foreach (GameObject prefab in prefabs)
        {
            Destroy(prefab);
        }
    }

    IEnumerator Counter()
    {
        int i = 5;
        while (i>0)
        {
            CounterText.text = i.ToString();
            i--;
            yield return new WaitForSeconds(1);
        }
        if(_counterAllowed)
        {
            UIManager.StopGame();
            GameOver();
        }
        
    }
}
