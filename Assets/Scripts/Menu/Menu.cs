using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    LevelTransition levelTransition;
    void Start() {
        levelTransition = FindObjectOfType<LevelTransition>();
    }

    public void StartGame() {
        levelTransition.FadeToLevel("Level0");
    }
}