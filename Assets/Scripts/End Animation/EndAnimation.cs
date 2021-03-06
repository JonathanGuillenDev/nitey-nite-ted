using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndAnimation : MonoBehaviour {

	public GameObject Music;
	public Image effectImage;
	public Image slideImage;

	public List<Sprite> Sequence = new List<Sprite>();
	public float displayTime = 0.7f;
	private int currentSlide = 0;
	private int effectSlide = 8;

	private bool removeEff;

	// Use this for initialization
	void Start () {
		iTween.CameraFadeAdd();
		slideImage.sprite = Sequence[currentSlide];
		StartCoroutine("Slideshow");
		DontDestroyOnLoad(Music);
	}

	IEnumerator Slideshow(){
		yield return new WaitForSeconds(displayTime);
		currentSlide++;
	//	iTween.CameraFadeTo(1,0.3f);

		yield return new WaitForSeconds(0.3f);
		slideImage.sprite = Sequence[currentSlide];
		iTween.CameraFadeTo(0,0.3f);

		if(currentSlide == effectSlide)
			effectImage.enabled = false;

		yield return new WaitForSeconds(0.3f);
		if(currentSlide >= Sequence.Count - 1){
			yield return new WaitForSeconds(3);
			iTween.CameraFadeTo(1,2);
			yield return new WaitForSeconds(2);
			SceneManager.LoadScene("Credits");
		}
		else{
			StartCoroutine("Slideshow");
		}
	}
}
