using UnityEngine;
using UnityEngine.UI;

public class DifficultyDropdown : MonoBehaviour
{
    public Dropdown dropdown;

    void Start()
    {
        dropdown.onValueChanged.AddListener(delegate
        {
            myDropdownValueChangedHandler(dropdown);
        });
    }
    void Destroy()
    {
        dropdown.onValueChanged.RemoveAllListeners();
    }

    private void myDropdownValueChangedHandler(Dropdown target)
    {
        Debug.Log("selected: " + target.value);
    }

    public void SetDropdownIndex(int index)
    {
        dropdown.value = index;
    }
}
