using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Main_MenuManager : MonoBehaviour
{
    public GameObject[] Menus;


    private int IndexMenuActual = 0;
    private static Manager manager;

    [Header("Opciones")]
    public float Volumen = 100;
    [SerializeField] AudioSource audioSource;
    [SerializeField] private Slider VolumenSlider;
    [SerializeField] TextMeshProUGUI VolumenTex;
    [SerializeField] TMP_Dropdown ResolucionesDropdown;
    [SerializeField] Resolution[] ResolucionesOptions;
    [SerializeField] private int indexRes;
    [SerializeField] Toggle PantallaCompletaToggle;

    [SerializeField] private bool PantallaCompleta;



    private void Start()
    {

        manager = Manager.instance;

        if (manager.ItsMyFirstDay == false)
        {


            Volumen = manager.Volumen;
            VolumenSlider.value = Volumen;
            
            indexRes = manager.IndexRes;
            PantallaCompleta = manager.PantallaCompleta;

            SetearResoluciones();                                     //Seteamos la resolucion 
            GestionVolumen();
        }
        else
        {
            //print("Its my first Day");
            SetearResoluciones();                                     //Seteamos la resolucion maxima
            GestionVolumen();                                         //Actualizamos al vol max.
            manager.ItsMyFirstDay = false;
        }


    }

    public void CambiarEscena(string Escena)
    {
        PasoDeDatos();
        manager.CambioDeEscena(Escena);
    }


    public void PasoDeDatos()
    {
        
        manager.IndexRes = indexRes;
        manager.PantallaCompleta = PantallaCompleta;
        
        manager.Volumen = Volumen;
    }
    public void ActivarMenu(int IndexMenuTarget)
    {
        Menus[IndexMenuTarget].SetActive(true);
        Menus[IndexMenuActual].SetActive(false);
        IndexMenuActual = IndexMenuTarget;
    }
    public void SalirDeLaAplicacion()
    {
        Application.Quit();                                           //Salir
    }

    public void GestionVolumen()
    {
        Volumen = VolumenSlider.value;                                //Tomamos el valor dle slider
        VolumenTex.text = VolumenSlider.value.ToString();             //Lo pasamos a string
        float Volumensource = Volumen / 100;                          //Lo pasamos de 0/100
        AudioListener.volume = Volumen / 10;                                //Seteamos el volumen Global (Escala 0-1)

    }


    private void SetearResoluciones()
    {

        ResolucionesOptions = Screen.resolutions;
        ResolucionesDropdown.ClearOptions();                                                              //Limpiamos las opciones
        List<string> ResolucionesString = new List<string>();                                            //Lista 

        foreach (Resolution res in ResolucionesOptions)
        {
            //print(res.width + "x" + res.height);
            ResolucionesString.Add(new string(res.width.ToString() + " X " + res.height.ToString()));     //Guardamos todas las resoluciones como texto
        }

        ResolucionesDropdown.AddOptions(ResolucionesString);                                              // Creamos del drop

        if (manager.ItsMyFirstDay == true)                                                           //Si es la primera iteracion resolucion maxima
        {
            PantallaCompletaToggle.isOn = true;
            PantallaCompleta = true;
            Screen.SetResolution(ResolucionesOptions[ResolucionesOptions.Length - 1].width, ResolucionesOptions[ResolucionesOptions.Length - 1].height, PantallaCompleta);   //Asignamos la Resolucion maxima
            ResolucionesDropdown.value = ResolucionesOptions.Length - 1;                                  //Actualizamos el dropdown
            //print("La pantalla esta: " + PantallaCompleta);
        }
        else
        {
            ResolucionesDropdown.value = indexRes;
            PantallaCompletaToggle.isOn = PantallaCompleta;
            //print("La pantalla esta: " + PantallaCompleta);
        }
    }


    public void CambiarResolucion()
    {

        indexRes = ResolucionesDropdown.value;                                                            //Resolucion seleccionada
        manager.CallCambiarResolucion(ResolucionesOptions[indexRes], PantallaCompleta);              //Aplicamos los cambios
    }


    public void CambiarPantallaCompleta()
    {
        PantallaCompleta = PantallaCompletaToggle.isOn;
        CambiarResolucion();
    }

}
