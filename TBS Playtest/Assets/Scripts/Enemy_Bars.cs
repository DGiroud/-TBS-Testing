using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Bars : MonoBehaviour {
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

    public Enemy_Organiser org;
    public GameObject dets;
    private Image HI;

    private bool gameStarted;

    private void Awake()
    {
        org = dets.GetComponent<Enemy_Organiser>();
        mHImage = mHImage.GetComponent<Image>();
        cHImage = cHImage.GetComponent<Image>();

        HI = transform.GetComponent<Image>();
    }

    private void Update()
    {      

        cHImage.fillAmount = currentHealth / 5;

        if (currentHealth >= org.deets[org.classNumber].health)
       {
           healthIncrease.interactable = false;
       }
       else healthIncrease.interactable = true;

        if (currentHealth <= 0)
        {
            healthDecrease.interactable = false;
        }
        else healthDecrease.interactable = true;

        if (highlighted)
        {
            HI.color = highlightColor;
        }
        else HI.color = standardColor;


        if (Movement.gameStarted)

            if (!gameStarted)
            {
                gameStarted = true;
                currentHealth = org.deets[org.classNumber].health;
                mHImage.fillAmount = org.deets[org.classNumber].health / 5;
            }
        

    }

    public void UpdateHealth()
    {
        mHImage.fillAmount = org.deets[org.classNumber].health / 5;        
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
