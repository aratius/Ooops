using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{

    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) {
            if(currentIndex < SceneManager.sceneCountInBuildSettings - 1) {
                SceneManager.LoadScene(currentIndex+1);
            }else {
                SceneManager.LoadScene(0);
            }
        }
    }
}
