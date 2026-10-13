using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastGun : MonoBehaviour
{
    public float range = 100f;

    public ParticleSystem muzzleFlash;
    public GameObject damagePS;

    public Camera fpsCam;

    public void Shoot()
    {
        muzzleFlash.Play();
        FindObjectOfType<AudioManager>().Play("pistol");
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            
            DroneController droneController = hit.transform.GetComponent<DroneController>();
            if (droneController != null)
            {
                FindObjectOfType<AudioManager>().Play("metal");
                droneController.blastDamage();
            }

            GameObject impactPS = Instantiate(damagePS, hit.point, Quaternion.identity);
            Destroy(impactPS, 2f);
        }

    }
}
