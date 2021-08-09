using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystemManager : MonoBehaviour
{

    [SerializeField] private double minMassValue;
    [SerializeField] private double maxMassValue;

    private PlanetarySystemFactory _planetarySystemFactory;
    IPlanetarySystem system;

    // Start is called before the first frame update
    void Start()
    {
        _planetarySystemFactory = new PlanetarySystemFactory();

        var _planetarySystemRandomTotalMass = (double)Random.Range((float)minMassValue, (float)maxMassValue);
       system  =_planetarySystemFactory.Create(_planetarySystemRandomTotalMass);
    }

    private void Update()
    {
        system.update(Time.deltaTime);
    }
}
