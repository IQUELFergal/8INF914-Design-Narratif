using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu
{
    public static Action onOpenMenu;
    public static Action onCloseMenu;

    protected void OnEnable()
    {
        onOpenMenu += Open;
        onCloseMenu += Close;
    }

    protected void OnDisable()
    {
        onOpenMenu -= Open;
        onCloseMenu -= Close;
    }

    public void Play()
    {
        GameManager.Instance.StateMachine.ChangeState(GameManager.Instance.PlayState);
    }

    public void OpenSettingsMenu()
    {
        SettingsMenu.onOpenMenu?.Invoke();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
