using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControler : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody2D rigidbody2D;

    float counter;

    private void Update()
    {
        counter += Time.deltaTime;

        if(Mathf.Abs(rigidbody2D.velocity.x) > occurAfterVelocity)
        {
            if(counter > dustFormationPeriod)
            {
                movementParticle.Play();
                counter = 0;
            }
        }
    }

}
