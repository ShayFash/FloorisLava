
using UnityEngine;

public static class SaveManagerAccess
{
    private static SaveManager _saveManager;
    public static SaveManager getInstance()
    {
        if (_saveManager == null)
            _saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();

        return _saveManager;
    }
}
