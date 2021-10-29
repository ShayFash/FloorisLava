
    [System.Serializable]
    public class AllData
    {
        public SaveableData[] SaveableDatas;
        
        public AllData(int length)
        {
            SaveableDatas = new SaveableData[length];
            
        }
    }
