using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class PauseMenu : MonoBehaviour
{
    public GameObject UI;
    public GameObject pixelCameraPrefab;
    private pixelatable[] oldTargets;
    public RenderTexture rt;
    // Start is called before the first frame update
    void Start()
    {
        pixelatable[] targets = GameObject.FindObjectsOfType<pixelatable>();
        foreach (pixelatable target in targets)
        {
            var pc = Instantiate(pixelCameraPrefab, new Vector3(0, 47.2f, 0), pixelCameraPrefab.transform.rotation);
            pc.GetComponent<PixelCameraFollow>().spriteTransform = target.transform;
            pc.GetComponent<Camera>().targetTexture = new RenderTexture(target.GetComponent<pixelatable>().width, target.GetComponent<pixelatable>().height, 0);
            pc.GetComponent<Camera>().targetTexture.filterMode = FilterMode.Point;
            target.GetComponentInChildren<RawImage>().texture = pc.GetComponent<Camera>().targetTexture;
            Destroy(target.GetComponent<pixelatable>());
        }
        oldTargets = targets;
    }

    // Update is called once per frame
    void Update()
    {
        pixelatable[] targets = GameObject.FindObjectsOfType<pixelatable>();
        foreach (pixelatable target in targets)
        {
            if (!oldTargets.Contains(target))
            {
                var pc = Instantiate(pixelCameraPrefab, new Vector3(0, 47.2f, 0), pixelCameraPrefab.transform.rotation);
                pc.GetComponent<PixelCameraFollow>().spriteTransform = target.transform;
                pc.GetComponent<Camera>().targetTexture = new RenderTexture(target.GetComponent<pixelatable>().width, target.GetComponent<pixelatable>().height, 0);
                pc.GetComponent<Camera>().targetTexture.filterMode = FilterMode.Point;
                target.GetComponentInChildren<RawImage>().texture = pc.GetComponent<Camera>().targetTexture;
                Destroy(target.GetComponent<pixelatable>());
            }
        }
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("startButton")) && Time.timeScale == 0)
        {
            Resume();
        }
        else if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 1)
        {
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        UI.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        UI.SetActive(false);
    }
    public void EndMission()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
