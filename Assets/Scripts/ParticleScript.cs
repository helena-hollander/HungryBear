using Unity.VisualScripting;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
   public ParticleSystem particle;
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         particle.Play();
      }
   }
}
