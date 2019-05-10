using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
	HealthManager healthManager;
	public static bool isDestroyed = false;
	public GameObject deadScreen;
    public GameObject deathCamera;
    public Renderer meshRender;

	void Start()
    {
		healthManager = GetComponent<HealthManager>();
		deadScreen = GameObject.Find("UI/InGameUI/DeadScreen");
        isDestroyed = false;
        
	}

	void Update()
    {
		if(healthManager.IsDead && !isDestroyed)
        {
			isDestroyed = true;

			StartCoroutine(ShowDeadScreen());

			MonoBehaviour[] scripts = GetComponentsInChildren<MonoBehaviour>();

			foreach(MonoBehaviour script in scripts)
            {
				if(script is WeaponBase)
                {
					DisableWeapon((WeaponBase)script);
				}
				else if(script is FirstPersonController)
                {
					DisableController((FirstPersonController)script);
				}
			}
		}
	}

	void DisableWeapon(WeaponBase weapon)
    {
		weapon.IsEnabled = false;
	}

	void DisableController(FirstPersonController controller)
    {
		controller.enabled = false;
	}

	IEnumerator ShowDeadScreen()
    {

        print("Player dead");
        GameObject.Find("FirstPersonCharacter").SetActive(false);

        Instantiate(deathCamera, transform.position, transform.rotation);

        meshRender.enabled = false;

        deadScreen.SetActive(true);

		Image image = deadScreen.GetComponent<Image>();
		Color origColor = image.color;

		for(float alpha = 0.0f; alpha <= 1.1f; alpha += 0.1f)
        {
			image.color = new Color(origColor.r, origColor.g, origColor.b, alpha);
			yield return new WaitForSeconds(0.1f);
		}

        yield return new WaitForSeconds(2.0f);

        Initiate.Fade("menu", Color.black, 2.0f);

		yield break;
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
    {
		if(hit.gameObject.tag == "BulletCase")
        {
			Physics.IgnoreCollision(GetComponent<Collider>(), hit.gameObject.GetComponent<Collider>());
		}
	}
}
