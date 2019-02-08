using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [System.Serializable]
    public class UIObjects
    {
        public GameObject UI_Object;
    }
    public List<UIObjects> _UIObjects = new List<UIObjects>();



    [SerializeField]
    private int SceneIndex;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void ShowUIObjects(int indexUIObject)
    {
        _UIObjects[indexUIObject].UI_Object.gameObject.SetActive(true);
    }

    public void HideUIObjects(int indexUIObject)
    {
        _UIObjects[indexUIObject].UI_Object.gameObject.SetActive(false);
    }

}

