using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallConroller : MonoBehaviour
{
    public GameObject[] Balls;
    public float MaxBallSpeed;
    public GameManager GameManager;

    List<GameObject> BasketBall;
    List<GameObject> FootBall;
    List<GameObject> VolleyBall;
    List<GameObject> TennisBall;

    private bool _game;
    private float _minBallSpeed;


    private void Awake()
    {
        BasketBall = new List<GameObject>();
        FootBall = new List<GameObject>();
        VolleyBall = new List<GameObject>();
        TennisBall = new List<GameObject>();

    }
    public void StartTheGame()
    {
        Awake();
        MaxBallSpeed = 5f;
        _game = true;
        _minBallSpeed = MaxBallSpeed - 3f;
        GameManager.Hp = 3;
        StartCoroutine(BallSpawning());
        StartCoroutine(BallSpeadIncrise());
    }
    public void StopTheGame()
    {
        StopAllCoroutines();
    }
    public void FailBall()
    {
        GameManager.LostHealth(0);
    }
    public void CheckBall(int i)
    {
        switch (i)
        {
            case 0:
                if(BasketBall.Count > 0)
                {
                    Animator anim = BasketBall[0].GetComponent<Animator>();
                    anim.Play("Explosion");
                    
                    Destroy(BasketBall[0]);
                    BasketBall.RemoveAt(0);
                    GameManager.ScoreAdd();
                }
                else
                {
                    GameManager.LostHealth(1);
                }
                break;
            case 1:
                if(FootBall.Count > 0)
                {
                    Destroy(FootBall[0]);
                    FootBall.RemoveAt(0);
                    GameManager.ScoreAdd();

                }
                else
                {
                    GameManager.LostHealth(1);
                }
                break;
            case 2:
                if(TennisBall.Count > 0)
                {
                    Destroy(TennisBall[0]);
                    TennisBall.RemoveAt(0);
                    GameManager.ScoreAdd();

                }
                else
                {
                    GameManager.LostHealth(1);
                }
                break;
            case 3:
                if(VolleyBall.Count > 0)
                {
                    Destroy(VolleyBall[0]);
                    VolleyBall.RemoveAt(0);
                    GameManager.ScoreAdd();

                }
                else
                {
                    GameManager.LostHealth(1);
                }
                break;
        }
    }
    public void RemoveFromList(int i)
    {
        if (i == 0)
            BasketBall.RemoveAt(0);
        else if (i == 1)
            FootBall.RemoveAt(0);
        else if (i == 2)
            TennisBall.RemoveAt(0);
        else if (i == 3)
            VolleyBall.RemoveAt(0);
    }
    public void SpawnBall()
    {
        float x = Random.Range(-2.5f, 2.5f);
        int ballIndex = Random.Range(0,Balls.Length-1);
        var Bal = Instantiate(Balls[ballIndex], new Vector3(x, 6, 0), Quaternion.identity);
        if(ballIndex == 0)
            BasketBall.Add(Bal);
        else if(ballIndex == 1)
            FootBall.Add(Bal);
        else if (ballIndex == 2)
            TennisBall.Add(Bal);
        else if (ballIndex == 3)
            VolleyBall.Add(Bal);


    }

    IEnumerator BallSpawning()
    {
        while (_game)
        {
            SpawnBall();
            yield return new WaitForSeconds(Random.Range(_minBallSpeed, MaxBallSpeed));
        }
        
    }
    IEnumerator BallSpeadIncrise()
    {
        while(_game)
        {
            if (_minBallSpeed > 0.4f)
                _minBallSpeed -= 0.1f;
            if (MaxBallSpeed > _minBallSpeed + 0.5f)
                MaxBallSpeed -= 0.05f;
            yield return new WaitForSeconds(1);
        }
    }
}
