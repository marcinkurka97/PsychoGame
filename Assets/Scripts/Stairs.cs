using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour
{
    LevelTransition levelTransition;
    void Start() {
        levelTransition = FindObjectOfType<LevelTransition>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        levelTransition.FadeToLevel("Level2");
    }
}
