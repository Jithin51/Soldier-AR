using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackedBullet : MonoBehaviour
{
    public float damage = 10f;
    public float speed;
    Transform player;
    private Vector3 target;
    bool isHacked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHacked)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
            {
                DestroyProjectile();
            }
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject); ;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + "Hit the drone");
        DroneController droneController = other.transform.GetComponent<DroneController>();
        droneController.TakeDamage(damage);
    }

    public void droneHacked(GameObject t)
    {
        Debug.Log("Hacked");
        player = t.transform;
        target = player.position;
        isHacked = true;
    }
}
