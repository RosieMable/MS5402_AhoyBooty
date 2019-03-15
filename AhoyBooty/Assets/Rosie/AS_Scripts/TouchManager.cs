using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public GameObject gObjt = null;

    protected Ray GenerateMouseRay()
    {
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, Camera.main.farClipPlane);

        Vector3 mousePosNear = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        Ray mr = new Ray(mousePosN, mousePosF - mousePosN);
        return mr;
    }


    // Update is called once per frame
   protected void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = GenerateMouseRay();
            RaycastHit hit;

            if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
            {
                gObjt = hit.transform.gameObject;
            }
        }
        else if (Input.GetMouseButtonUp(0) && gObjt)
        {
            gObjt = null;
        }
    }



}
