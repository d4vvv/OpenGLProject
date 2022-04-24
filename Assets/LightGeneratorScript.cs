using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGeneratorScript : MonoBehaviour
{
    private float roomWidth = ParametersScript.roomWidth;
    private float roomDepth = ParametersScript.roomDepth;
    private float roomHeight = ParametersScript.roomHeight;
    private float screenWidth = ParametersScript.screenWidth;
    private float frontCorridorDepth = ParametersScript.frontCorridorDepth;

    List<SpotlightGen> spotlightsList = new List<SpotlightGen>();

    Color baseColor = Color.cyan;
    void Awake()
    {
        for (int j = 10; j < roomDepth; j+= 20)
        {
            for (int i = 10; i < roomWidth; i += 20)
            {
                spotlightsList.Add(new SpotlightGen(baseColor, new Vector3(i, roomHeight + 3 , j), new Vector3(90f, 0f, 0f), 40f, 600f, roomHeight + j));
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
