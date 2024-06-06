using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionHandler : MonoBehaviour
{
    public GameObject uiElement; // Assign the UI element to show/hide
    public string sceneToLoad; // The name of the scene to load
    private bool isPlayerInTrigger = false;
    private StarterAssets.StarterAssetsInputs _inputs;

    private void Start()
    {
        if (uiElement != null)
        {
            uiElement.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            _inputs = other.GetComponent<StarterAssets.StarterAssetsInputs>();

            if (uiElement != null)
            {
                uiElement.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            _inputs = null;

            if (uiElement != null)
            {
                uiElement.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && _inputs != null && _inputs.interact)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
