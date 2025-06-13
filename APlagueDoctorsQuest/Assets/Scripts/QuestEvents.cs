using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

static class QuestEvents
{
    static public UnityEvent QuestStart = new UnityEvent();
    static public UnityEvent<float, float, float> Update = new UnityEvent<float, float, float>();
    static public UnityEvent MapObtained = new UnityEvent();
    static public UnityEvent DigForNecklace = new UnityEvent();
    static public UnityEvent NecklaceObtained = new UnityEvent();
    static public UnityEvent QuestComplete = new UnityEvent();
}
