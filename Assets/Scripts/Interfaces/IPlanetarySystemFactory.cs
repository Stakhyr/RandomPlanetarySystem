using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface IPlanetarySystemFactory 
{
    IPlanetarySystem Create(double Mass);
}