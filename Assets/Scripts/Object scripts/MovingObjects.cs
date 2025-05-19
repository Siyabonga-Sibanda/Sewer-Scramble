using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] private ButtonLogic button;
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypoint = 0;

    [SerializeField] private float speed;
    // Update is called once per frame
    void Update()
    {

        if (button.isOn)
        {
            currentWaypoint = 1;
        }
        else { currentWaypoint = 0; }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
    }
}
