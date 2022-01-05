using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    
    private int loadTime = 500;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (loadTime != 0)
        {
            loadTime--;
            // JR 15/11/2020 Permet d'empécher le joueur d'attaquer
            GameManager.IsInputEnabled = false;
        }
        else
        {
            // JR 15/11/2020 Permet au joueur d'attaquer
            GameManager.IsInputEnabled = true;
        }
    }
}
