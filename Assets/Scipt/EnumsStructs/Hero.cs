using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
using NPC.Ally;

public class Hero : MonoBehaviour
{
    float tempDistan;
    float cantidad;
    private void Awake()
    {
        gameObject.transform.tag = "Herue";
        cantidad =9f;

    }
    void Start()
    {
        Zombi.textoZom = Zombi.gusto;
        Ninja.textoNinja = Ninja.ataque;
        
        gameObject.AddComponent(typeof(Player));
        GameObject cara = new GameObject();
        cara.AddComponent(typeof(Camera));
        cara.AddComponent(typeof(Ojos));//codigo de camara

        gameObject.GetComponent<Player>().mirar = cara.GetComponent<Ojos>();
        cara.transform.SetParent(gameObject.transform);
        cara.transform.localPosition = new Vector3 (0, 0.5f, 0);
    }
    public void Update()
    {
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
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Juego.balas = cantidad.ToString();
    }
    
}