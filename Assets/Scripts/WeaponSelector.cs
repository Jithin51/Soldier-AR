using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public GameObject weaponHolder;

    //Guns
    public GameObject normalGun;
    public GameObject iceGun;
    public GameObject hackGun;
    public GameObject electricGun;

    //ShootButtons
    public GameObject normalButton;
    public GameObject iceButton;
    public GameObject hackButton;
    public GameObject electricButton;

    private void Start()
    {
        onNormalGun();
    }

    public void selectWeapon()
    {
        weaponHolder.SetActive(true);
    }

    public void onNormalGun()
    {
        if (!normalGun.activeInHierarchy)
        {
            normalGun.SetActive(true);
            normalButton.SetActive(true);
            FindObjectOfType<AudioManager>().Play("reload");
            iceGun.SetActive(false);
            iceButton.SetActive(false);
            hackGun.SetActive(false);
            hackButton.SetActive(false);
            electricGun.SetActive(false);
            electricButton.SetActive(false);
            weaponHolder.SetActive(false);
        }
        
    }

    public void onIceGun()
    {
        if (!iceGun.activeInHierarchy)
        {
            iceGun.SetActive(true);
            iceButton.SetActive(true);
            FindObjectOfType<AudioManager>().Play("reload");
            normalGun.SetActive(false);
            normalButton.SetActive(false);
            hackGun.SetActive(false);
            hackButton.SetActive(false);
            electricGun.SetActive(false);
            electricButton.SetActive(false);
            weaponHolder.SetActive(false);
        }
    }

    public void onHackGun()
    {
        if (!hackGun.activeInHierarchy)
        {
            hackGun.SetActive(true);
            hackButton.SetActive(true);
            FindObjectOfType<AudioManager>().Play("reload");
            normalGun.SetActive(false);
            normalButton.SetActive(false);
            iceGun.SetActive(false);
            iceButton.SetActive(false);
            electricGun.SetActive(false);
            electricButton.SetActive(false);
            weaponHolder.SetActive(false);
        }
    }

    public void onElectricGun() 
    {
        if (!electricGun.activeInHierarchy)
        {
            electricGun.SetActive(true);
            electricButton.SetActive(true);
            FindObjectOfType<AudioManager>().Play("reload");
            hackGun.SetActive(false);
            hackButton.SetActive(false);
            normalGun.SetActive(false);
            normalButton.SetActive(false);
            iceGun.SetActive(false);
            iceButton.SetActive(false);
            weaponHolder.SetActive(false);
        }
    }
}
