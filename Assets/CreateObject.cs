using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject local_gm;

    private float CheckValues(float x){
        if(x == 0){
            return 0;
        } else if(x > 0){
            return 1;
        } else {
            return -1;
        }
    }

    public void Move_obj(Vector3 start_pos, float height){
        local_gm.transform.position += start_pos;
        StartCoroutine(Move(local_gm, height, 0.04f));
    }
    public CreateObject(Color color_, float width, float height, float depth)
    {
        local_gm = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer tempRenderer = local_gm.GetComponent<Renderer>();
        tempRenderer.material.color = color_;
        FloorGeneratorScript.Resize(local_gm, Math.Abs(width), new Vector3(CheckValues(width), 0, 0));
        FloorGeneratorScript.Resize(local_gm, Math.Abs(height), new Vector3(0, CheckValues(height), 0));
        FloorGeneratorScript.Resize(local_gm, Math.Abs(depth), new Vector3(0, 0, CheckValues(depth)));
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Move(GameObject gm, float height, float speed)
    {
        while (gm.transform.position.y < height)
        {
            gm.transform.position += new Vector3(0, speed, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
