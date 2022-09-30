using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class HeathBar : MonoBehaviour
{
    public Slider slider;
    public GameObject _Player;
    public Transform respawnPoint;
    public int currentHealth;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        if (slider.value == 0)
        {
            slider.value += 100;
        }
    }

}
