using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * 8f;
        float dy = Input.GetAxis("Vertical") * Time.deltaTime * 8f;

        // Unityでは2DであってもVector3型で指定しなければならない
        // Mathf.Clampは値を2, 3引数の値に限定する
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + dx, -8f, 8f),
            Mathf.Clamp(transform.position.y + dy, -4.5f, 4.5f),
            10
        );

    }

    // 発射スクリプト
    IEnumerator Shoot() {
        // 無限ループ
        while(true) {
            Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
