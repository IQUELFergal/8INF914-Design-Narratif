using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    static Dialog currentDialog;
    static int currentDialogLineIndex = 0;
    static int currentLineIndex = 0;
    public static void OpenDialog(Dialog dialog)
    {
        GameManager.Instance.StateMachine.ChangeState(GameManager.Instance.DialogState);
        currentDialog = dialog;
        DialogUI.onOpenMenu?.Invoke();
        DialogUI.displayDialogLine?.Invoke(dialog.dialogLines[currentDialogLineIndex], currentLineIndex);
    }

    public static void ProgressDialog()
    {
        currentLineIndex++;
        if (currentLineIndex >= currentDialog.dialogLines[currentDialogLineIndex].lines.Length)
        {
            currentLineIndex = 0;
            currentDialogLineIndex++;
            if (currentDialogLineIndex >= currentDialog.dialogLines.Count)
            {
                currentDialogLineIndex = 0;
                CloseDialog();
                return;
            }
        }
        DialogUI.displayDialogLine?.Invoke(currentDialog.dialogLines[currentDialogLineIndex], currentLineIndex);
    }

    public static void CloseDialog()
    {
        GameManager.Instance.StateMachine.ChangeState(GameManager.Instance.StateMachine.LastState);
        DialogUI.onCloseMenu?.Invoke();
        currentDialog = null;
        currentDialogLineIndex = 0;
        currentLineIndex = 0;
    }
}
