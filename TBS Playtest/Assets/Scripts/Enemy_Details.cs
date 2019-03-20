using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Details : MonoBehaviour {

    public string className;

    public float health;
    public float move;

    public Text classNam;
    public Image hBar;
    public Image mBar;


    private void Start()
    {
        classNam.text = className;
        hBar.fillAmount = (health / 5);
        mBar.fillAmount = (move / 5);
    }
}
