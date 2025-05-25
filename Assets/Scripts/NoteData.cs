using System.Collections.Generic;  // <-- Esto es clave

[System.Serializable]
public class NoteData
{
    public float time;
    public int lane;
    public float duration;
}

[System.Serializable]
public class SongData
{
    public List<NoteData> notes;
}

