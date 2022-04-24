using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject local_gm;
    public void Resize(GameObject gm, float amount, Vector3 direction)
    {
        gm.transform.position += direction * amount / 2;
        gm.transform.localScale += direction * amount; // Scale object in the specified direction
    }

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
    public CreateWall(Color color_, float width, float height, float depth)
    {
        local_gm = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer tempRenderer = local_gm.GetComponent<Renderer>();
        tempRenderer.material.color = color_;
        Resize(local_gm, Math.Abs(width), new Vector3(CheckValues(width), 0, 0));
        Resize(local_gm, Math.Abs(height), new Vector3(0, CheckValues(height), 0));
        Resize(local_gm, Math.Abs(depth), new Vector3(0, 0, CheckValues(depth)));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
