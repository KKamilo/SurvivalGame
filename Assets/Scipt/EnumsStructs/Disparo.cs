using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public static int daño;
    void Start()
    {
        gameObject.transform.tag = "bala";
        daño = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * 15 * Time.deltaTime;
        if (transform.localPosition.z > 2.5)
            Destroy(gameObject);
    }

}
