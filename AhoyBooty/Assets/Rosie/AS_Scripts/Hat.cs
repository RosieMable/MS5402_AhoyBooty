using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    private MeshRenderer mat;

    private Rigidbody rigidbody;

    private Collider col;

    public Color colourHat;

    // Start is called before the first frame update
    void Start()
    {
        mat = this.GetComponentInChildren<MeshRenderer>();

        rigidbody = this.gameObject.AddComponent<Rigidbody>();

        rigidbody.useGravity = false;

        rigidbody.freezeRotation = true;

        rigidbody.isKinematic = true;

        mat.material.color = Random.ColorHSV();

        col = this.gameObject.AddComponent<BoxCollider>();

        colourHat = mat.material.color;
    }

    void OnMouseDrag()
    {
         Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.gameObject.transform.parent.position.z);
            Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = objPos;
    }

}
