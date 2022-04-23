using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGeneratorScript : MonoBehaviour
{
    //private GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //private Renderer rend = floor.GetComponent<Renderer>();

    public GameObject floorLevel;
    
    public void Resize(GameObject gm, float amount, Vector3 direction)
 {
      gm.transform.position += direction * amount / 2;
      gm.transform.localScale += direction * amount; // Scale object in the specified direction
 }
    void Awake()
    {
       
        //Renderer floorRenderer = floorLevel.GetComponent<Renderer>();
        //floorRenderer.material.color = new Color (0, 1, 0, 1);

        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Resize(floor, 10, new Vector3(1,0,0));
        Resize(floor, 30, new Vector3(0,0,1));
      
        GameObject seat = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer seatRenderer = seat.GetComponent<Renderer>();
        seatRenderer.material.color = new Color (0.5f, 0, 0.5f, 1);
        seat.transform.position += new Vector3(3 ,1, 30f);
        Resize(seat, 4, new Vector3(1,0,0));

        for (int i = 0; i < 5; i ++)
        {
            GameObject step = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //floorLevel.transform.localScale = new Vector3(1, 1, 1);
            Resize(step, 11-(i*2), new Vector3(0,0,1));
            Resize(step, 10, new Vector3(1,0,0));
            step.transform.position += new Vector3(0, i+1, 0);
            //GameObject.Instantiate(step, new Vector3(0,i+1,0), Quaternion.identity);
        }
        

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
