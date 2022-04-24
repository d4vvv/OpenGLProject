using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour
{
    // Start is called before the first frame update

    public void Resize(GameObject gm, float amount, Vector3 direction)
    {
        gm.transform.position += direction * amount / 2;
        gm.transform.localScale += direction * amount; // Scale object in the specified direction
    }
    public CreateWall(Color color_, float x, float y, float z)
    {
        GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer tempRenderer = temp.GetComponent<Renderer>();
        tempRenderer.material.color = color_;
        Resize(temp, 4f, new Vector3(0, 0, -1));
        Resize(temp, 14f, new Vector3(0, 1, 0));
       // Resize(temp, roomWidth, new Vector3(1, 0, 0));
       // temp.transform.position += new Vector3(0, -5f, roomDepth + 1);
       // StartCoroutine(Move(temp, 7f, 0.04f));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
