using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameObject selected;

    public RaycastHit hit;
    
    public static bool gameStarted = false;

    private void Start()
    {    
    }

    private void Update()
    {
        Ray ray = transform.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (selected != null)
        {
            if (selected.transform.tag == "Player")
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                    if (selected != null)
                        selected.transform.rotation = Quaternion.Euler(0, 0, 0);


                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                    if (selected != null)
                        selected.transform.rotation = Quaternion.Euler(0, 270, 0);


                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                    if (selected != null)
                        selected.transform.rotation = Quaternion.Euler(0, 180, 0);


                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                    if (selected != null)
                        selected.transform.rotation = Quaternion.Euler(0, 90, 0);
            }

            if (selected.transform.tag == "Enemy")
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                    if (selected != null)
                        selected.GetComponent<Enemy_Stats>().geo.transform.rotation = Quaternion.Euler(0, 0, 0);


                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                    if (selected != null)
                        selected.GetComponent<Enemy_Stats>().geo.transform.rotation = Quaternion.Euler(0, 270, 0);


                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                    if (selected != null)
                        selected.GetComponent<Enemy_Stats>().geo.transform.rotation = Quaternion.Euler(0, 180, 0);


                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                    if (selected != null)
                        selected.GetComponent<Enemy_Stats>().geo.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }




        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                if (hit.transform.tag == "Player")
                {
                    if (selected != null)
                    {
                        if (selected.transform.tag == "Player")
                        {
                            selected.transform.GetComponent<Player>().display.transform.GetComponent<Player_Stats>().abilitySlot.gameObject.SetActive(false);
                            selected.transform.GetComponent<Player>().display.transform.GetComponent<Player_Stats>().highlighted = false;
                        }
                        if (selected.transform.tag == "Enemy")
                        {                            
                            selected.transform.GetComponent<Enemy_Stats>().display.transform.GetComponent<Enemy_Bars>().dets.gameObject.SetActive(false);
                            selected.transform.GetComponent<Enemy_Stats>().display.transform.GetComponent<Enemy_Bars>().highlighted = false;
                        }
                    }

                    selected = hit.transform.gameObject;
                    selected.transform.GetComponent<Player>().display.transform.GetComponent<Player_Stats>().abilitySlot.gameObject.SetActive(true);
                    selected.transform.GetComponent<Player>().display.transform.GetComponent<Player_Stats>().highlighted = true;
                    selected.transform.GetComponent<Player>().display.transform.GetComponent<Player_Stats>().UpdateStats();
                }

               if (hit.transform.tag == "Enemy")
                {
                    if (selected != null)
                    {
                        if (selected.transform.tag == "Player")
                        {
                            selected.transform.GetComponent<Player>().display.transform.GetComponent<Player_Stats>().abilitySlot.gameObject.SetActive(false);
                            selected.transform.GetComponent<Player>().display.transform.GetComponent<Player_Stats>().highlighted = false;
                        }
                        if (selected.transform.tag == "Enemy")
                        {                           
                            selected.transform.GetComponent<Enemy_Stats>().display.transform.GetComponent<Enemy_Bars>().dets.gameObject.SetActive(false);
                            selected.transform.GetComponent<Enemy_Stats>().display.transform.GetComponent<Enemy_Bars>().highlighted = false;
                        }
                    }

                    selected = hit.transform.gameObject;                    
                    selected.transform.GetComponent<Enemy_Stats>().display.transform.GetComponent<Enemy_Bars>().dets.gameObject.SetActive(true);
                    selected.transform.GetComponent<Enemy_Stats>().display.transform.GetComponent<Enemy_Bars>().highlighted = true;
                    selected.transform.GetComponent<Enemy_Stats>().display.transform.GetComponent<Enemy_Bars>().UpdateHealth();
                    //selected.transform.GetComponent<Enemy_Stats>().display.transform.GetComponent<Enemy_Bars>().specialAbilities.Awake();
                }
                

                if (hit.transform.tag == "Tile" && selected != null)
                    selected.transform.position = hit.transform.GetComponent<Tile>().movementPoint.transform.position;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (selected != null)
            {
                if (selected.transform.tag == "Player")
                {
                    selected.transform.GetComponent<Player>().display.transform.GetComponent<Player_Stats>().abilitySlot.gameObject.SetActive(false);
                    selected.transform.GetComponent<Player>().display.transform.GetComponent<Player_Stats>().highlighted = false;
                }
                if (selected.transform.tag == "Enemy")
                {
                    selected.transform.GetComponent<Enemy_Stats>().display.transform.GetComponent<Enemy_Bars>().dets.gameObject.SetActive(false);
                    selected.transform.GetComponent<Enemy_Stats>().display.transform.GetComponent<Enemy_Bars>().highlighted = false;
                }
                selected = null;
                
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameStarted = false;
            SceneManager.LoadScene("Main");
        }
    }

    public void StartGame()
    {
        gameStarted = true;
    }
}
