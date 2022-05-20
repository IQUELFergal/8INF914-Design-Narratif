using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dialog : ScriptableObject
{
    [System.Serializable]
    public class DialogLine
    {
        public Character character;
        [TextArea(3,3)]
        public string[] lines;
    }

    public List<DialogLine> dialogLines;
}
