using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IPlanetaryObject
{
    double Mass { get;  }
    MassClassEnum MassClass { get; }

    void Move(float deltaTime);
}

enum MassClassEnum
{
    Asteroidan,
    Mercurian,
    Subterran,
    Terran,
    Superterran,
    Neptunian,
    Jovian
}