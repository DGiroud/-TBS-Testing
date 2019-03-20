using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Organiser : MonoBehaviour {

    public List<Enemy_Details> deets;

    public float move;
    public int classNumber = 0;

    public GameObject panel;

    public Button scrollLeft;
    public Button scrollRight;

    private void Update()
    {
        if (!Movement.gameStarted)
        {
            if (classNumber <= 0)
                scrollLeft.interactable = false;
            else
                scrollLeft.interactable = true;

            if (classNumber >= deets.Count - 1)
                scrollRight.interactable = false;
            else
                scrollRight.interactable = true;
        }else
        {
            scrollLeft.interactable = false;
            scrollRight.interactable = false;
        }

        

    }

    public void ScrollLeft()
    {
        panel.transform.position += new Vector3(move, 0, 0);
        classNumber--;
    }

    public void ScrollRight()
    {
        panel.transform.position -= new Vector3(move, 0, 0);
        classNumber++;
    }
}
