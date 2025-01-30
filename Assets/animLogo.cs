using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using System.Threading.Tasks;

public class animLogo : MonoBehaviour
{
    public GameObject[] objetos; // El objeto UI a mover

    async void Start()
    {
       
        for (var i = 0; i < objetos.Length; i++) {
            Vector3 finalPos = objetos[i].transform.position;
            Vector3 finalRot = objetos[i].transform.eulerAngles;
            if (i % 2 == 0)
            {
                objetos[i].transform.position = new Vector3(finalPos.x - 300, finalPos.y, finalPos.z);
            }
            else {
                objetos[i].transform.position = new Vector3(finalPos.x + 600, finalPos.y, finalPos.z); 
            }
                objetos[i].transform.eulerAngles = new Vector3(0,0, 0);
                objetos[i].SetActive(true);
                LeanTween.move(objetos[i], finalPos, 1f).setEase(LeanTweenType.easeOutCirc);
                LeanTween.rotate(objetos[i], finalRot, 1.5f);
                await Task.Delay(1000);
        
        }

    }
}
