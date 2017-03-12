using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    [SerializeField] float fireRate;
    [SerializeField] float delay;

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire",delay,fireRate); // InvokeRepeating用来重复调用某个方法
	}

    void Fire()
    {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audioSource.Play();
    }		
}
