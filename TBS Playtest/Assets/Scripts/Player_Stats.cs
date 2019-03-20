using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Stats : MonoBehaviour
{
    [Header("Max Stats")]
    public float maxHealth;
    public float maxMovement;    

    [Header("Current Stats")]
    public float currentHealth;        

    [Header("Bars")]
    public Image mHImage;
    public Image cHImage;
    

    [Header("Buttons")]
    public Button healthIncrease;
    public Button healthDecrease;
    

    [Header("Highlights")]
    public Color standardColor;
    public Color highlightColor;
    public bool highlighted;

    public Details_Panel abilitySlot;
   

    private Image HI;


    private void Awake()
    {
        mHImage = mHImage.GetComponent<Image>();    
        cHImage = cHImage.GetComponent<Image>();

        HI = transform.GetComponent<Image>();
    }

    private void Update()
    {    
        mHImage.fillAmount = maxHealth/5;

        cHImage.fillAmount = currentHealth / 5;

        if (currentHealth >= maxHealth)
        {
            healthIncrease.interactable = false;            
        }else healthIncrease.interactable = true;

        if (currentHealth <= 0)
        {
            healthDecrease.interactable = false;
        }
        else healthDecrease.interactable = true;        

        if (highlighted)
        {
            HI.color = highlightColor;
        }else HI.color = standardColor;

    }

    public void UpdateStats()
    {
        
    }

    public void IncreaseHealth()
    {
        currentHealth += 1.0f;
    }

    public void DecreaseHealth()
    {
        currentHealth -= 1.0f;
    }
   
}
