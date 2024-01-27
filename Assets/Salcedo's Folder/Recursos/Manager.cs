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


    [Header("SpawnPoint")]
    private GameObject Player;
    public Vector3 SpawnPoint = new Vector3(-43f, 0.6f, -37.5f);              //Pos Inicial
    private bool Tecnologico = false;


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

    private void OnLevelWasLoaded(int level)                                             //Para el regreso en el spawnpoint       
    {

        if (Tecnologico)                                                               //si estamos regresando al tec
        {
            Time.timeScale = 1f;
            Player = GameObject.FindGameObjectWithTag("Player");
            //Debug.Log("Regreso al tec y actualice pos");
            Player.transform.position = SpawnPoint;
            Tecnologico = false;
        }
    }



    public void CallCambiarResolucion(Resolution Res, bool PantallaCompleta)
    {

        Screen.SetResolution(Res.width, Res.height, PantallaCompleta);  //Seteamos la resolucion
        //print("Cambie resolucion: " + ResolucionesOptions[indexRes].width.ToString() + "x" + ResolucionesOptions[indexRes].height.ToString() );
        //print(PantallaCompleta);
    }

    public void CambioDeEscena(string Escena, Vector3 SpawnLocation, float TiempoEspera)
    {

        if (Escena == "TecnologicoRecorridoLibre")                              //Si vamos al tecnologicos preparamos el trigger
        {
            Tecnologico = true;
        }

        else

        {
            SpawnPoint = SpawnLocation;                                         //Si no vamos al tecnologico guardamos el spawnpoint
        }

        StartCoroutine(CambiarDeEscena(Escena, TiempoEspera));                  //Cambiamos de Escena

    }

    IEnumerator CambiarDeEscena(string Escena, float TiempoEspera)
    {

        yield return new WaitForSeconds(TiempoEspera);
        SceneManager.LoadScene(Escena);
        //Debug.Log("Entre al Cambio");

    }
}
