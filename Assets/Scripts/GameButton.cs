using UnityEngine;
using UnityEngine.Events;


public abstract class GameButton : MonoBehaviour,Interactable
{
    public void interact()
    {
        if (!isOpened())
        {
            PlayerAccess.getInstance().GetComponent<Animator>().SetTrigger("touch");
            interactSpecific();
        }
    }

    protected abstract void interactSpecific();
    protected abstract bool isOpened();


}
