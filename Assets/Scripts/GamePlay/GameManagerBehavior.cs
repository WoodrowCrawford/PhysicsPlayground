using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    [SerializeField]
    private PlayerBehavior _player;

    [SerializeField]
    private GameObject _checkpoint;

    [SerializeField]
    private GameObject _goal;


    private void Awake()
    {
        //Gets the component of the player Behavior script
        _player = GetComponent<PlayerBehavior>();
        _checkpoint = GetComponent<GameObject>();
        _goal = GetComponent<GameObject>();
        
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
       
    }

    private void Update()
    {
        
    }
}
