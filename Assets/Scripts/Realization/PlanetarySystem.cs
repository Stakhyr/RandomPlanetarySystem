using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlanetarySystem :MonoBehaviour, IPlanetarySystem
{

    public IEnumerable<IPlanetaryObject> PlanetaryObjects { get; }

    public PlanetarySystem(IEnumerable<IPlanetaryObject> planetaryObjects)
    {
        PlanetaryObjects = planetaryObjects;
    }

    public void update(float deltaTime)
    {
        foreach(var planetaryObject in PlanetaryObjects) 
        {
            planetaryObject.Move(deltaTime,planetaryObject.Mass);
        }
    }
}
