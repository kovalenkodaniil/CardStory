using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvent : MonoBehaviour
{
    public static UnityAction<int> DestinyStoneChangeCount;
    public static UnityAction<Item> ItemTaked;
    public static UnityAction<int> KnowledgeChanged;
    public static UnityAction PlayerDied;
}
