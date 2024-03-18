using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;


public class DropdownHandler : MonoBehaviour {

    public void OnValueChanged(int value){
        Debug.Log("Value: " + value);
    }
}
