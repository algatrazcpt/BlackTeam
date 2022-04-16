using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSettings : MonoBehaviour
{
    [SerializeField] private string chipName;
    [SerializeField] private int chipId;
    [SerializeField] private string chipScene;
    public string ChipName { get => chipName; set => chipName = value; }
    public string ChipScene { get => chipScene; set => chipScene = value; }
    public int ChipId { get => chipId; set => chipId = value; }
}
