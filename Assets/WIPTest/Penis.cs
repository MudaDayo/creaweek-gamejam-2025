using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Penis : MonoBehaviour
{
    public Color mapColor = Color.red;
    public int puddleSize = 1;

    private ParticleSystem part;
    private List<ParticleCollisionEvent> collisionEvents;
    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.GetComponent<TestPissOnMap>() == null) return;
        TestPissOnMap pissMap = other.GetComponent<TestPissOnMap>();

        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        for (int i = 0; i < numCollisionEvents; i++)
        {
            pissMap.DrawCircle(collisionEvents[i].intersection, puddleSize, mapColor);
        }
    }
}
