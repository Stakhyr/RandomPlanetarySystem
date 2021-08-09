using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IPlanetarySystem 
{
    IEnumerable<IPlanetaryObject> PlanetaryObjects { get; }
    void update(float deltaTime);
}