using UnityEngine;
using UnityEngine.SceneManagement;
public class KillVolume : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            SceneManager.LoadScene("game fail");
        }
    }
}