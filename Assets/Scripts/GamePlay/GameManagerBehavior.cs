using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{
    private PlayerBehavior _player;
    private Animator _animator;


    private void Awake()
    {
        //Gets the component of the player Behavior script
        _player = GetComponent<PlayerBehavior>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animator.enabled = true;
    }
}
