using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegoSpawner : MonoBehaviour
{

    public GameObject[] bricks;
    public GameObject ARCamera;
    System.Random rnd = new System.Random();

    static float cooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && cooldown < 0.01f)
        {
            Vector3 camRotation = ARCamera.transform.rotation * Vector3.forward;
            Vector3 camPosition = ARCamera.transform.position;
            if(Physics.Raycast(camPosition, camRotation, 100f, 3))
            {
                //hello! :D
                Instantiate(bricks[rnd.Next(bricks.Length)]);
                cooldown = 200f;
            }
        }
        else if(cooldown > 0.01f)
        {
            cooldown -= 1/60;
        }
    }
}
