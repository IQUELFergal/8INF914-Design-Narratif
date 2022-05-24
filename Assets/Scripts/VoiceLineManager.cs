using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VoiceLineManager : MonoBehaviour
{
    [SerializeField] AudioSource voiceSource;
    [SerializeField] TMP_Text subTitleText;
    Coroutine coroutine;

    public void PlayVoiceLine(VoiceLine voiceLine, Color textColor)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(VoiceLinePlayer(voiceLine, textColor));
    }

    IEnumerator ShowHideSubTitle(float duration, Color textColor, bool show)
    {
        Color baseColor;
        Color endColor;
        subTitleText.gameObject.SetActive(!show);
        if (show)
        {
            baseColor = new Color(textColor.r, textColor.g, textColor.b, 0);
            endColor = new Color(textColor.r, textColor.g, textColor.b, 1);
        }
        else
        {
            baseColor = new Color(textColor.r, textColor.g, textColor.b, 1);
            endColor = new Color(textColor.r, textColor.g, textColor.b, 0);
        }
        float t = 0;
        while (t < duration)
        {
            subTitleText.color = Color.Lerp(baseColor, endColor, t / duration);
            yield return null;
            t += Time.deltaTime;
        }
        subTitleText.color = endColor;
        subTitleText.gameObject.SetActive(show);
    }

    IEnumerator VoiceLinePlayer(VoiceLine voiceLine, Color textColor)
    {
        voiceSource.clip = voiceLine.voiceClip;
        voiceSource.Play();
        yield return ShowHideSubTitle(voiceLine.fadeDuration, textColor, true);
        subTitleText.text = voiceLine.voiceLine;
        float t = 0;
        while (t < voiceLine.voiceLineDuration)
        {
            yield return null;
            t += Time.deltaTime;
        }
        voiceSource.Stop();
        yield return ShowHideSubTitle(voiceLine.fadeDuration, textColor, false);
    }

}
