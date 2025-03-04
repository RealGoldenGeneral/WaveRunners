using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SFB;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
public class InsertAudio : MonoBehaviour
{
    private AudioClip audioClip;
    public GameObject gameManager;
    public AudioSource audioSource;
    public GameObject player;
    public GameObject AI;
    public Button button;

    public void OnPointerDown(PointerEventData eventData) { }
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    private void onClick()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Select Audio", "", "mp3", false);
        if (paths.Length > 0)
        {
            StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
        }
    }

    private IEnumerator OutputRoutine(string url)
    {
        var loader = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);
        yield return loader.SendWebRequest();
        audioClip = DownloadHandlerAudioClip.GetContent(loader);
        gameManager.SetActive(true);
        player.SetActive(true);
        AI.SetActive(true);
        audioSource.clip = audioClip;
        button.gameObject.SetActive(false);
        audioSource.Play();
    }
}
