using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneHandler : MonoBehaviour
{
    [SerializeField] private Slider progressBar;  
    [SerializeField] private float waitTime = 2f; 
    private void Start()
    {
        StartCoroutine(LoadMainMenuAsync()); 
    }   
    private IEnumerator LoadMainMenuAsync()
    {
        float elapsedTime = 0f;  
        AsyncOperation operation = SceneManager.LoadSceneAsync("MainMenuScene");
        operation.allowSceneActivation = false; 

        while (elapsedTime < waitTime || operation.progress < 0.9f)
        {
            elapsedTime += Time.deltaTime;            
            float progress = Mathf.Clamp01(elapsedTime / waitTime); 
                        
            if (progressBar != null)
            {
                progressBar.value = progress;  
            }
            
            if (elapsedTime >= waitTime && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;  
            }
            yield return null;  
        }
    
    }
}
