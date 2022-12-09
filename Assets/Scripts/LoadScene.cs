using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private Button button;
    public int scene = 1;
    public GameObject[] missiles;
    public GameObject[] DummyMissiles;
    public GameObject helicopter;
    public GameObject explosion;
    public bool isUnlocked = true;
    public bool isLevel = true;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        if (!isUnlocked)
        {
            GetComponent<Image>().color = new Color(0, 0, 0, 0.25f);
        }
    }
    void SetDifficulty()
    {
        if (isUnlocked)
        {
            StartCoroutine(startGame());
        }
        if (!isLevel)
        {
            SceneManager.LoadScene(scene);
        }
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(0.3f);
        missiles[0].SetActive(true);
        DummyMissiles[0].SetActive(false);
        Debug.Log(1);
        yield return new WaitForSeconds(0.15f);
        missiles[1].SetActive(true);
        DummyMissiles[1].SetActive(false);
        Debug.Log(1);
        yield return new WaitForSeconds(0.15f);
        missiles[2].SetActive(true);
        DummyMissiles[2].SetActive(false);
        Debug.Log(1);
        yield return new WaitForSeconds(0.15f);
        missiles[3].SetActive(true);
        DummyMissiles[3].SetActive(false);
        Debug.Log(1);
        //yield return new WaitForSeconds(0.15f);
        yield return new WaitForSeconds(1f);
        helicopter.SetActive(false);
        explosion.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
    }

}
