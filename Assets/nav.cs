using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nav : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void index()
	{
		SceneManager.LoadScene ("index");
	}

	public void uno()
	{
		SceneManager.LoadScene ("uno");
	}

	public void dos()
	{
		SceneManager.LoadScene ("dos");
	}

	public void tres()
	{
		SceneManager.LoadScene ("tres");
	}

	public void cuatro()
	{
		SceneManager.LoadScene ("cuatro");
	}

	public void cinco()
	{
		SceneManager.LoadScene ("cinco");
	}

	public void seis()
	{
		SceneManager.LoadScene ("seis");
	}

	public void siete()
	{
		SceneManager.LoadScene ("siete");
	}

	public void ocho()
	{
		SceneManager.LoadScene ("ocho");
	}

	public void nueve()
	{
		SceneManager.LoadScene ("nueve");
	}

	public void diez()
	{
		SceneManager.LoadScene ("diez");
	}

	public void once()
	{
		SceneManager.LoadScene ("once");
	}

	public void doce()
	{
		SceneManager.LoadScene ("doce");
	}

	public void registro()
	{

		Application.ExternalEval ("window.open(\"https://goo.gl/SjvBb6\",\"_blank\")");
	}


	public void conferencias()
	{

		Application.ExternalEval ("window.open(\"https://www.intertraffic.com/es/mexico/programme/conference/\",\"_blank\")");
	}

}
