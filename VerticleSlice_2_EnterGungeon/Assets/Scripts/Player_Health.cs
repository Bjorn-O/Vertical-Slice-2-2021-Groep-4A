using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Player_Health : MonoBehaviour
{

    int health = 6;

    Vector3 shieldPoint;

    [SerializeField] GameObject[] HealthUI;
    [SerializeField] Sprite[] HealthIcons;

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            AddHealth(2);
        }
    }

    void TakeDamage()
    {
        health -= 1;
        UpdateHealth();
    }


    void AddHealth(int healthAmount)
    {
        health += healthAmount;
        if (health > 6)
        {
            health = 6;
        }
        UpdateHealth();
    }

    void UpdateHealth()
    {
        switch (health)
        {
            case 0:
                HealthUI[0].GetComponent<Image>().sprite = HealthIcons[0];
                break;
            case 1:
                HealthUI[0].GetComponent<Image>().sprite = HealthIcons[1];
                break;
            case 2:
                HealthUI[0].GetComponent<Image>().sprite = HealthIcons[2];
                HealthUI[1].GetComponent<Image>().sprite = HealthIcons[0];
                break;
            case 3:
                HealthUI[0].GetComponent<Image>().sprite = HealthIcons[2];
                HealthUI[1].GetComponent<Image>().sprite = HealthIcons[1];
                break;
            case 4:
                HealthUI[1].GetComponent<Image>().sprite = HealthIcons[2];
                HealthUI[2].GetComponent<Image>().sprite = HealthIcons[0];
                break;
            case 5:
                HealthUI[1].GetComponent<Image>().sprite = HealthIcons[2];
                HealthUI[2].GetComponent<Image>().sprite = HealthIcons[1];
                break;
            case 6:
                HealthUI[2].GetComponent<Image>().sprite = HealthIcons[2];
                break;
        }
    }
}
