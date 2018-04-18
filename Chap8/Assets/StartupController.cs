using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartupController : MonoBehaviour {
    [SerializeField] private Slider progressBar;

    void Start()
    {
        Messenger.AddListener<int, int>(StartupEvent.MANAGERS_PROGRESS, OnManagersProgress);
        Messenger.AddListener(StartupEvent.MANAGERS_STARTED, OnManagersStarted);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener<int, int>(StartupEvent.MANAGERS_PROGRESS,
        OnManagersProgress);
        Messenger.RemoveListener(StartupEvent.MANAGERS_STARTED,
        OnManagersStarted);
    }
    private void OnManagersProgress(int numReady, int numModules)
    {
        float progress = (float)numReady / numModules;
        progressBar.value = progress;
    }
    private void OnManagersStarted()
    {
        Managers.Mission.GoToNext();
    }
}
