using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{

    public void doExit()
    {
        print("Application Closed");
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Application.Quit();
            print("App closed");
        }
    }

}
