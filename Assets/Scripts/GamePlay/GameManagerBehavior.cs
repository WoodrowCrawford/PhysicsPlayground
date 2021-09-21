using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    [SerializeField]
    private PlayerBehavior _player;

    public GameObject winScreen;


    public bool _gameWon = false;


    private void Awake()
    {
        //Gets all the components
        _player = GetComponent<PlayerBehavior>();
        

    }

    //Starts the game
    public void StartGame()
    {
        SceneManager.LoadScene("PlayGround");
    }


    //Reloads the Playground scene
    public void RestartGame()
    {
        SceneManager.LoadScene("Playground");
    }


    private void Start()
    {
        winScreen.SetActive(false);
    }

    private void Update()
    {
        if (_gameWon == true)
        {
            winScreen.SetActive(true);
        }
        else
        {
            winScreen.SetActive(false);
        }
    }

}
