using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FondoFollowY : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float velocidad;

    void Update()
    {
        Vector3 seguirplayer = new Vector3(transform.position.x, 0.4803f, transform.position.z);

        transform.position = seguirplayer;
        //transform.position = Vector3.MoveTowards(transform.position, seguirplayer, velocidad * Time.deltaTime);
    }
}
