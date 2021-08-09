using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlanetarySystemFactory : IPlanetarySystemFactory
{
    public IPlanetarySystem Create(double mass)
    {
        var rnd = new System.Random();
        var count = rnd.Next(2, 10);

        var currentMass = mass;
        var planetaryObjects = new List<IPlanetaryObject>();
        double previousRadius = 0;
        double previousZOffset = 0;
        for (int i = 0; i < count; i++)
        {
            var planetMass = i == count - 1 ? currentMass : GetRandomNumber(0.00001, currentMass / 2);
            var massClass = GetMassClass(planetMass);
            var radius = GetRadius(massClass);
            float zOffset = (float)(previousZOffset + previousRadius + radius + GetRandomNumber(3, 10));

            planetaryObjects.Add(new PlanetaryObject(planetMass, massClass, radius, zOffset));
            
            currentMass -= planetMass;
            previousRadius = radius;
            previousZOffset = zOffset;

        }

        return new PlanetarySystem(planetaryObjects);
    }

    private MassClassEnum GetMassClass(double mass)
    {
        switch (mass)
        {
            case var _ when mass < 0 && mass > 0.00001:    return MassClassEnum.Asteroidan;
            case var _ when mass < 0.00001 && mass > 0.1:  return MassClassEnum.Mercurian;
            case var _ when mass < 0.1 && mass > 0.5:      return MassClassEnum.Subterran;
            case var _ when mass < 0.5 && mass > 2:        return MassClassEnum.Terran;
            case var _ when mass < 2 && mass > 10:         return MassClassEnum.Superterran;
            case var _ when mass < 10 && mass > 50:        return MassClassEnum.Neptunian;
            case var _ when mass < 50 && mass > 100:       return MassClassEnum.Jovian;

            default: return MassClassEnum.Jovian;
        }
    }

    private float GetRadius(MassClassEnum massClass)
    {
        switch (massClass)
        {
            case MassClassEnum.Asteroidan:      return Random.Range(0f, 0.03f);
            case MassClassEnum.Mercurian:       return Random.Range(0.03f, 0.07f);
            case MassClassEnum.Subterran:       return Random.Range(0.5f, 1.2f);
            case MassClassEnum.Terran:          return Random.Range(0.8f, 1.9f);
            case MassClassEnum.Superterran:     return Random.Range(1.3f, 3.3f);
            case MassClassEnum.Neptunian:       return Random.Range(2.1f, 5.7f);
            case MassClassEnum.Jovian:          return Random.Range(3.5f, 27f);

            default: return Random.Range(12f, 14f);
        };
    }


    private double GetRandomNumber(double minimum, double maximum)
    {
        var random = new System.Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }

}
