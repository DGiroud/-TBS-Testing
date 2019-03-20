using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Details_Panel : MonoBehaviour
{
    public Image HP;
    public Image MOV;


    public void Awake()
    {
        HP = HP.GetComponent<Image>();
        MOV = MOV.GetComponent<Image>();
    }
    public void StatUpdate(float hP, float mOV)
    {
        HP.fillAmount = hP;
        MOV.fillAmount = mOV;
    }
}
