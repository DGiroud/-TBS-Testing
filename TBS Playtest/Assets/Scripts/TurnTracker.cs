using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnTracker : MonoBehaviour {

    public Text turnTracker;

    public int turnNumber = 0;

    public List<Turnz> players;

    private void Update()
    {
if (Input.GetKeyDown(KeyCode.Space))
        {
            EndTurn();
        }
    }

    public void NextTurn()
    {
        turnNumber++;
        turnTracker.text = turnNumber.ToString();
        foreach (var item in players)
        {
            item.turn.isOn = false;
        }
    }

    public void EndTurn()
    {
        if (transform.GetComponent<Movement>().selected.GetComponent<Turnz>())
        {
            transform.GetComponent<Movement>().selected.GetComponent<Turnz>().turn.isOn = true;
        }
    }
}
