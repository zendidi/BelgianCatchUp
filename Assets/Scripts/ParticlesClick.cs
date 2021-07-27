using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.UIElements;

public class ParticlesClick : MonoBehaviour
{
	public ParticleSystem particle1;
	public ParticleSystem particle2;
	public ParticleSystem particle3;
	public ParticleSystem particle4;
	public ParticleSystem particle5;
	public ParticleSystem particle6;
	public ParticleSystem particle7;

	public int ParticleSelector;
	public int ParticleHistory;


    Vector3 mousePosition;

    void Update()
	{
        MousePos();

        if (Input.GetButtonDown("Fire1"))
		{
                Shoot();
		}

        mousePosition = Input.mousePosition;
	}

    void MousePos()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    IEnumerator Cleaning(ParticleSystem wipeParticle)
    {
        float particleTime = wipeParticle.main.duration;
        yield return new WaitForSeconds(particleTime);
        Destroy(wipeParticle);
    }

    void Shoot() //random des differents effets, jamais deux fois le meme a la suite
	{
        ParticleSelector = Random.Range(0, 8);
        Debug.Log(ParticleSelector);

        if (ParticleSelector == 0 && ParticleHistory != 1 )
        {
            ParticleSystem ghost1 = ParticleSystem.Instantiate(particle1, new Vector3(mousePosition.x, mousePosition.y, mousePosition.z), Quaternion.identity);
            ghost1.Play();
            ParticleHistory = 1;
            Cleaning(ghost1);
        }
        else if (ParticleSelector == 1 && ParticleHistory!=2)
        {
            ParticleSystem ghost2 = ParticleSystem.Instantiate(particle2, new Vector3(mousePosition.x, mousePosition.y, mousePosition.z), Quaternion.identity);
            ghost2.Play();
            ParticleHistory = 2;
            Cleaning(ghost2);
        }
        else if (ParticleSelector == 2 && ParticleHistory != 3)
        {
            ParticleSystem ghost3 = ParticleSystem.Instantiate(particle3, new Vector3(mousePosition.x, mousePosition.y, mousePosition.z), Quaternion.identity);
            ghost3.Play();
            ParticleHistory = 3;
            Cleaning(ghost3);
        }
        else if (ParticleSelector == 3 && ParticleHistory != 4)
        {
            ParticleSystem ghost4 = ParticleSystem.Instantiate(particle4, new Vector3(mousePosition.x, mousePosition.y, mousePosition.z), Quaternion.identity);
            ghost4.Play();
            ParticleHistory = 4;
            Cleaning(ghost4);
        }
        else if (ParticleSelector == 4 && ParticleHistory != 5)
        {
            ParticleSystem ghost5 = ParticleSystem.Instantiate(particle5, new Vector3(mousePosition.x, mousePosition.y, mousePosition.z), Quaternion.identity);
            ghost5.Play();
            ParticleHistory = 5;
            Cleaning(ghost5);
        }
        else if (ParticleSelector == 5 && ParticleHistory != 6)
        {
            ParticleSystem ghost6 = ParticleSystem.Instantiate(particle6, new Vector3(mousePosition.x, mousePosition.y, mousePosition.z), Quaternion.identity);
            ghost6.Play();
            ParticleHistory = 6;
            Cleaning(ghost6);
        }
        else if (ParticleSelector == 6 && ParticleHistory != 7)
        {
            ParticleSystem ghost7 = ParticleSystem.Instantiate(particle7, new Vector3(mousePosition.x, mousePosition.y, mousePosition.z), Quaternion.identity);
            ghost7.Play();
            ParticleHistory = 7;
            Cleaning(ghost7);
        }
        else
        {
            Shoot();
        }
    }
}
