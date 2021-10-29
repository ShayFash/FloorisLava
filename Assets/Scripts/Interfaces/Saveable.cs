
/**
 * Interface for objects that are saveable
 * 
 */
    public interface Saveable
    {
        /// <summary>
        /// Get the data to save from the saveable gameobject
        /// </summary>
        /// 
        /// <returns>SaveableData: data to save</returns>
        SaveableData saveObject();
        /// <summary>
        /// Load the object's status using the data supplied
        /// </summary>
        /// <param name="data">The data to use to replae the current status of the object</param>
        void loadObject(SaveableData data);
    }
