using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGun : MonoBehaviour
{
    public float damage = 20f;
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
                droneController.IceDamage(damage);
            }

            GameObject impactPS = Instantiate(damagePS, hit.point, Quaternion.identity);
            Destroy(impactPS, 2f);
        }

    }
}
