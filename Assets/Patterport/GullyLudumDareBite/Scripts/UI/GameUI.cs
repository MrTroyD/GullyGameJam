using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameUI : MonoBehaviour
{
    [SerializeField] GullyGameManager _gameManager;
    [SerializeField] TMP_Text _timer;
    [SerializeField] TMP_Text _gameOverText; //Leaving it a Text Mesh Pro instead of a game object because I just might do an effect later. :-\

    internal void HideGameOverText()
    {
        //If I'm a good little developer I have this hidden by default in Unity
        this._gameOverText.gameObject.SetActive(false); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this._timer.text = this._gameManager.timer.ToString("00");
    }

    public void ShowGameOverText()
    {
        this._gameOverText.gameObject.SetActive(true);
    }
}
