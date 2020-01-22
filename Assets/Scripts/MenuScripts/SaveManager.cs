using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public Save SaveInstance { get; set; }

    public void SaveGameState()
    {
        SaveInstance = new Save();

        SaveGameObjects();

        WriteSaveInstanceAsFile();

        Debug.Log("Game saved");
    }

    public void LoadGameState()
    {
        var saveInstance = LoadSaveInstace();

        if (!string.IsNullOrEmpty(saveInstance.ActiveSceneName) && !SceneManager.GetActiveScene().name.Equals(saveInstance.ActiveSceneName))
            SceneManager.LoadScene(saveInstance.ActiveSceneName);

        for (int i = 0; i < 2; i++)
        {
            foreach (var go in saveInstance.GameObjects)
            {
                LoadGameObject(go);
            }
        }

        Debug.Log("Game loaded");
    }

    private void SaveGameObjects()
    {
        var gameObjects = FindObjectsOfType<GameObject>();
        foreach (var go in gameObjects)
        {
            if (go.activeInHierarchy)
            {
                SaveInstance.GameObjects.Add(new GameObjectState(go));
            }
        }

        SaveInstance.Points = 100;
        SaveInstance.ActiveSceneName = SceneManager.GetActiveScene().name;

        Debug.Log("Game saved");
    }

    private void WriteSaveInstanceAsFile(string path = null, string saveFileName = null)
    {
        if (string.IsNullOrEmpty(saveFileName))
            saveFileName = "gamesave.save";

        if (string.IsNullOrEmpty(path))
            path = Application.persistentDataPath + "/" + saveFileName;

        using (var file = File.Create(path))
        {
            var instanceAsJson = JsonUtility.ToJson(SaveInstance);

            var instanceAsBytes = new UTF8Encoding(true).GetBytes(instanceAsJson);

            file.Write(instanceAsBytes, 0, instanceAsBytes.Length);

            file.Close();
        }

        Debug.Log("File saved at " + path);

    }

    private Save LoadSaveInstace()
    {
        var filePath = GetSaveInstanceFilePathOrDefault();
        var plainFileContent = File.ReadAllText(filePath);

        return JsonUtility.FromJson<Save>(plainFileContent);
    }

    private string GetSaveInstanceFilePathOrDefault(string saveFileName = null)
    {
        var appFolder = Application.persistentDataPath;
        if (!Directory.Exists(appFolder))
        {
            Debug.Log("There is no game folder");
            return null;
        }

        var saveFiles = Directory.GetFiles(appFolder, "*.save");
        if (saveFiles.Length < 1)
        {
            Debug.Log("There is no save instance in game folder");
            return null;
        }


        if (saveFileName == null)
        {
            Debug.LogWarning("There are some save instances, but saveFileName is not specified");
            return saveFiles[0];
        }


        if (saveFiles.Length == 0)
            return saveFiles[0];

        var saveInstance = saveFiles.FirstOrDefault(x => x.Contains(saveFileName));
        if (saveInstance == null)
        {
            Debug.LogWarning("There is no save instance with specified name");
            return null;
        }

        return saveInstance;
    }

    private void LoadGameObject(GameObjectState state)
    {
        var originalGameObject = FindGameObject(state);
        if (originalGameObject == null)
        {
            Debug.LogError($"Object with ID: {state.Id} and NAME: {state.Name} not found in scene");
            return;
        }
        if (originalGameObject.tag.Equals("NonSerializable"))
        {
            Debug.LogError($"Object with ID: {state.Id} and NAME: {state.Name} is non serializable");
            return;
        }

        originalGameObject.transform.position = new Vector3(state.Position[0], state.Position[1], state.Position[2]);
        originalGameObject.transform.rotation = new Quaternion(state.Rotation[0], state.Rotation[1], state.Rotation[2], state.Rotation[3]);
    }

    private GameObject FindGameObject(GameObjectState state)
    {
        var id = state.Id;
        var name = state.Name;

        var objById = FindGameObjectById(id);
        if (objById != null)
            return objById;

        var objByName = GameObject.Find(name);
        if (objByName != null)
            return objByName;

        return null;
    }

    private GameObject FindGameObjectById(int id)
    {
        var gameObjects = FindObjectsOfType<GameObject>();
        foreach (var go in gameObjects)
        {
            if (go.activeInHierarchy && go.GetInstanceID() == id)
            {
                return go;
            }
        }
        return null;
    }
}
