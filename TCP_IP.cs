using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Networking;



public class TCP_IP : MonoBehaviour
{
    [System.Serializable]
    public struct estructuraDatosWeb
    {
        [System.Serializable]
        public struct registro
        {
            public int velocidad;
            
        }
        public List<registro> variable;

    }

    public estructuraDatosWeb datos;

    public Transform tabla;
    public GameObject lectura;

    [ContextMenu("Leer")] //esto hace que el isnpector ejecute el metodo

    public void Leer(System.Action accionAlTerminar)
    {
        StartCoroutine(CorrutinaLeer(accionAlTerminar));

    }

    private IEnumerator CorrutinaLeer(System.Action accionAlTerminar)
    {

        UnityWebRequest web = UnityWebRequest.Get("https://dmaenergia.000webhostapp.com/GetInfo.php");
        //UnityWebRequest web = UnityWebRequest.Get("https://dmaenergia.000webhostapp.com/GetVoltaje.php");
        yield return web.SendWebRequest();
        //esperamos a que vuelva
        //volvio

        datos = JsonUtility.FromJson<estructuraDatosWeb>(web.downloadHandler.text);
        accionAlTerminar();




    } //trabaja como una interrupcion, no detiene el proceso de unity al leer

    

    [ContextMenu("Crear tabla")]
    void CrearTabla()
    {
   
            GameObject inst = Instantiate(lectura, tabla);
            inst.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
            inst.name = "Lectura";
            tabla.GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = datos.variable[0].velocidad.ToString();
    

    }

   
    void Start()
    {
        Leer(CrearTabla);

    }
   

}