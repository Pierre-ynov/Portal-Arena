using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{

    // Update is called once per frame
    public void ReturnMenu()
    {
        UISoundManagerScript.soundInstance.PlaySound();
        SceneManager.LoadScene("Début");
    }

}
