using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Ojos mirar;
    public readonly float speed= Juego.hSpied; // variable Readonly de velocidad a la cual se le hacigna el dato que tiene almacenado la variable hSpied en la clace Juego (Creador)
   
    void Update()
    {
        if (Juego.vivo == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward * speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * speed;
            }
            transform.eulerAngles = new Vector3(0, mirar.MouseX, 0);
        }
    }
    
}