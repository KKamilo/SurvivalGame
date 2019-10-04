using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally; //se llama el Namespaces que tiene encapsulado la clase Ciudadano
using NPC.Enemy; //se llama el Namespaces que tiene encapsulado la clase Zombi
using UnityEngine.UI;

public class Juego : MonoBehaviour //Generador
{
    public static int cyti = 0; // variable de contador para mostrar cuantos ciudadanos hay
    public static int zombis = 0; // variable de contador para mostrar cuantos Zombis hay
    public static int ninjas = 0;
    public static int mostro;
    public  int enemy= 1;
    public static int vida = 1;
    public Text textZ; // testo UI que es usado como contador de Zombis
    public Text textC; // testo UI que es usado como contador de Aldeanos
    public Text textoN;
    public Text salud;
    public Text mensajesEnemy;
    public Text mensaje;
    public Text municion;
    public static bool vivo = true; // Bool de verificador de vida
    public static string mensajeEnemi;
    public static string mensajeCyti;
    public static string kunais;
    public static GameObject perder;
    public static GameObject ganas;


    public GameObject arma;//para colocar el prefat del arma
    public static GameObject armaEstatica;
    public Color colo;
    readonly int cantidad; //variable de Readonly para la creacion de los cubos
    public Juego() // costructor para inicialisar el Readonly 
    {
        System.Random rnd = new System.Random(); //se creo una bariable Random 
        cantidad = rnd.Next(5, 25);// se le agrega los parametros para la variable creada anterior mente
    }
    public static float hSpied;//variable estatica para la velocidad del herue
    
    void Awake()
    {
        armaEstatica = arma;
        perder = GameObject.Find("Image");// imajen que saldra al perder
        perder.SetActive(false);// se apaga la imajen para que no salga al principio
        ganas = GameObject.Find("YouWin");
        ganas.SetActive(false);
        hSpied = Random.Range(0.1f, 0.5f);
        int i = 0;
        int k = 0;
        while (i < cantidad)
        {
            int n = Random.Range(1, 4);
            GameObject objec = GameObject.CreatePrimitive(PrimitiveType.Cube);
            objec.AddComponent<Rigidbody>();
            Vector3 v = new Vector3();
            v.x = Random.Range(-30, 39);
            v.z = Random.Range(-39, 39);
            objec.transform.position = v;
            if (i == 0 && k == 0)
            {
                objec.GetComponent<Renderer>().material.color = colo;
                objec.AddComponent(typeof(Hero));
                k++;
            }
            else
            {
                switch (n)
                {
                    case 1:
                        objec.AddComponent(typeof(Zombi));
                        break;
                    case 2:
                        objec.AddComponent(typeof(Ciudadano));
                        break;
                    case 3:
                        objec.AddComponent(typeof(Ninja));
                        break;
                }
            }
            i++;
        }
        foreach (Zombi zombi in Transform.FindObjectsOfType<Zombi>()) //Usamos Transform.FindObjectsOfType para buscar el objetoreferente al zombi en la esena
        {
            zombis = zombis + 1;
        }
        foreach (Ciudadano aldeano in Transform.FindObjectsOfType<Ciudadano>()) //Usamos Transform.FindObjectsOfType para buscar el objetoreferente al ciudadano en la esena
        {
            cyti = cyti + 1;
        }
        foreach (Ninja ninja in Transform.FindObjectsOfType<Ninja>())
        {
            ninjas = ninjas + 1;
        }

    }
    public void Update ()
    {
        textZ.text = "Zombis: " + zombis; // modifica el texto del cambas y muestra el numero de enemigos
        textC.text = "Aldeanos:" + cyti; // modifica el texto del cambas y muestra el numero de aliados
        textoN.text = "Ninjas: " + ninjas;
        salud.text = "Vida: " + vida;
        mensajesEnemy.text = mensajeEnemi;
        mensaje.text = mensajeCyti;
        municion.text = "Kunais: "+kunais;
        enemy = zombis + ninjas;
        mostro = enemy;
        if (enemy == 0)
        {
            Juego.ganas.SetActive(true);
            Juego.vivo = false;
        }
    }

}