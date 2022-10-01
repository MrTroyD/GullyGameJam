using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GullyGameManager : MonoBehaviour
{
    [SerializeField] GameUI _gameUI;
    float _fakeTimer = 10;
    private GameState _currentState;

    private float _timeBonus = 10; //Every 10 seconds

    public enum GameState
    {
        Starting,
        Playing,
        Over
    }


    public float timer
    {
        get { return this._fakeTimer; }
    }

    void Start()
    {
        this._currentState = GameState.Starting;
        this._gameUI.HideGameOverText();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimer();
    }

    void CheckTimer()
    { 
        this._fakeTimer -= Time.deltaTime;

        if (this._fakeTimer <= 0)
        {
            this._fakeTimer = 99999;
            switch (this._currentState)
            {
                case GameState.Starting:
                    this._currentState = GameState.Playing;
                    break;
                case GameState.Playing:
                    this._currentState = GameState.Over;
                    this._gameUI.ShowGameOverText();
                    break;
                case GameState.Over:
                    GameOver();
                    break;
            }
        }
    }

    public void OnCollectible(GameCollectible.CollectibleType type)
    {
        switch (type)
        {
            case GameCollectible.CollectibleType.TimeBonus:
                this._fakeTimer += this._timeBonus;
                break;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
