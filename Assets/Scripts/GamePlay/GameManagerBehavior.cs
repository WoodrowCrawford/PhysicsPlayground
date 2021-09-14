using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{
    private PlayerBehavior _player;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private GameObject _checkpoint;


    private void Awake()
    {
        //Gets the component of the player Behavior script
        _player = GetComponent<PlayerBehavior>();
        _animator = GetComponent<Animator>();
        _checkpoint = GetComponent<GameObject>();
    }

    //Reloads the Playground scene
    public void RestartGame()
    {
        SceneManager.LoadScene("Playground");
    }

    private void Start()
    {
        _animator.enabled = true;
    }

    private void Update()
    {
        
    }
}
