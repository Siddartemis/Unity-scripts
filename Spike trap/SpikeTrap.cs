using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private Animator anim;
    private bool canTrigger = true;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && canTrigger == true)
        {
            canTrigger = false;
            StartCoroutine("SpikeRoutine");
        }
    }

    private IEnumerator SpikeRoutine()
    {
        yield return new WaitForSeconds(2);
        anim.SetTrigger("TriggerSpikes");
        gameObject.tag = "environement hazard";
        yield return new WaitForSeconds(2);
        anim.SetTrigger("SpikesIn");
        gameObject.tag = "Untagged";
        canTrigger = true;

    }
}
