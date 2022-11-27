using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    [SerializeField] private GameObject dino;
    [SerializeField] private GameObject dinoSwapPanel;
    public int GameDifficulty { get; private set; }

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
        var dinoObj = Instantiate(dino);
        var dinoController = dinoObj.GetComponent<DinoController>();

        switch (scene.name) {
            case "Sidekick":
                dinoController.MaxFallSpeed = -10f;
                GameDifficulty = (int)Difficulty.Sidekick;
                break;
            case "Hero":
                dinoController.MaxFallSpeed = -12.5f;
                GameDifficulty = (int)Difficulty.Hero;
                break;
            case "Superhero":
                dinoController.MaxFallSpeed = -12.5f;
                GameDifficulty = (int)Difficulty.Superhero;
                break;
            case "Epichero":
                // disable Helper UI on Epic Hero difficulty
                dinoObj.transform.Find("Canvas").gameObject.SetActive(false);
                dinoController.MaxFallSpeed = -13.75f;
                GameDifficulty = (int)Difficulty.Epichero;
                break;
        }

        Instantiate(dinoSwapPanel);
    }
}