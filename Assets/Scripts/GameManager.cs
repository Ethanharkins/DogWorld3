using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;

    private static GameManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(camera);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
