using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private Plane plane;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Rigidbody rb;
    public Text shotsText;
    private int shots;


    void UpdateShotsCount () {
        shotsText.text = shots.ToString();
    }

    void Start()
    {
        // Plane(direction, )
        plane = new Plane(Vector3.up, Vector3.zero);
        rb = GetComponent<Rigidbody>();
        shots = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance;
        // mouse down
        if(Input.GetMouseButtonDown(0)) {
            // Raycast(ray)はbooleanを返すだけだが、第二引数にout修飾子をつけた変数を置いておくとそこにぶつかった平面までの距離を突っ込んでくれる
            if(plane.Raycast(ray, out distance)) {
                startPoint = ray.GetPoint(distance);
            }
        }
        // mouse up
        if(Input.GetMouseButtonUp(0)) {
            if(plane.Raycast(ray, out distance)) {
                endPoint = ray.GetPoint(distance);
                rb.AddForce(-1f * (endPoint - startPoint), ForceMode.Impulse);
                shots++;
                UpdateShotsCount();
            }
        }
    }
}
