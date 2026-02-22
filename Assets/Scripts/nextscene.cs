using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class nextscene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    /// <summary>
    /// Loads the selected scene.
    /// This method can be called from UI buttons or game events.
    /// </summary>
    public void Sceneloader()
    {
        // Load the scene
        SceneManager.LoadScene(sceneName);

        // Teleport in  scene
        SceneManager.LoadScene(sceneName);
    }
}
