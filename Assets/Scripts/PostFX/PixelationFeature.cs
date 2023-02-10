// Credits: whateep
// https://github.com/whateep/unity-simple-URP-pixelation

using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PixelationFeature : ScriptableRendererFeature
{
	[System.Serializable]
	public class CustomPassSettings
	{
		public RenderPassEvent renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
		public int screenHeight = 360;
	}

	[SerializeField]
	private CustomPassSettings settings;

	private PixelationPass customPass;

	public override void Create()
	{
		customPass = new PixelationPass(settings);
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{

#if UNITY_EDITOR

		if (renderingData.cameraData.isSceneViewCamera) return;

#endif

		renderer.EnqueuePass(customPass);
	}
}
