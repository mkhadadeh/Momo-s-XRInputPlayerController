using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    const float multiple = 127.3f;
    public Transform[] cylinders;
    public Transform player;
    int currentRing;
    // Start is called before the first frame update
    void Start()
    {
        currentRing = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y < cylinders[currentRing].position.y - 2 * multiple)
        {
            cylinders[currentRing].position -= new Vector3(0, 5 * multiple, 0);
            currentRing = (currentRing + 1) % 5;
        }
    }
}
