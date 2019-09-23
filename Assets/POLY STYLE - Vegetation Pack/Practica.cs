using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practica : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int num = 0;
    Hola:
        num++;

        if (num>5)
        {
            goto Salir;
        }
        print("atrapado en el loop");
            goto Hola;
    Salir:
        print("im free!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
