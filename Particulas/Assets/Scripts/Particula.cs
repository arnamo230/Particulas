using UnityEngine;

public class Particula : MonoBehaviour
{
    public float velIni = 5f;
    public float angIni = 45f;
    public float vidaMax = 2f;
    public float grav = 9.8f;

    public float tiempoActivo = 0f;

    Vector3 posIni;
    bool ya = false;

    public void Iniciar(float v, float a, float vida, float g)
    {
        velIni = v;
        angIni = a;
        vidaMax = vida;
        grav = g;

        posIni = transform.position;
        tiempoActivo = 0f;
        ya = true;
    }

    public void ActualizarMovimiento(float dt)
    {
        if (!ya) return;

        // sumo el tiempo que lleva viva
        tiempoActivo += dt;

        // si ya se ha pasado pues nada
        if (tiempoActivo > vidaMax) return;

        // paso el angulo a radianes
        float angR = angIni * Mathf.Deg2Rad;

        // saco velocidad en x e y
        float vx = velIni * Mathf.Cos(angR);
        float vy = velIni * Mathf.Sin(angR);

        float t = tiempoActivo;

        // tiro parabolico
        float x = vx * t;
        float y = vy * t - 0.5f * grav * t * t;

        // muevo la particula desde donde ha salido
        transform.position = posIni + new Vector3(x, y, 0f);
    }
}

