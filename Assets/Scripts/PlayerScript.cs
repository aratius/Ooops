using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * 8f;
        float dy = Input.GetAxis("Vertical") * Time.deltaTime * 8f;

        // Unityでは2DであってもVector3型で指定しなければならない
        transform.position = new Vector3(
            transform.position.x + dx,
            transform.position.y + dy,
            10
        );

    }
}
