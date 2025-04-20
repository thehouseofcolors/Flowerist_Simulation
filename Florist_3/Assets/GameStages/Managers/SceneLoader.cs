using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class SceneLoader : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private float _minLoadTime = 2f; // Minimum display time for loading screen

    [Header("Events")]
    public UnityEvent OnLoadStart;
    public UnityEvent OnLoadComplete;

    public void LoadScene(string sceneName) 
    {
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }
        else
        {
            Debug.LogError($"Scene {sceneName} cannot be loaded! Check build settings.");
        }
    }

    private IEnumerator LoadSceneAsync(string sceneName) 
    {
        // Check if UI elements are destroyed before accessing
        if (_loadingScreen == null || _progressBar == null)
        {
            yield break;
        }

        // Reset progress bar
        _progressBar.value = 0f;
        
        // Show loading screen
        _loadingScreen.SetActive(true);
        OnLoadStart?.Invoke();

        float loadStartTime = Time.time;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        // Load the scene in the background
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            _progressBar.value = progress;

            // Delay scene activation until minimum load time has passed
            if (operation.progress >= 0.9f)
            {
                float elapsedTime = Time.time - loadStartTime;
                float remainingTime = _minLoadTime - elapsedTime;

                if (remainingTime > 0)
                {
                    yield return new WaitForSeconds(remainingTime);
                }

                operation.allowSceneActivation = true;
            }

            yield return null;
        }

        // Hide loading screen
        OnLoadComplete?.Invoke();
        if (_loadingScreen != null) // Check before deactivating
        {
            _loadingScreen.SetActive(false);
        }
    }

    public void ReloadCurrentScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToSeedShop() { LoadScene("SeedShop");}

    public void GoToGarden() { LoadScene("Garden");}

    public void GoToFlowerShop() { LoadScene("FlowerShop");}
    
}