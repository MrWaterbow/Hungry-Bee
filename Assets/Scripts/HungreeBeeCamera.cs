using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungreeBeeCamera : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 30);
    }
}
