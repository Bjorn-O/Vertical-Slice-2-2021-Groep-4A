using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo_UI : MonoBehaviour
{

    int maxAmmo = 8;
    int ammo;

    [SerializeField] GameObject[] ammoUI;
    [SerializeField] Sprite[] ammoIcon;

    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetKey(KeyCode.R))
        {
            ReloadGun();
        }
    }

    void Shoot()
    {
        ammo -= 1;
        UpdateAmmo();
    }

    void ReloadGun()
    {
        for (int i = 0; i < ammoUI.Length; i++)
        {
            ammoUI[i].GetComponent<Image>().sprite = ammoIcon[1];
        }
        ammo = maxAmmo;
    }

    void UpdateAmmo()
    {
        switch (ammo)
        {
            case 0:
                ammoUI[7].GetComponent<Image>().sprite = ammoIcon[0];
                break;
            case 1:
                ammoUI[6].GetComponent<Image>().sprite = ammoIcon[0];
                break;
            case 2:
                ammoUI[5].GetComponent<Image>().sprite = ammoIcon[0];
                break;
            case 3:
                ammoUI[4].GetComponent<Image>().sprite = ammoIcon[0];
                break;
            case 4:
                ammoUI[3].GetComponent<Image>().sprite = ammoIcon[0];
                break;
            case 5:
                ammoUI[2].GetComponent<Image>().sprite = ammoIcon[0];
                break;
            case 6:
                ammoUI[1].GetComponent<Image>().sprite = ammoIcon[0];
                break;
            case 7:
                ammoUI[0].GetComponent<Image>().sprite = ammoIcon[0];
                break;
            default:
                break;
        }
    }
}
