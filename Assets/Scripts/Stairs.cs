using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour
{

    /// <summary>
    /// cza zrobic swapa ze sceny pierwszzego pietra na parter
    /// </summary>

    private string levelName = "Level3";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //SceneManager.LoadScene("Level3", LoadSceneMode.Additive);
        //SceneManager.UnloadScene("Level1");
        SceneManager.LoadScene(levelName);
        
    }


}
