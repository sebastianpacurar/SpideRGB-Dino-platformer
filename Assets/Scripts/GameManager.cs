using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject dino;
    [SerializeField] private GameObject dinoSwapPanel;
    [HideInInspector] public static GameManager Instance;

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
        if (!scene.name.Equals("SpiderDino") && !scene.name.Equals("LevelOne")) return;
        var dinoObj = Instantiate(dino);
        var grappleArea = dinoObj.transform.GetChild(4).GetComponent<BoxCollider2D>();
        var dinoController = dinoObj.GetComponent<DinoController>();
        var grappleLogic = dinoObj.GetComponent<GrappleLogic>();

        if (scene.name.Equals("SpiderDino")) {
            grappleLogic.GrappleMaxDistance = 9f;
            dinoController.Speed = 10f;
            dinoController.JumpForce = 20f;
            grappleArea.offset = new Vector2(0, 6);
            grappleArea.size = new Vector2(20, 10);
        } else if (scene.name.Equals("LevelOne")) {
            grappleLogic.GrappleMaxDistance = 4.5f;
            dinoController.Speed = 10f;
            dinoController.JumpForce = 10f;
            grappleArea.offset = new Vector2(0, 3);
            grappleArea.size = new Vector2(10, 5);
        }

        Instantiate(dinoSwapPanel);
    }
}