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
using System.Collections.Generic;

public class GlowObject : MonoBehaviour
{
	public Color glowColor;
	[Range(1, 30)]
	[SerializeField]
	private float lerpMultiplier = 12;

	private List<Material> materials = new List<Material>();
	private Color currentColor, targetColor;
	private Renderer[] renders;

	private void Start()
	{
		renders = GetComponentsInChildren<Renderer>();
		for (int i = 0; i < renders.Length; i++)
		{
			materials.AddRange(renders[i].materials);
		}
	}

	private void Update()
	{
		if (currentColor == targetColor)
		{
			enabled = false;
		} else
		{
			currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * lerpMultiplier);
			for (int i = 0; i < materials.Count; i++)
			{
				materials[i].SetColor("_GlowColor", currentColor);
			}
		}
	}

	private void OnMouseEnter()
	{
		targetColor = glowColor;
		enabled = true;
	}

	private void OnMouseExit()
	{
		targetColor = Color.black;
		enabled = true;
	}
}
