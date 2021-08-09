using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlanetaryObject :MonoBehaviour, IPlanetaryObject
{
    [SerializeField] GameObject planetPrefab;

    GameObject planataryObject;
    public double Mass { get; }
    public float Radius { get; }
    public MassClassEnum MassClass { get; }

    public PlanetaryObject(double mass, MassClassEnum massClass, float radius, float zOffset)
    {
        Mass = mass;
        MassClass = massClass;
        Radius = radius;

        InizializePlanetaryObject(radius, zOffset);
    }

    //body motion in orbit
    public void Move(float deltaTime,double mass)
    {
        planataryObject.transform.RotateAround(new Vector3(0,0,0), Vector3.up, 10 * (float)mass * deltaTime);
    }


    //initialization of the sphere for graphical representation of the planet
    private void InizializePlanetaryObject(float radius, float zOffset) 
    {
        planataryObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        planataryObject.transform.position = new Vector3(0, 0, zOffset);
        planataryObject.transform.localScale = new Vector3(radius, radius, radius);

        //add color to sphere object
        var objectRenderer = planataryObject.GetComponent<Renderer>();
        objectRenderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        //add light to sphere object
        var lightComp = planataryObject.AddComponent<Light>();
        lightComp.color = Color.white;
        lightComp.intensity = 10f;


    }
}
