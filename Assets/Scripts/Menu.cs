using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField] InputField NameField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        if (!string.IsNullOrWhiteSpace(NameField.text))
        {
            GameState.Instance.PlayerName = NameField.text;
            SceneManager.LoadScene(1);
        }
    }
}
