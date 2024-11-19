using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuManager : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
