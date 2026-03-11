using System.Collections.Generic;
using UnityEngine;

public class ControlParticulas : MonoBehaviour
{
    public GameObject prefabParti;

    public int Parti = 10;
    public float velBase = 5f;
    public float angBase = 45f;
    public float vidaBase = 2f;
    public float grav = 9.8f;

    public KeyCode tecla = KeyCode.Space;

    public List<GameObject> lista = new List<GameObject>();

    void Update()
    {
        // si le doy a la tecla se crean
        if (Input.GetKeyDown(tecla))
        {
            CrearExplosion();
        }

        if (lista.Count > 0)
        {
            List<GameObject> borrar = new List<GameObject>();

            // recorro todas las particulas
            for (int i = 0; i < lista.Count; i++)
            {
                GameObject go = lista[i];
                if (go == null)
                {
                    borrar.Add(go); // a veces pasa, ni idea
                    continue;
                }

                Particula p = go.GetComponent<Particula>();
                if (p == null)
                {
                    borrar.Add(go); // si no tiene script pues fuera
                    continue;
                }

                // actualizo su movimiento
                ActualizarParticula(p, Time.deltaTime);

                // si ha vivido demasiado la mato
                if (p.tiempoActivo > p.vidaMax)
                {
                    borrar.Add(go);
                }
            }

            // borro las que tocan
            for (int i = 0; i < borrar.Count; i++)
            {
                GameObject muerto = borrar[i];
                lista.Remove(muerto);
                if (muerto != null) Destroy(muerto);
            }
        }
    }

    void CrearExplosion()
    {
        // creo varias particulas
        for (int i = 0; i < Parti; i++)
        {
            GameObject nueva = Instantiate(prefabParti, transform.position, Quaternion.identity);

            Particula p = nueva.GetComponent<Particula>();
            if (p != null)
            {
                float v = velBase + Random.Range(-1f, 1.3f);
                float vida = vidaBase + Random.Range(-0.4f, 0.7f);
                float ang = angBase + Random.Range(-18f, 19f); 

                p.Iniciar(v, ang, vida, grav);
            }

            lista.Add(nueva);
        }
    }

    void ActualizarParticula(Particula p, float dt)
    {
        p.ActualizarMovimiento(dt);
    }
}

