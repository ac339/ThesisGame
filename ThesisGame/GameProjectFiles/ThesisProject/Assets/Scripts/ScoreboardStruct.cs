using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct ScoreboardStruct {

        [System.Serializable]
        public struct ArrayEntry
        {
            public string entryname;
            public string name;
            public int score;
            public int seed;
        }
    public ArrayEntry[] scoreboardstruct;
}
   



