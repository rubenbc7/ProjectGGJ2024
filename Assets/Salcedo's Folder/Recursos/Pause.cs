using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject MenuPausaObj;

    public bool Ispaused = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          PauseManagement();
        }

    }

    private void Awake()
    {
        Ispaused = false;
        Time.timeScale = 1.0f;
    }
    public void PauseManagement ()
    {
        if (Ispaused)
        {
            Ispaused = false;
            MenuPausaObj.SetActive(false);
            
            Time.timeScale = 1;


        } else
        {
            Ispaused = true;
            MenuPausaObj.SetActive(true);
            StartCoroutine(Wait());
            
        }
    }

    public void ChangeScene (string Scene)
    {
        Manager.instance.CambioDeEscena(Scene);
    }

    public void ApplicationExit ()
    {
        Application.Quit();                              
    }
    IEnumerator Wait()
    {
       
        yield return new WaitForSeconds(0.35f);
        Time.timeScale = 0;
    }
}
