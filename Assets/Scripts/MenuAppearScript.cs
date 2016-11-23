using UnityEngine;
using System.Collections;

public class MenuAppearScript : MonoBehaviour
{

    public GameObject menu; // Assign in inspector
    public bool isShowing;
    

    void Start()
    {
        menu.SetActive(false);
        Cursor.visible = false;
    }


    void Update()
    {
        
        if (Input.GetKeyDown("escape"))
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                Cursor.visible = true;
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                Cursor.visible = false;
            }
        }
        
    }
}