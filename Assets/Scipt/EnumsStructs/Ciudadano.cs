using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;

namespace NPC // NameSpace que guarga toda la estructura del Ciudadano
{
    namespace Ally // NameSpace que guarga la class Zombi para ser usada en el Generador
    {
        public class Ciudadano : ReguladorNPC
        {
            public DatosNPC datoNPC;
            public string yoSoy;
            float tempDistan;
            float vision = 5f;
            Vector3 direction;

            void Start()
            {
                rotarcion = Random.Range(35, 95);
                gameObject.transform.tag = "City";
                yoSoy = Nombre();
                if (datoNPC.age> 15)
                    veloci = (float)(15 * 3) / datoNPC.age;
                StartCoroutine(rutinaZombiCyti());
            }
            
            public string Nombre()
            {// esta funcion se encardga de construir el mensaje con el nombre y edad del adeano
                datoNPC.age = Random.Range(15, 101);
                int rndName = Random.Range(0, 20);
                datoNPC.nameNPC = (Nombres)rndName;
                return "Hola, me llamo " + datoNPC.nameNPC + " y tengo " + datoNPC.age + " años";
            }
            public void Update()
            {
                GameObject enemy = null; // GameObject que almacena a todos los Zombis en la esena
                foreach (Zombi zombi in Transform.FindObjectsOfType < Zombi>())
                {

                    tempDistan = Vector3.Distance(zombi.transform.position, transform.position);
                    if (tempDistan < vision)
                    {
                        vision = tempDistan;
                        enemy = zombi.gameObject; //remplasa el null por el Zombi mas sercano
                    }
                }
                //hace que los ciudadanos corran de los Zombis mas cercanos 
                if (enemy != null)
                {
                    direction = Vector3.Normalize(enemy.transform.position - transform.position);
                    transform.position += direction * -0.1f;
                }
                else
                {
                    vision = 5f;
                    ComportarceNormal();
                }
            }
            private void OnCollisionEnter(Collision collision)
            {

                if (collision.transform.tag == "Zombi")
                {
                    Zombi transform = gameObject.AddComponent<Zombi>();
                    transform.datos = (DatoZombis)gameObject.GetComponent<Ciudadano>().datoNPC;
                    Destroy(gameObject.GetComponent<Ciudadano>());
                    Juego.enemy++;
                    Juego.cyti--;

                }
            }
        }
       public struct DatosNPC
        {
            public Nombres nameNPC;
            public int age;
            public Accion mover;
            //este Enum guarda los nombres de los aldeanos para mostrarlo mas adelante
           
            static public explicit operator DatoZombis(DatosNPC cambio)
            {
                DatoZombis z = new DatoZombis();
                z.edad = cambio.age;
                return z;
            }
       }
        public enum Nombres
        { Krooth, Zacot, Skooth, Griath, Arait, Catinius, Conbertus, Ambilos, Divicatus, Centus, Donnius, nCenno, Cotto, Ambisavus, Tritó, Vírico, Litugena, Epasius, Epia, Regula }
        
    }
}