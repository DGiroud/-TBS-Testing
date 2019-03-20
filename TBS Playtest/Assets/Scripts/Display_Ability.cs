using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_Ability : MonoBehaviour
{

    public Button scrollLeft;
    public Button scrollRight;

    private Animator anim;

    public bool disLeft;
    public bool disRight;

    public bool isLeft;
    public bool isMid;
    public bool isRight;

    public void Awake()
    {
        anim = transform.GetComponent<Animator>();

        anim.SetBool("Mid", false);
        anim.SetBool("Left", false);
        anim.SetBool("Right", false);        
            

        if (isMid)
            anim.SetBool("Mid", true);

        if (isLeft)
            anim.SetBool("Left", true);

        if (isRight)
            anim.SetBool("Right", true);
    }

    private void Update()
    {
        if (disLeft)
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .5f && !anim.IsInTransition(0))
            {
                disLeft = false;
                scrollLeft.interactable = false;
            }

        if (disRight)
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .5f && !anim.IsInTransition(0))
            {
                disRight = false;
                scrollRight.interactable = false;
            }

        if (Movement.gameStarted)
        {
            scrollRight.interactable = false;
            scrollLeft.interactable = false;
        }

    }

    public void MoveLeft()
    {
        if (anim.GetBool("Mid") == true)
        {
            isLeft = true;
            isMid = false;

            anim.SetBool("Left", true);
            anim.SetBool("Mid", false);
            anim.SetBool("Right", false);

            disLeft = true;
            scrollRight.interactable = true;
        }

        if (anim.GetBool("Right") == true)
        {
            isMid = true;
            isRight = false;

            anim.SetBool("Left", false);
            anim.SetBool("Mid", true);
            anim.SetBool("Right", false);


            scrollLeft.interactable = true;
            scrollRight.interactable = true;

        }
    }

    public void MoveRight()
    {
        if (anim.GetBool("Mid") == true)
        {
            isRight = true;
            isMid = false;

            anim.SetBool("Left", false);
            anim.SetBool("Mid", false);
            anim.SetBool("Right", true);


            scrollLeft.interactable = true;
            disRight = true;

        }

        if (anim.GetBool("Left") == true)
        {
            isMid = true;
            isLeft = false;

            anim.SetBool("Left", false);
            anim.SetBool("Mid", true);
            anim.SetBool("Right", false);


            scrollLeft.interactable = true;
            scrollRight.interactable = true;

        }
    }
}
