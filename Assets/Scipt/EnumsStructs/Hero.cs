using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
using NPC.Ally;

public class Hero : MonoBehaviour
{
    float tempDistan;
    float balas= 0;
    GameObject arma;
    public Juego miJueguito;
    private void Awake()
    {
        gameObject.transform.tag = "Herue";
        
    }
    void Start()
    {
        miJueguito = GameObject.FindObjectOfType<Juego>();
        Zombi.textoZom = Zombi.gusto;
        Ninja.textoNinja = Ninja.ataque;

        gameObject.AddComponent(typeof(Player));
        GameObject cara = new GameObject();
        cara.AddComponent(typeof(Camera));
        cara.AddComponent(typeof(Ojos));//codigo de camara
        
        gameObject.GetComponent<Player>().mirar = cara.GetComponent<Ojos>();
        cara.transform.SetParent(gameObject.transform);
        cara.transform.localPosition = new Vector3 (0, 0.45f, 0.3f);
    }
    public void Update()
    {
        
        if (balas > 0 )
        {
            if (Juego.vivo == true && Juego.mostro > 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    arma = Instantiate(Juego.armaEstatica, Vector3.zero, Quaternion.identity);
                    arma.transform.SetParent(gameObject.transform, false);
                    arma.transform.localPosition = new Vector3(0.2f, 0.3f, 0.6f);
                    balas = balas - 1;
                    Juego.kunais = balas.ToString();
                }
            }
        }
        GameObject citi = null;
        GameObject zombiz = null;
        GameObject ninya = null;// GameObject que almacena a todos los Zombis en la esena
        foreach (Zombi zombi in Transform.FindObjectsOfType<Zombi>()) //Foreach que recorre la esena del juego mirando cuantos Zombis hay
        {
            tempDistan = Vector3.Distance(zombi.transform.position, transform.position); // variable para almacenar la distancia de los Zombis al Herue
            if (tempDistan <= ReguladorNPC.visionRadius)
                zombiz = zombi.gameObject;
        }
        foreach (Ninja ninja in Transform.FindObjectsOfType<Ninja>()) //Foreach que recorre la esena del juego mirando cuantos Zombis hay
        {
            tempDistan = Vector3.Distance(ninja.transform.position, transform.position); // variable para almacenar la distancia de los Zombis al Herue
            if (tempDistan <= ReguladorNPC.visionRadius)
                ninya = ninja.gameObject;
        }
        foreach (Ciudadano city in Transform.FindObjectsOfType<Ciudadano>()) //Foreach que recorre la esena del juego mirando cuantos Zombis hay
        {
            tempDistan = Vector3.Distance(city.transform.position, transform.position); // variable para almacenar la distancia de los Zombis al Herue
            if (tempDistan <= ReguladorNPC.visionRadius)
                citi = city.gameObject;
        }
        // If que mostrara el mensaje de los Zombis al perseguir si estan en el radio de vicion
        if (zombiz != null)
            Juego.mensajeEnemi = Zombi.gusto;
        else if (ninya != null)
            Juego.mensajeEnemi = Ninja.ataque;
        else
            Juego.mensajeEnemi = "";

        if (citi != null)
            Juego.mensajeCyti = Ciudadano.yoSoy;
        else
            Juego.mensajeCyti = "";
        
    }
    private void OnCollisionEnter  (Collision collision)
    {
        if (collision.transform.tag == "item")
        { balas = balas+6;
            Destroy(collision.gameObject);
            Juego.kunais = balas.ToString();
        }
    }
    
}