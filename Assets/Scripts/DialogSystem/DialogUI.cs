using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogUI : Menu
{
    [Header("Character")]
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Image portraitImage;

    [Header("Dialog")]
    [SerializeField] TextMeshProUGUI dialogText;

    public static Action<Dialog.DialogLine, int> displayDialogLine;
    public static Action onOpenMenu;
    public static Action onCloseMenu;

    protected void OnEnable()
    {
        onOpenMenu += Open;
        onCloseMenu += Close;
        displayDialogLine += SetupUI;
    }

    protected void OnDisable()
    {
        onOpenMenu -= Open;
        onCloseMenu -= Close;
        displayDialogLine -= SetupUI;
    }

    void SetupUI(Dialog.DialogLine dialogLine, int lineIndex)
    {
        nameText.text = dialogLine.character.displayName;
        portraitImage.sprite = dialogLine.character.portrait;
        dialogText.text = dialogLine.lines[lineIndex];
    }
}
