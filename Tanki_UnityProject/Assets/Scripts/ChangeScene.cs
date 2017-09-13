﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public string SceneName;

    public void SetScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
