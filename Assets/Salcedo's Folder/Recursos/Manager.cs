using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    [Header("Config")]
    public bool ItsMyFirstDay = true;
    public int IndexRes;
    public bool PantallaCompleta;
    public float Volumen;


    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)                             //Evitamos duplicados
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }


    public void CallCambiarResolucion(Resolution Res, bool PantallaCompleta)
    {

        Screen.SetResolution(Res.width, Res.height, PantallaCompleta);  //Seteamos la resolucion
        //print("Cambie resolucion: " + ResolucionesOptions[indexRes].width.ToString() + "x" + ResolucionesOptions[indexRes].height.ToString() );
        //print(PantallaCompleta);
    }

    public void CambioDeEscena(string Escena)
    {
        SceneManager.LoadScene(Escena);
    }

}
