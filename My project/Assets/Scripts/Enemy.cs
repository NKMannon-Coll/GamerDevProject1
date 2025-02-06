using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed = 10f;

    void Update()
    {
        if (player != null) 
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            float angleRad = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x);
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * angleRad);
        }
    }

    /*private void OnParticleTrigger(GameObject collision)
    {
        
    }*/



}
