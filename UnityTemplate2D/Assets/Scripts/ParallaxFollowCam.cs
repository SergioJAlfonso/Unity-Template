using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFollowCam : MonoBehaviour
{
    //Definir farClipPlane y nearClipPlane y poner todos los fondos entre ellos
    [SerializeField]
    Camera cam;

    //Transform de player. Misma velocidad que camara
    [SerializeField]
    Transform subject;

    Vector2 startPos;
    Vector3 camInitPos;
    float startZ;

    Vector2 travel; 
    float parallaxFactor;

    float imageSize;

    void Start()
    {
        startPos = transform.position;
        startZ = transform.position.z;
        camInitPos = cam.transform.position;

        imageSize = transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x;

        //Calculo factor parallax según posicion en z
        float DistanceFromSubject = transform.position.z - subject.position.z;
        float ClippingPlane = (cam.transform.position.z + (DistanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));
        parallaxFactor = Mathf.Abs(DistanceFromSubject) / ClippingPlane;
    }

    // Update is called once per frame
    void Update()
    {
        travel = (Vector2)(cam.transform.position - camInitPos) - startPos;
        if (Mathf.Abs(travel.x) > imageSize)
            cam.transform.position = camInitPos;

        Vector2 newPos = startPos + travel * parallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);
    }
}
