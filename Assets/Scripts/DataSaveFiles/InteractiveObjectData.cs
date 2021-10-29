
[System.Serializable]
public class InteractiveObjectData:SaveableData
{
    public bool Open;

    public InteractiveObjectData(bool open)
    {
        this.Open = open;
    }
}
