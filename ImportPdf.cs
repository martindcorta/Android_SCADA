using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ImportPdf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //UnityWebRequest web = UnityWebRequest.Get("https://dmaenergia.000webhostapp.com/pdf.php");//esta clase de unity me permite realizar peticiones y manejar respuestas HTTP mediante el POST/PUT
        //web.SendWebRequest();// se queda esperando hasta que el pedido es devuelto
        //StartCoroutine(GetText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("Leer")] //esto hace que desde el mismo inspector de unity pueda ejecutar el metodo de forma manual

    public void Leer(System.Action accionAlTerminar)// es publico porqeu a este metodo accedemos desde afuera
    {
        StartCoroutine(CorrutinaLeer(accionAlTerminar));//la corrutina me permite que unity se siga ejecutando mientras nosotros leemos o escribimos 

    }
    private IEnumerator CorrutinaLeer(System.Action accionAlTerminar)
    { //enumero los pasos para realizar la lectura a la nube

        UnityWebRequest web = UnityWebRequest.Get("https://dmaenergia.000webhostapp.com/pdf.php");//esta clase de unity me permite realizar peticiones y manejar respuestas HTTP mediante el POST/PUT
        yield return web.SendWebRequest();// se queda esperando hasta que el pedido es devuelto
        //Una vez que vuelve....
        accionAlTerminar();




    }
    /*
    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://dmaenergia.000webhostapp.com/pdf.php");
        //yield return www.Send();
        yield return www.SendWebRequest();
    }*/

    }
