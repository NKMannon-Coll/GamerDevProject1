using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;

    void Update()
    {
        if (player != null) 
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    /*private void OnParticleTrigger(GameObject collision)
    {
        
    }*/



}
