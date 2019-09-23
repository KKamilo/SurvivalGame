using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;
using NPC.Enemy;

//Clase que Regula el comportamiento de los Zombis y Aldeanos
public class ReguladorNPC : MonoBehaviour 
{
    public int direccion;
    public Vector3 dirijir;
    public float veloci = 3f;
    Accion accion;
    public int rotarcion;
    public GameObject player;
    public GameObject city;
    public GameObject enemy;
    public static float visionRadius = 5f;
    public Vector3 positionInicial ;


   
    public IEnumerator rutinaZombiCyti()
    {
        while (true)
        {
            int accionInt = Random.Range(1, 4);

            //Indicadior que  accion realisara el Zombi y el Aldeano los cuales son: Idle => Quieto y Moving => Mover y Rotating => Rotar
            switch (accionInt)
            {
                
                case 1:
                    accion = Accion.Idle;
                    break;
                case 2:
                    direccion = Random.Range(0, 4);
                    accion = Accion.Moving;
                    break;
                case 3:
                    accion = Accion.Rotating;
                    break;
                
            }
            yield return new WaitForSeconds(3f);
        }
    }
    // clase que al masena los Comportamientos
    public void ComportarceNormal()
    {

        if (accion == Accion.Moving)
        {
            switch (direccion)
            {
                case 0:
                    transform.position += transform.forward * veloci * Time.deltaTime;
                    break;
                case 1:
                    transform.position -= transform.forward * veloci * Time.deltaTime;
                    break;
                case 2:
                    transform.position += transform.right * veloci * Time.deltaTime;
                    break;
                case 3:
                    transform.position -= transform.right * veloci * Time.deltaTime;
                    break;
            }

        }
        else if (accion == Accion.Rotating)
        {

            transform.Rotate(transform.up * rotarcion * Time.deltaTime);
        }
    }
    //Gizmos que muestra en la ventana de Scene el radio de vicion de los Zombis Y Aldeanos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
    
}
