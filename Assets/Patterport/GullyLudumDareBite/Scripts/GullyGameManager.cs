using Patterport.Gully.GameType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GullyGameManager : MonoBehaviour
{
    [SerializeField] GameSettings _settings;
    [SerializeField] GameUI _gameUI;
    [SerializeField] Player _player;

    [Header("Game Mode")]
    [SerializeField] List<GameMode> _gameModes;
    public List<GameMode> _roundGameMode; //For testing
    GameMode _currentMode;


    [SerializeField]float _fakeTimer = 10;
    private GameState _currentState;

    private float _timeBonus = 10; //Every 10 seconds
    int _roundIndex = 0;//This is the index within the round
    int _intensity = 0; //Intensity is the global round


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

    public GameMode currentMode
    {
        get { return this._currentMode; }
    }

    void Start()
    {
        this._player.DisableControls();
        this._currentState = GameState.Starting;
        this._gameUI.HideGameOverText();
        Random.seed = this._settings.seed; // Oh yeah! Bring on the chaos!

    }

    private void OnEnable()
    {
        foreach(GameMode mode in this._gameModes)
        {
            mode.SetGameManager(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimer();

        if (this._currentState == GameState.Playing)
        {
            DoGame();
        }
    }

    void CheckTimer()
    { 
        this._fakeTimer -= Time.deltaTime;

        if (this._fakeTimer <= 0)
        {
            this._fakeTimer = 999;
            switch (this._currentState)
            {
                case GameState.Starting:
                    this._currentState = GameState.Playing;
                    this._player.EnableControls();

                    ScrambleModes();
                    break;
                case GameState.Playing:
                    this._gameUI.ShowGameOverText();
                    break;
                case GameState.Over:
                    GameOver();
                    break;
            }
        }
    }

    public void ScrambleModes()
    {
        List<GameMode> tempModes = new List<GameMode>();
        List<GameMode> scrambledMode = new List<GameMode>();

        for (int i = 1; i < this._gameModes.Count; i++)
        {
            tempModes.Add(this._gameModes[i]);
            print("add" + i);
        }

        while(tempModes.Count > 0)
        {
            int index = Random.Range(0, tempModes.Count);
            scrambledMode.Add(tempModes[index]);

            tempModes.RemoveAt(index);
        }

        if (scrambledMode.Count > 1)
        {
            scrambledMode.Insert(Random.Range(1, scrambledMode.Count), this._gameModes[0]);
        }
        else
        {
            scrambledMode.Add(this._gameModes[0]);
        }

        this._roundGameMode = scrambledMode;
        this._roundIndex = 0;
        this._currentMode = this._roundGameMode[this._roundIndex];

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

    public void OnGameOverCalled()
    {
        this._currentState = GameState.Over;
        this._fakeTimer = 10; //However 
        this._gameUI.ShowGameOverText();
        this._player.DisableControls();

    }

    void DoGame()
    {
        this._currentMode.GameUpdate(Time.deltaTime);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
