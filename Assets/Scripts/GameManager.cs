using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    [SerializeField] private GameObject dino;
    [SerializeField] private GameObject dinoSwapPanel;
    public int GameDifficulty { get; set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        // used to fix quirky GoToMainMenu() since it's called by 3 different buttons
        if (Time.timeScale.Equals(0)) {
            Time.timeScale = 1;
        }

        if (scene.name.Equals("MainMenu")) return;
        Instantiate(dino);
        Instantiate(dinoSwapPanel);
    }
}