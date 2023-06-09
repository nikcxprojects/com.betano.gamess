using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance 
    { 
        get => FindObjectOfType<UIManager>(); 
    }

    private GameObject _gameRef;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;
    [SerializeField] GameObject settings;


    [Space(10)]
    [SerializeField] AudioSource sfxSource;

    private void Awake()
    {
        
    }


    private void Start()
    {
        OpenMenu();
    }


    public void OpenSettings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void StartGame()
    {
        if (_gameRef)
        {
            Destroy(_gameRef);
        }

        var _parent = GameObject.Find("Environment").transform;
        var _prefab = Resources.Load<GameObject>("level");

        _gameRef = Instantiate(_prefab, _parent);

        menu.SetActive(false);
        game.SetActive(true);
    }

    public void Stop()
    {
        var greenLine = GameObject.Find("green line").transform;
        var indicator = GameObject.Find("indicator").transform;

        var distance = Vector2.Distance(greenLine.position, indicator.position);
        var IsTrue = distance <= 0.562f;

        if(!IsTrue)
        {
            var expl = Instantiate(Resources.Load<GameObject>("explosion"));
            Destroy(expl, 1.0f);
        }

        var popupResult = IsTrue ? "cool" : "lose";
        var prefab = Resources.Load<GameObject>(popupResult);

        var popup = Instantiate(prefab);
        Destroy(popup, 1.0f);

        StartGame();
    }

    public void OpenMenu()
    {
        if(_gameRef)
        {
            Destroy(_gameRef);
        }

        settings.SetActive(false);
        game.SetActive(false);
        menu.SetActive(true);
    }
}
