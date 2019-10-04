using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojos : MonoBehaviour
{
    public float MouseX;
    float MouseY;
    float sensibilidad = 3.5f;
    float limitarvicion;
    public bool invertedMouse;
    void Update()
    {
        if (Juego.vivo == true && Juego.mostro > 0)
        {
            float xrot = Input.GetAxisRaw("Mouse X");
            MouseX += xrot * sensibilidad;

            float yrot = Input.GetAxisRaw("Mouse Y");
            float campo = yrot * sensibilidad;

            Vector3 mousePosition = Input.mousePosition;
            MouseX += Input.GetAxis("Mouse X");
            if (invertedMouse)
            {
                limitarvicion += campo;
            }
            else
            {
                limitarvicion -= campo;
            }
            transform.eulerAngles = new Vector3(limitarvicion, MouseX, 0);
        }
    }
}




//nombre del emun (gameObllet)ramdom.ramger