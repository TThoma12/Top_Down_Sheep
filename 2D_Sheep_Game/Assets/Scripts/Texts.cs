using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texts : MonoBehaviour
{
    public Dictionary<string, string> buttons = new Dictionary<string, string>
    {
        {"start", " " },
        {"settings", " " },
        {"back", " " },
        {"pause", " " },
        {"resume", " " },
        {"exit", " " },
    };
    public Dictionary<string, string> quests_names = new Dictionary<string, string>
    {
        {"find_sheep", " " },
        {"guide_sheep", " " }

    };

    public Dictionary<string, string> quests_description = new Dictionary<string, string>
    {
        {"find_sheep", " " },
        {"guide_sheep", " " }
    };

    public string credits = "";
}
