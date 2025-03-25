using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public GameObject player;
    public GameObject AI1;
    public GameObject AI2;
    public GameObject AI3;
    private AudioSource audioSource;
    private GameObject countdown;
    public static GameObject[] positions;
    public static bool hasStarted;

    // Comparison function for sorting the positions of the racers.
    public static int CompareRacers(GameObject p1, GameObject p2)
    {
        if (p1.transform.position.x > p2.transform.position.x) return -1;
        else if (p1.transform.position.x == p2.transform.position.x) return 0;
        else return 1;
    }

    // Activates AI, player movement, and level generation.
    public static void StartGame()
    {
        hasStarted = true;
    }

    // Deactivates AI and player movement and restarts the scene.
    public async static void EndGame()
    {
        hasStarted = false;

        await Task.Delay(5000);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Start is called before the first frame update
    void Start()
    {
        positions = new GameObject[4];
        positions[0] = player;
        positions[1] = AI1;
        positions[2] = AI2;
        positions[3] = AI3;
        hasStarted = false;
        audioSource = GameObject.Find("Game Manager").GetComponent<AudioSource>();
        countdown = GameObject.Find("Countdown");
        AI1.AddComponent<AIBehaviour>();
        AI1.GetComponent<AIBehaviour>().AIPlayer = AI1;
        AI2.AddComponent<AIBehaviour>();
        AI2.GetComponent<AIBehaviour>().AIPlayer = AI2;
        AI3.AddComponent<AIBehaviour>();
        AI3.GetComponent<AIBehaviour>().AIPlayer = AI3;
    }

    // Update is called once per frame
    void Update()
    {
        // Update positions of racers.
        Array.Sort(positions, CompareRacers);

        // End game after audio has been played.
        if (!audioSource.isPlaying && hasStarted)
        {
            countdown.SetActive(true);
            countdown.GetComponent<TMPro.TMP_Text>().text = $"{positions[0].name} Wins!";
            EndGame();
        }
    }
}
