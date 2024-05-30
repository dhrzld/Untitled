using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RaycastDisplayInfo : MonoBehaviour
{
    public Text infoText; 
    public float displayDuration = 2.0f; 
    public float maxDistance = 1.0f; 

    private Coroutine displayCoroutine;

    void Update()
    {
       
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, maxDistance))
        {

            if (hit.distance <= maxDistance)
            {
              
                string hitInfo = $"Hit Object: {hit.collider.name}\n" +
                                 $"Position: {hit.point}\n" +
                                 $"Distance: {hit.distance}";
                infoText.text = hitInfo;

               
                if (displayCoroutine != null)
                {
                    StopCoroutine(displayCoroutine);
                }
               
                displayCoroutine = StartCoroutine(ClearInfoTextAfterDelay(displayDuration));

               
                Debug.Log(hitInfo);
            }
        }
        else
        {
           
            infoText.text = "No hit detected.";

            
            if (displayCoroutine != null)
            {
                StopCoroutine(displayCoroutine);
            }
            displayCoroutine = StartCoroutine(ClearInfoTextAfterDelay(displayDuration));
        }
    }

    private IEnumerator ClearInfoTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        infoText.text = "";
    }
}
