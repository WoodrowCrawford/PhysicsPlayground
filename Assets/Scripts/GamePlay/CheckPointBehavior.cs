using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBehavior : MonoBehaviour
{

    public PlayerBehavior player;

    public GameObject checkPoint;


    private void Awake()
    {
        player.GetComponent<PlayerBehavior>();
        checkPoint.GetComponent<GameObject>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("CheckPoint"))
        {
            player.touchedCheckPoint = true;
            Debug.Log("Check Point Reached!");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
