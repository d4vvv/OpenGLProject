using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class SpotlightGen : MonoBehaviour 
{
    GameObject spotlight = new GameObject("Spotlight");
    public SpotlightGen(Color color, Vector3 position, Vector3 rotation, float spotAngle = 30, float intensity = 200, float range = 50)
    {
        var lightComp = spotlight.AddHDLight(HDLightTypeAndShape.ConeSpot);
        lightComp.color = color;
        lightComp.intensity = intensity;
        lightComp.SetLightUnit(LightUnit.Lux);
        lightComp.range = range;
        lightComp.luxAtDistance = 3;
        //lightComp. = spotAngle;
        lightComp.SetSpotAngle(120f);
        spotlight.transform.eulerAngles = rotation;
        spotlight.transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
