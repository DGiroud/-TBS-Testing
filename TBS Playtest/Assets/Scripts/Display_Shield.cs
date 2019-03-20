using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_Shield : MonoBehaviour
{
    public Image bar;

    public float maxLevel;
    public float currentLevel;

    private void Awake()
    {
        bar = bar.GetComponent<Image>();
    }

    public void Increase()
    {
        if (currentLevel < maxLevel)
        {
            currentLevel += 1;
            bar.fillAmount = currentLevel / maxLevel;
        }
        else return;
    }

    public void Decrease()
    {
        if (currentLevel > 0)
        {
            currentLevel -= 1;
            bar.fillAmount = currentLevel / maxLevel;
        }
        else return;
    }
}
