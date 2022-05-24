using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VoiceLine : ScriptableObject
{
    public AudioClip voiceClip;
    [TextArea(8,8)]
    public string voiceLine;

    public float voiceLineDuration = 1f;
    public float fadeDuration = 0.1f;
}
