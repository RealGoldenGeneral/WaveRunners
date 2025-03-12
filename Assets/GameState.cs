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

    public static int CompareRacers(GameObject p1, GameObject p2)
    {
        if (p1.transform.position.x > p2.transform.position.x) return -1;
        else if (p1.transform.position.x == p2.transform.position.x) return 0;
        else return 1;
    }

    public static void StartGame()
    {
        hasStarted = true;
    }

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
    }

    // Update is called once per frame
    void Update()
    {
        Array.Sort(positions, CompareRacers);
        if (!audioSource.isPlaying && hasStarted)
        {
            countdown.SetActive(true);
            countdown.GetComponent<TMPro.TMP_Text>().text = $"{positions[0].name} Wins!";
            EndGame();
        }
    }
}
