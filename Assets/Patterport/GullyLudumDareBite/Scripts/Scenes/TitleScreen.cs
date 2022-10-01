using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{

    [SerializeField] Button _startButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Do something cute/cool here later
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GullyGame");
    }
}
