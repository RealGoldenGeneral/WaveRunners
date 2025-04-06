using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using SFB;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
public class InsertAudio : MonoBehaviour
{
    private AudioClip audioClip;
    public GameObject gameManager;
    public AudioSource audioSource;
    public GameObject player;
    public GameObject AI1;
    public GameObject AI2;
    public GameObject AI3;
    public Button button;
    public GameObject positionText;
    public GameObject countdownText;

    public void OnPointerDown(PointerEventData eventData) { }
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    private void onClick()
    {
        //// Opens file explorer for audio file (only mpeg for now)
        //var paths = StandaloneFileBrowser.OpenFilePanel("Select Audio", "", "mp3", false);
        //if (paths.Length > 0)
        //{
        //    StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
        //}
        gameManager.SetActive(true);
        player.SetActive(true);
        AI1.SetActive(true);
        AI2.SetActive(true);
        AI3.SetActive(true);
        button.gameObject.SetActive(false);
        positionText.SetActive(true);
        countdownText.SetActive(true);
    }

    //private IEnumerator OutputRoutine(string url)
    //{
    //    // Loads audio from file and starts game (only takes mpeg for now)
    //    var loader = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);
    //    yield return loader.SendWebRequest();
    //    audioClip = DownloadHandlerAudioClip.GetContent(loader);
    //    gameManager.SetActive(true);
    //    player.SetActive(true);
    //    AI1.SetActive(true);
    //    AI2.SetActive(true);
    //    AI3.SetActive(true);
    //    audioSource.clip = audioClip;
    //    button.gameObject.SetActive(false);
    //    positionText.SetActive(true);
    //    countdownText.SetActive(true);
    //}
}
