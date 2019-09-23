using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
using NPC.Ally;

public class Hero : MonoBehaviour
{
    float tempDistan;
    private void Awake()
    {
        gameObject.transform.tag = "Herue";
        

    }
    void Start()
    {
        Zombi.prueba = Zombi.gusto;

        gameObject.AddComponent(typeof(Player));
        GameObject cara = new GameObject();
        cara.AddComponent(typeof(Camera));
        cara.AddComponent(typeof(Ojos));//codigo de camara

        gameObject.GetComponent<Player>().mirar = cara.GetComponent<Ojos>();
        cara.transform.SetParent(gameObject.transform);
        cara.transform.localPosition = new Vector3 (0, 0.5f, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "City")
        {
            Debug.Log(collision.transform.GetComponent<Ciudadano>().yoSoy);
        }
    }
    public void Update()
    {
        GameObject zZombi = null; // GameObject que almacena a todos los Zombis en la esena
        foreach (Zombi zombi in Transform.FindObjectsOfType<Zombi>()) //Foreach que recorre la esena del juego mirando cuantos Zombis hay
        {
            tempDistan = Vector3.Distance(zombi.transform.position, transform.position); // variable para almacenar la distancia de los Zombis al Herue
            if (tempDistan <= ReguladorNPC.visionRadius)
                zZombi = zombi.gameObject;
        }
        // If que mostrara el mensaje de los Zombis al perseguir si estan en el radio de vicion
        if (zZombi != null)
            Juego.mensajeZom = Zombi.gusto;
        else
            Juego.mensajeZom = "";
    }
}