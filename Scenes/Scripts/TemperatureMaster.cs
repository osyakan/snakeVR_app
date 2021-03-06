// 視界の変化を操作するクラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

// switchflagを立ち上げることによって視界を変化させる

public class TemperatureMaster : MonoBehaviour
{
    [Header("Resource References")]
	[Tooltip("ThermalVision.shader")]
	public Shader ThermalVision;
	[Tooltip("ThermalVisionSurfaceReplacement.shader")]
	public Shader TVSurfaceReplacement; // cool replacement material
	[Tooltip("ThermalVisionPalettes.png")]
	public Texture2D ReferencePalette;
	[Header("ReferencePalette")]
	public float environmentTemperature = 26;
    Material ThermalVisionMaterial = null;
    Material SkyboxMaterialCached = null;
    Material SkyboxMaterialReplacement = null;
    public bool TVflag;
    public float max_degree_float = 100.0f;
    public float min_degree_float = 0.0f;
	bool switchflag;
    public Camera camera;
	public GameObject PointLight;
	public GameObject Sunlight;

    void Awake()
    {
		switchflag = true;
		TVflag = false;
        SkyboxMaterialCached = RenderSettings.skybox;
        ThermalVisionMaterial = new Material(ThermalVision);
        SkyboxMaterialReplacement = new Material(TVSurfaceReplacement);
		PointLight.SetActive(false);
		Sunlight.SetActive(true);
    }

	void Start()
	{
		foreach(TemperatureAssign TC in GetAllTemperatureAssigns())
		{
			Renderer R = TC.gameObject.GetComponent<Renderer>();
			if (R==null) continue;
			//シェーダーのタグを保持させる
			TC.cachedMaterialTag = R.material.GetTag("RenderType", false);
			// もとの色を保持させる
			TC.cachedColor = R.material.color;
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (switchflag)
		{
			switchflag = false;
			TVflag = !TVflag;
			List<TemperatureAssign> TCs = GetAllTemperatureAssigns();
			if(TVflag){
				// ポイントライト点灯
				PointLight.SetActive(true);
				Sunlight.SetActive(false);

				// 空の背景色をSkyboxMaterialReplacementに変更
					RenderSettings.skybox = SkyboxMaterialReplacement;
					// replace material tags and color for objects with explicit temperature control
					foreach (TemperatureAssign TC in TCs) {
						Renderer R = TC.gameObject.GetComponent<Renderer>();
						if (R==null) continue;
						//シェーダーのタグを保持させる
						TC.cachedMaterialTag = R.material.GetTag("RenderType", false);
						// もとの色を保持させる
						TC.cachedColor = R.material.color;

						TC.gameObject.GetComponent<Renderer>().material.SetOverrideTag("RenderType", "Temperature");
						TC.gameObject.GetComponent<Renderer>().material.color = new Color(degree2float(TC.temperature_degree), 0, 0, 0);
						
					}
			}
			else{
				// ポイントライト消灯
				Sunlight.SetActive(true);
				PointLight.SetActive(false);

					// 空の背景色をSkyboxMaterialCachedに変更
					RenderSettings.skybox = SkyboxMaterialCached;

					// restore temperature-controlled object tags and color
					foreach (TemperatureAssign TC in TCs) {
						Renderer R = TC.gameObject.GetComponent<Renderer>();
						if (R==null) continue;
						TC.gameObject.GetComponent<Renderer>().material.SetOverrideTag("RenderType", TC.cachedMaterialTag);
						TC.gameObject.GetComponent<Renderer>().material.color = TC.cachedColor;
					}
					// everything else
					camera.ResetReplacementShader();
			}
		}
        
    }

    // シェーダーを変更
    void OnRenderImage(RenderTexture src, RenderTexture dst) {

		Shader.SetGlobalFloat("_EnvironmentTemperature", degree2float(environmentTemperature));
		ThermalVisionMaterial.SetFloat("_EnvironmentTemperature", degree2float(environmentTemperature));
		if (TVflag) {
            ThermalVisionMaterial.SetTexture("_ReferencePalette", ReferencePalette);
			
			Graphics.Blit(src, dst, ThermalVisionMaterial);

		} else {
			Graphics.Blit(src, dst);
		}
	}

    float degree2float(float degree){
        if (degree>=max_degree_float)
            return 1.0f;
        else if (degree<=min_degree_float)
            return 0.0f;
        return 1.0f*degree/(max_degree_float-min_degree_float);

    }

	public void OnStandSwitchingView()
	{
		switchflag = true;
	}

    // TemperatureAssignクラスを保持しているオブジェクトを返す
    List<TemperatureAssign> GetAllTemperatureAssigns() {
		List<TemperatureAssign> TCs = new List<TemperatureAssign>();
		foreach(TemperatureAssign TC in Resources.FindObjectsOfTypeAll(typeof(TemperatureAssign)) as TemperatureAssign[]) {
			// if (!EditorUtility.IsPersistent(TC.transform.root.gameObject) && 
			// 		!(TC.hideFlags == HideFlags.NotEditable || TC.hideFlags == HideFlags.HideAndDontSave)) {
			if (!(TC.hideFlags == HideFlags.NotEditable || TC.hideFlags == HideFlags.HideAndDontSave)) {
				TCs.Add(TC);
			}
		}
		return TCs;
	}
}
