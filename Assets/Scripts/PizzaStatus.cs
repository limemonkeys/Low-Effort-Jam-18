/* Base drag and drop system by Code Monkey
 * https://www.youtube.com/watch?v=BGr-7GZJNXg
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PizzaStatus : MonoBehaviour, IDropHandler
{
    public GameObject gameManager;

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag != null) 
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (eventData.pointerDrag.tag == "Topping")
            {
                gameManager.GetComponent<GameManager>().AddTopping(eventData.pointerDrag.name);
            }
            
        }
    }
}
