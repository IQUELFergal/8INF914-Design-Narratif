using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLineTrigger : MonoBehaviour
{
    public void TriggerVoiceLine(VoiceLine voiceLine)
    {
        GameManager.Instance.VoiceLineManager.PlayVoiceLine(voiceLine, Color.white);
    }
}
