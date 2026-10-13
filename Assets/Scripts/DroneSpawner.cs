using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{

    public GameObject drone;

    private float timeBtwInstantiation;
    public float startTimeBtwInstantiation;


    // Start is called before the first frame update
    void Start()
    {
        timeBtwInstantiation = startTimeBtwInstantiation;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwInstantiation <= 0)
        {
            Instantiate(drone, transform.position, Quaternion.identity);
            timeBtwInstantiation = startTimeBtwInstantiation;
        }
        else
        {
            timeBtwInstantiation -= Time.deltaTime;
        }
    }
}
