using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvas2;
    public GameObject enemy;
    

    private void Update() {
        if(enemy.transform.childCount == 0) {
            canvas2.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            canvas.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            canvas.SetActive(false);
            enemy.SetActive(true);
        }
    }
}
