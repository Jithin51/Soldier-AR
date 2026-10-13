using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    //Player
    Transform player;
    GameObject[] drone;

    //Shooting Controller
    private float timeBtwShots;
    public float startTimeBtwShots;
    public Transform shootPoint;

    //Shooting Object
    public GameObject projectile;
    public GameObject hackedBullets;

    //Gun Flags
    bool isIced = false;
    bool isHacked = false;

    //IceGun Controls
    float IcegunTimer = 3f;
    public GameObject freezeObj;

    //HackGun Controls
    float hackGunTimer = 10f;


    //MoveDrone
    public DroneMovement droneMovement;

    //Health and HealthBar controls
    public float health = 50f;
    public HealthBar healthBar;

    //Icebar controls
    public IceBar iceBar;

    //Explosion
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //drone= GameObject.FindGameObjectsWithTag("Drone");
        
        timeBtwShots = startTimeBtwShots;
        droneMovement.MoveDrone();
        //BulletToShoot = projectile.gameObject;

        //HealthBar Controls
        healthBar.setMaxHealth(health);
        healthBar.setHealth(health);

        //Icebar Controls
        iceBar.setMaxIce(IcegunTimer);
        iceBar.setIce(0f);

    }

    // Update is called once per frame
    void Update()
    {

        //Normal shooting
        if (!isIced && !isHacked)
        {
            transform.LookAt(player);
            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, shootPoint.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
                droneMovement.MoveDrone();
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }


        //Iced
        if (isIced)
        {
            if (IcegunTimer <= 0f)
            {
                isIced = false;
                FindObjectOfType<AudioManager>().Play("IceBreak");
                freezeObj.SetActive(false);
                IcegunTimer = 3f;
                iceBar.setIce(0f);
            }
            else
            {
                IcegunTimer -= Time.deltaTime;
                iceBar.setIce(IcegunTimer);
            }
        }

        //Hacked
        if (isHacked)
        {
            Debug.Log("Is now hacked");
            health = 50f;
            if (drone[0] == null)
            {
                drone = GameObject.FindGameObjectsWithTag("Drone");
                //isHacked = false;
                //return;
            }
            transform.LookAt(drone[0].transform);
            if (timeBtwShots <= 0)
            {
                timeBtwShots = startTimeBtwShots;
                GameObject bullet = Instantiate(hackedBullets, shootPoint.position, Quaternion.identity);
                HackedBullet hackedBulletController = bullet.transform.GetComponent<HackedBullet>();
                hackedBulletController.droneHacked(drone[0]);
                droneMovement.MoveDrone();
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
            if (hackGunTimer <= 0)
            {
                Die();
            }
            else
            {
                hackGunTimer -= Time.deltaTime;
            }
        }
        
    }

    //Drone Life Controller for normal gun
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.setHealth(health);
        if (health <= 0f)
        {
            Die();
        }
    }


    public void IceDamage(float amount)
    {
        isIced = true;
        freezeObj.SetActive(true);
        health -= amount;
        healthBar.setHealth(health);
        if (health <= 0f)
        {
            Die();
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("GotIced");
        }
    }



    public void hackDamage()
    {
        isHacked = true;
        //player = GameObject.FindGameObjectWithTag("Drone").transform;
        drone = GameObject.FindGameObjectsWithTag("Drone");
        transform.LookAt(drone[0].transform);
        //BulletToShoot = hackedBullets;
        //Add hacked effects
    }

    //Drone Life controller for Blast gun
    public void blastDamage()
    {
        Die();
    }


    void Die()
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        FindObjectOfType<AudioManager>().Play("explosion");
        Destroy(explosion, 2f);
        Destroy(gameObject);
    }

}
