using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    [SerializeField] private GameObject dino;
    [SerializeField] private GameObject dinoSwapPanel;
    public int GameDifficulty { get; private set; }

    // dino grapple collider
    private BoxCollider2D _grappleArea;

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
        var grappleArea = dinoObj.transform.GetChild(4).GetComponent<BoxCollider2D>();
        var dinoController = dinoObj.GetComponent<DinoController>();
        var grappleLogic = dinoObj.GetComponent<GrappleLogic>();

        switch (scene.name) {
            case "Easy":
                grappleLogic.GrappleMaxDistance = 9f;
                dinoController.Speed = 10f;
                dinoController.JumpForce = 20f;
                dinoController.MaxFallSpeed = -10f;
                grappleArea.offset = new Vector2(0, 6);
                grappleArea.size = new Vector2(20, 10);
                GameDifficulty = (int)Difficulty.Easy;
                break;
            case "Hard":
                grappleLogic.GrappleMaxDistance = 9f;
                dinoController.Speed = 8f;
                dinoController.JumpForce = 20f;
                dinoController.MaxFallSpeed = -15f;
                grappleArea.offset = new Vector2(0, 6);
                grappleArea.size = new Vector2(20, 10);
                GameDifficulty = (int)Difficulty.Hard;
                break;
        }

        Instantiate(dinoSwapPanel);
    }
}