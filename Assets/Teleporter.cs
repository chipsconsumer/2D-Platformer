using UnityEngine;

public class Teleporter : MonoBehaviour

{

    [SerializeField] private Transform destination; // Punkt docelowy

    private void OnTriggerEnter2D(Collider2D other)

    {

        if (other.CompareTag("Player"))

        {

            // Teleportacja gracza do pozycji portalu docelowego

            other.transform.position = destination.position;

        }

    }

}
