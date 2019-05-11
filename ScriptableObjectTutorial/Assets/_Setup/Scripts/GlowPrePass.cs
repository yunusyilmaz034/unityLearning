/*
 * Copyright (c) 2018 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GlowPrePass : MonoBehaviour
{
	private static RenderTexture prePass;
	private static RenderTexture blurred;

	private Material blurMat;

	private void OnEnable()
	{
		prePass = new RenderTexture(Screen.width, Screen.height, 24);
		prePass.antiAliasing = QualitySettings.antiAliasing;
		blurred = new RenderTexture(Screen.width >> 1, Screen.height >> 1, 0);

		Camera camera = GetComponent<Camera>();
		Shader glowShader = Shader.Find("Hidden/GlowReplace");
		camera.targetTexture = prePass;
		camera.SetReplacementShader(glowShader, "Glowable");
		Shader.SetGlobalTexture("_GlowPrePassTex", prePass);

		Shader.SetGlobalTexture("_GlowBlurredTex", blurred);

		blurMat = new Material(Shader.Find("Hidden/Blur"));
		blurMat.SetVector("_BlurSize", new Vector2(blurred.texelSize.x * 1.5f, blurred.texelSize.y * 1.5f));
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination);

		Graphics.SetRenderTarget(blurred);
		GL.Clear(false, true, Color.clear);

		Graphics.Blit(source, blurred);

		for (int i = 0; i < 4; i++)
		{
			RenderTexture temp = RenderTexture.GetTemporary(blurred.width, blurred.height);
			Graphics.Blit(blurred, temp, blurMat, 0);
			Graphics.Blit(temp, blurred, blurMat, 1);
			RenderTexture.ReleaseTemporary(temp);
		}

		Graphics.Blit(source, destination);
	}
}
