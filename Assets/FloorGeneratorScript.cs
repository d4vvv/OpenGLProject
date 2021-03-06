using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGeneratorScript : MonoBehaviour
{
    public Material GlowMaterial;
    public Material GlowMaterial2;
    public Material TestMaterial;

    //private GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //private Renderer rend = floor.GetComponent<Renderer>();
    List<GameObject> test = new List<GameObject>();
    List<GameObject> glowSticks = new List<GameObject>();
    List<GameObject> leftUnderSeatFloorList = new List<GameObject>();
    List<GameObject> rightUnderSeatFloorList = new List<GameObject>();
    List<Renderer> renderers = new List<Renderer>();
    List<Renderer> leftUnderSeatRenderers = new List<Renderer>();
    List<Renderer> rightUnderSeatRenderers = new List<Renderer>();
    List<Renderer> glowSticksRenderers = new List<Renderer>();
    List<GameObject> rightSeatList = new List<GameObject>();
    List<Renderer> rightSeatRenderers = new List<Renderer>();
    List<GameObject> leftSeatList = new List<GameObject>();
    List<Renderer> leftSeatRenderers = new List<Renderer>();

    GameObject test2;

    private float roomWidth = ParametersScript.roomWidth;
    private float roomDepth = ParametersScript.roomDepth;
    private float roomHeight = ParametersScript.roomHeight;
    private float screenWidth = ParametersScript.screenWidth;
    private float frontCorridorDepth = ParametersScript.frontCorridorDepth;

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
        Renderer floorRenderer = floor.GetComponent<Renderer>();
        floorRenderer.material.shader = Shader.Find("HDRP/Lit");
        //floorRenderer.material.color = new Color(0.65f, 0.65f, 0.65f, 1f);
        //floorRenderer.material = TestMaterial;
        Resize(floor, roomWidth, new Vector3(1,0,0));
        Resize(floor, roomDepth, new Vector3(0,0,1));
        

        for (int i = 0; i < 40; i ++)
        {

            test.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
            renderers.Add(test[i].GetComponent<Renderer>());
            //renderers[i].material.color = new Color(0.65f, 0.65f, 0.65f, 1f);
            renderers[i].material.shader = Shader.Find("HDRP/Lit");
            Resize(test[i], roomDepth - frontCorridorDepth - (i*2)-0.01f, new Vector3(0,0,1));
            Resize(test[i], roomWidth, new Vector3(1,0,0));
            StartCoroutine(Move(test[i],i-0.02f, 0.04f));

            glowSticks.Add(GameObject.CreatePrimitive(PrimitiveType.Cylinder));
            glowSticksRenderers.Add(glowSticks[i].GetComponent<Renderer>());
            glowSticksRenderers[i].material = GlowMaterial;
            glowSticks[i].transform.localScale = new Vector3(0.2f, 4.5f, 0.2f);
            glowSticks[i].transform.eulerAngles = new Vector3(0, 0, 90f);
            glowSticks[i].transform.position = new Vector3(roomWidth / 2, 0, roomDepth - frontCorridorDepth + 0.5f - 2f * i);
            StartCoroutine(Move(glowSticks[i], i + 0.5f, 0.04f));



        }

        for (int i = 0; i < 11; i++)
        {
            leftUnderSeatFloorList.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
            leftUnderSeatRenderers.Add(leftUnderSeatFloorList[i].GetComponent<Renderer>());
            leftUnderSeatRenderers[i].material.color = new Color(0.2f, 0.2f, 0.2f, 1f);
            leftUnderSeatRenderers[i].material.shader = Shader.Find("HDRP/Lit");
            rightUnderSeatFloorList.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
            rightUnderSeatRenderers.Add(rightUnderSeatFloorList[i].GetComponent<Renderer>());
            rightUnderSeatRenderers[i].material.color = new Color(0.2f, 0.2f, 0.2f, 1f);
            rightUnderSeatRenderers[i].material.shader = Shader.Find("HDRP/Lit");

            for (int j = 0; j < (int)(roomWidth/2 - 10)/8; j++)
            {
                int index = i * (int)((roomWidth / 2 - 10) / 8) + j;
                Debug.Log(index);
                leftSeatList.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
                leftSeatRenderers.Add(leftSeatList[index].GetComponent<Renderer>());
                leftSeatRenderers[index].material = GlowMaterial2;
                Resize(leftSeatList[index], 4, new Vector3(0, 0, 1));
                Resize(leftSeatList[index], 4, new Vector3(1, 0, 0));
                Resize(leftSeatList[index], 8, new Vector3(0, 1, 0));
                leftSeatList[index].transform.position = new Vector3(6 + 8*j, 0, roomDepth - frontCorridorDepth - 2f - 8f * i);
                StartCoroutine(Move(leftSeatList[index], i * 4f + 6f, 0.04f));

                rightSeatList.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
                rightSeatRenderers.Add(rightSeatList[index].GetComponent<Renderer>());
                rightSeatRenderers[index].material = GlowMaterial2;
                Resize(rightSeatList[index], 4, new Vector3(0, 0, 1));
                Resize(rightSeatList[index], 4, new Vector3(1, 0, 0));
                Resize(rightSeatList[index], 8, new Vector3(0, 1, 0));
                rightSeatList[index].transform.position = new Vector3(12 + 8 * j + roomWidth / 2, 0, roomDepth - frontCorridorDepth - 2f - 8f * i);
                StartCoroutine(Move(rightSeatList[index], i * 4f + 6f, 0.04f));
            }
            
            if (i == 0)
            {
                Resize(leftUnderSeatFloorList[i], (roomWidth / 2) - 5, new Vector3(1, 0, 0));
                Resize(leftUnderSeatFloorList[i], 2.01f, new Vector3(0, 1, 0));
                Resize(leftUnderSeatFloorList[i], roomDepth - frontCorridorDepth - (i * 8)+2, new Vector3(0, 0, 1));

                StartCoroutine(Move(leftUnderSeatFloorList[i], i * 4f, 0.04f));
                    
                Resize(rightUnderSeatFloorList[i], (roomWidth / 2) - 5, new Vector3(1, 0, 0));
                Resize(rightUnderSeatFloorList[i], 2.01f, new Vector3(0, 1, 0));
                Resize(rightUnderSeatFloorList[i], roomDepth - frontCorridorDepth - (i * 8)+2, new Vector3(0, 0, 1));
                rightUnderSeatFloorList[i].transform.position += new Vector3(roomWidth / 2 + 5, 0, 0);
                StartCoroutine(Move(rightUnderSeatFloorList[i], i*4f, 0.04f));
                
            }
            else
            {
                Resize(leftUnderSeatFloorList[i], (roomWidth / 2) - 5, new Vector3(1, 0, 0));
                Resize(leftUnderSeatFloorList[i], 4f, new Vector3(0, 1, 0));
                Resize(leftUnderSeatFloorList[i], roomDepth - frontCorridorDepth - (i * 8)+2, new Vector3(0, 0, 1));
                StartCoroutine(Move(leftUnderSeatFloorList[i], i * 4f+ 0.01f, 0.04f));

                Resize(rightUnderSeatFloorList[i], (roomWidth / 2) - 5, new Vector3(1, 0, 0));
                Resize(rightUnderSeatFloorList[i], 4f, new Vector3(0, 1, 0));
                Resize(rightUnderSeatFloorList[i], roomDepth - frontCorridorDepth - (i * 8) + 2, new Vector3(0, 0, 1));
                rightUnderSeatFloorList[i].transform.position += new Vector3(roomWidth / 2 + 5, 0, 0);
                StartCoroutine(Move(rightUnderSeatFloorList[i], i * 4f + 0.01f, 0.04f));
            } 
        }

        CreateRoom();

       


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateRoom()
    {
        GameObject lowerFrontWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer lowerFrontWallRenderer = lowerFrontWall.GetComponent<Renderer>();
        lowerFrontWallRenderer.material.color = new Color(0.65f, 0.65f, 0.65f, 1f);
        lowerFrontWallRenderer.material.shader = Shader.Find("HDRP/Lit");
        Resize(lowerFrontWall, 4f, new Vector3(0, 0, -1));
        Resize(lowerFrontWall, 14f, new Vector3(0, 1, 0));
        Resize(lowerFrontWall, roomWidth, new Vector3(1, 0, 0));
        lowerFrontWall.transform.position += new Vector3(0, -5f, roomDepth + 1);
        StartCoroutine(Move(lowerFrontWall, 7f, 0.04f));

        GameObject upperFrontWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer upperFrontWallRenderer = upperFrontWall.GetComponent<Renderer>();
        upperFrontWallRenderer.material.color = new Color(0.65f, 0.65f, 0.65f, 1f);
        upperFrontWallRenderer.material.shader = Shader.Find("HDRP/Lit");
        Resize(upperFrontWall, 4f, new Vector3(0, 0, -1));
        Resize(upperFrontWall, 14f, new Vector3(0, 1, 0));
        Resize(upperFrontWall, roomWidth, new Vector3(1, 0, 0));
        upperFrontWall.transform.position += new Vector3(0, -5f, roomDepth + 1);
        StartCoroutine(Move(upperFrontWall, roomHeight - 3.5f, 0.16f));

        GameObject leftFrontWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer leftFrontWallRenderer = leftFrontWall.GetComponent<Renderer>();
        leftFrontWallRenderer.material.color = new Color(0.65f, 0.65f, 0.65f, 1f);
        leftFrontWallRenderer.material.shader = Shader.Find("HDRP/Lit");
        Resize(leftFrontWall, 4f, new Vector3(0, 0, -1));
        Resize(leftFrontWall, roomHeight, new Vector3(0, 1, 0));
        Resize(leftFrontWall, (roomWidth - screenWidth) / 2, new Vector3(1, 0, 0));
        leftFrontWall.transform.position += new Vector3(0, -roomHeight, roomDepth + 1);
        StartCoroutine(Move(leftFrontWall, roomHeight / 2, 0.16f));

        GameObject rightFrontWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer rightFrontWallRenderer = rightFrontWall.GetComponent<Renderer>();
        rightFrontWallRenderer.material.color = new Color(0.65f, 0.65f, 0.65f, 1f);
        rightFrontWallRenderer.material.shader = Shader.Find("HDRP/Lit");
        Resize(rightFrontWall, 4f, new Vector3(0, 0, -1));
        Resize(rightFrontWall, roomHeight, new Vector3(0, 1, 0));
        Resize(rightFrontWall, (roomWidth - screenWidth) / 2, new Vector3(1, 0, 0));
        rightFrontWall.transform.position += new Vector3(roomWidth - ((roomWidth - screenWidth) / 2), -roomHeight, roomDepth + 1);
        StartCoroutine(Move(rightFrontWall, roomHeight / 2, 0.16f));

        GameObject frontWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer frontWallRenderer = frontWall.GetComponent<Renderer>();
        frontWallRenderer.material.color = new Color(0.65f, 0.65f, 0.65f, 1f);
        frontWallRenderer.material.shader = Shader.Find("HDRP/Lit");
        Resize(frontWall, roomHeight, new Vector3(0, 1, 0));
        Resize(frontWall, roomWidth, new Vector3(1, 0, 0));
        frontWall.transform.position += new Vector3(0, -roomHeight, roomDepth);
        StartCoroutine(Move(frontWall, roomHeight / 2, 0.16f));

        GameObject screen = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer screenRenderer = screen.GetComponent<Renderer>();
        screenRenderer.material = GlowMaterial;
        //screenRenderer.material.color = new Color(0.9f, 0.9f, 0.9f, 1f);
        Resize(screen, roomHeight - 10, new Vector3(0, 1, 0));
        Resize(screen, roomWidth - 10, new Vector3(1, 0, 0));
        screen.transform.position += new Vector3(5, -roomHeight, roomDepth - 1f);
        StartCoroutine(Move(screen, ((roomHeight - 10) / 2), 0.12f));

        GameObject backWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer backWallRenderer = backWall.GetComponent<Renderer>();
        backWallRenderer.material.shader = Shader.Find("HDRP/Lit");
        //backWallRenderer.material.color = new Color(0.65f, 0.65f, 0.65f, 1f);
        Resize(backWall, roomHeight, new Vector3(0, 1, 0));
        Resize(backWall, roomWidth, new Vector3(1, 0, 0));
        backWall.transform.position += new Vector3(0, -roomHeight, 0);
        StartCoroutine(Move(backWall, roomHeight / 2, 0.16f));

        GameObject rightWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer rightWallRenderer = rightWall.GetComponent<Renderer>();
        rightWallRenderer.material.color = new Color(0.65f, 0.65f, 0.65f, 1f);
        rightWallRenderer.material.shader = Shader.Find("HDRP/Lit");
        Resize(rightWall, roomHeight, new Vector3(0, 1, 0));
        Resize(rightWall, roomDepth - 10, new Vector3(0, 0, 1));
        rightWall.transform.position += new Vector3(-1, -roomHeight, 0);
        StartCoroutine(Move(rightWall, roomHeight / 2, 0.16f));

        GameObject rightWallDoor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer rightWallDoorRenderer = rightWallDoor.GetComponent<Renderer>();
        rightWallDoorRenderer.material.color = new Color(0.65f, 0.65f, 0.65f, 1f);
        rightWallDoorRenderer.material.shader = Shader.Find("HDRP/Lit");
        Resize(rightWallDoor, roomHeight - 20, new Vector3(0, 1, 0));
        Resize(rightWallDoor, 6, new Vector3(0, 0, 1));
        rightWallDoor.transform.position += new Vector3(-1, 2 * roomHeight, roomDepth - 9);
        StartCoroutine(MoveDown(rightWallDoor, (roomHeight / 2) + 10, 0.16f));

        GameObject leftWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer leftWallRenderer = leftWall.GetComponent<Renderer>();
        leftWallRenderer.material.color = new Color(0.65f, 0.65f, 0.65f, 1f);
        leftWallRenderer.material.shader = Shader.Find("HDRP/Lit");
        Resize(leftWall, roomHeight, new Vector3(0, 1, 0));
        Resize(leftWall, roomDepth, new Vector3(0, 0, 1));
        leftWall.transform.position += new Vector3(roomWidth, -roomHeight, 0);
        StartCoroutine(Move(leftWall, roomHeight / 2, 0.16f));

        GameObject celling = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer cellingRenderer = celling.GetComponent<Renderer>();
        cellingRenderer.material.color = new Color(0.65f, 0.65f, 0.65f, 1f);
        cellingRenderer.material.shader = Shader.Find("HDRP/Lit");
        Resize(celling, roomWidth, new Vector3(1, 0, 0));
        Resize(celling, roomDepth, new Vector3(0, 0, 1));
        celling.transform.position += new Vector3(0, 1.5f * roomHeight, 0);
        StartCoroutine(MoveDown(celling, roomHeight, 0.16f));



    }

    public IEnumerator Move(GameObject gm, float height, float speed)
    {   
        while(gm.transform.position.y < height)
        {
            gm.transform.position += new Vector3(0, speed, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator MoveDown(GameObject gm, float height, float speed)
    {
        while (gm.transform.position.y > height)
        {
            gm.transform.position -= new Vector3(0, speed, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
