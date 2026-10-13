using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{

    bool moveDrone = false;

    Transform portal;
    public float speed;
    public float x1, x2;
    public float y1, y2;
    public float z1, z2;
    Vector3 targetPos;
    float Xoffset;
    float Yoffset;
    float Zoffset;
    // Start is called before the first frame update
    void Start()
    {
        portal = GameObject.FindGameObjectWithTag("Portal").transform;
        Xoffset = Random.Range(-(x1), x2);
        Yoffset = Random.Range(y1, y2);
        Zoffset = Random.Range(-(z1), z2);
        //Zoffset = 0f;
        targetPos = new Vector3(portal.position.x + Xoffset, portal.position.y + Yoffset, portal.position.z + Zoffset);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDrone)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if (transform.position == targetPos)
            {
                moveDrone = false;
            }
        }
    }

    public void MoveDrone()
    {
        moveDrone = true;
        portal = GameObject.FindGameObjectWithTag("Portal").transform;
        Xoffset = Random.Range(-(x1), x2);
        Yoffset = Random.Range(y1, y2);
        Zoffset = Random.Range(-(z1), z2);
        targetPos = new Vector3(portal.position.x + Xoffset, portal.position.y + Yoffset, portal.position.z + Zoffset);
    }
}
