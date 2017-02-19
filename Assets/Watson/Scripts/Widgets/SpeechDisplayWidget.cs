/**
* Copyright 2015 IBM Corp. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/


using IBM.Watson.DeveloperCloud.DataTypes;
using IBM.Watson.DeveloperCloud.Services.SpeechToText.v1;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

#pragma warning disable 414

namespace IBM.Watson.DeveloperCloud.Widgets
{
	/// <summary>
	/// Simple class for displaying the SpeechToText result data in the UI.
	/// </summary>
	public class SpeechDisplayWidget : Widget
	{
		#region Inputs

		[SerializeField]
		private Input m_SpeechInput = new Input ("SpeechInput", typeof(SpeechToTextData), "OnSpeechInput");

		#endregion

		#region Widget interface

		/// <exclude />
		protected override string GetName ()
		{
			return "SpeechDisplay";
		}

		#endregion

		#region Private Data

		[SerializeField]
		private bool m_ContinuousText = false;
		[SerializeField]
		private Text m_Output = null;
		[SerializeField]
		private InputField m_OutputAsInputField = null;
		[SerializeField]
		private Text m_OutputStatus = null;
		[SerializeField]
		private float m_MinConfidenceToShow = 0.5f;

		private string m_PreviousOutputTextWithStatus = "";
		private string m_PreviousOutputText = "";
		private float m_ThresholdTimeFromLastInput = 3.0f;
		//3 secs as threshold time. After 3 secs from last OnSpeechInput, we are considering input as new input
		private float m_TimeAtLastInterim = 0.0f;
		public ArrayList finalList = new ArrayList ();
		public ArrayList interimList = new ArrayList ();

		//		public string[] getKeywordList() {
		//			string[] results = new string[keywordList.Capacity];
		//			for (int i = 0; i < results.Length; i++) {
		//				results [i] = (string)keywordList [i];
		//			}
		//			return results;
		//		}
		//
		//		public void clearKeywords() {
		//			keywordList = new ArrayList ();
		//		}

		#endregion

		#region Event Handlers

		private void OnSpeechInput (Data data)
		{
			if (m_Output != null || m_OutputAsInputField != null) {
				SpeechRecognitionEvent result = ((SpeechToTextData)data).Results;
				if (result != null && result.results.Length > 0) {
					string outputTextWithStatus = "";
					string outputText = "";

					if (Time.time - m_TimeAtLastInterim > m_ThresholdTimeFromLastInput) {
						if (m_Output != null)
							m_PreviousOutputTextWithStatus = m_Output.text;
						if (m_OutputAsInputField != null)
							m_PreviousOutputText = m_OutputAsInputField.text;
					}

					if (m_Output != null && m_ContinuousText)
						outputTextWithStatus = m_PreviousOutputTextWithStatus;

					if (m_OutputAsInputField != null && m_ContinuousText)
						outputText = m_PreviousOutputText;

					foreach (var res in result.results) {
						foreach (var alt in res.alternatives) {
							string text = alt.transcript;
							if (m_Output != null) {
								string o = string.Concat (outputTextWithStatus, string.Format ("{0} ({1}, {2:0.00})\n", text, res.final ? "Final" : "Interim", alt.confidence));
								//								keywordList.Add (o);
								//								print (o);
								if (res.final) {
									print (o);
									finalList.Add (o);
								} else {
									interimList.Add (o);
								}
							}

							if (m_OutputAsInputField != null) {
								if (!res.final || alt.confidence > m_MinConfidenceToShow) {
									m_OutputAsInputField.text = string.Concat (outputText, " ", text);

									if (m_OutputStatus != null) {
										string o = string.Format ("{0}, {1:0.00}", res.final ? "Final" : "Interim", alt.confidence);
										//										print (o);
										//										keywordList.Add (o);
									}
								}
							}

							if (!res.final)
								m_TimeAtLastInterim = Time.time;

						}
					}
				}
			}
		}

		#endregion

		private SpeechDisplayWidget speech = null;
		private bool isStart = true;
		private bool audio1 = false;
		private bool break1 = false;
		private bool saying1 = false;
		private bool saying2 = false;
		private bool audio4 = false;
		private bool audio2 = false;
		private bool audio3 = false;
		private DateTime t0 = System.DateTime.Now;
		private DateTime tt = System.DateTime.Now;
		private bool again = false;
		private AudioSource[] speakings;
		private int interimTimes = 0;
		private int finalTimes = 0;

		private bool detectKeyword (string[] keywords)
		{
			foreach (string keyword in keywords) {
				foreach (string sentence in finalList) {
					if (((string)sentence).Contains (keyword)) {
						return true;
					}
				}
			}
			return false;
		}

		//		void Start ()
		//		{
		//			t0 = System.DateTime.Now;
		//
		//		}
		//
		//		// Update is called once per frame
		void Update ()
		{
			if (isStart) {
				speakings = this.GetComponents<AudioSource> ();
				isStart = false;
				audio1 = true;

			}
			//		Thread.Sleep (3000);
			//		StartCoroutine(Fade());
			TimeSpan delta = System.DateTime.Now.Subtract (t0);
//			bool bad = detectKeyword (new string[] {"Ball", "mass", "weight", "two", "heavy", "light", "different", "high", "heavier", "higher", "masses", "gravity", "acceleration", "speed"});
//			print (bad);
			if (delta.Seconds > 17.5 && audio1) {
				speakings [0].Play ();
				t0 = System.DateTime.Now;
				audio1 = false;
				break1 = true;
			}

			if (delta.Seconds > 29 && break1) {
				break1 = false;
				saying1 = true;
				t0 = System.DateTime.Now;
				interimList.Clear ();
				finalList.Clear ();

			}

			if (delta.Seconds > 1 && saying1) {
				if (interimList.Count - interimTimes == 0 && System.DateTime.Now.Subtract(tt).Seconds > 2 && interimList.Count != 0) {
					saying1 = false;
					audio2 = true;
					interimList.Clear ();
					finalList.Clear ();
					t0 = System.DateTime.Now;
					interimTimes = 0;
					finalTimes = 0;
					again = false;
				} else {
					// Add Hint1
					if (interimList.Count - interimTimes > 0 && !again) {
						tt = System.DateTime.Now;
						again = true;
					}
					interimTimes = interimList.Count;
				}
			}

			if (delta.Seconds > 1 && audio2) {

				speakings [1].Play (); 
				t0 = System.DateTime.Now;
				audio2 = false;
				saying2 = true;
				interimList.Clear ();
				finalList.Clear ();
			}

			if (delta.Seconds > 1 && audio4) {
				speakings [2].Play ();
				print ("Hint6");
				t0 = System.DateTime.Now;
				audio4 = false;
				saying2 = true;
			}

			if (delta.Seconds > 6 && saying2) {
				if (interimList.Count - interimTimes == 0 && System.DateTime.Now.Subtract(tt).Seconds > 2 && interimList.Count != 0) {
					bool good = detectKeyword (new string[] {"experiment", "ball", "mass", "weight", "two", "heavy", "light", "different", "high", "heavier", "higher", "masses", "gravity", "acceleration", "speed"});
					interimList.Clear ();
					finalList.Clear ();
					interimTimes = 0;
					finalTimes = 0;
					if (good && !audio4) {
						// 5 seconds
						saying2 = false;
						audio3 = true;
						again = false;
						t0 = System.DateTime.Now;
						print ("Hint5");
					} else {
						saying2 = false;
						audio4 = true;
						again = false;
					}
				} else {
					// Hint2
					if (interimList.Count - interimTimes > 0 && !again) {
						tt = System.DateTime.Now;
						again = true;
					}
					interimTimes = interimList.Count;
				}
			}
			if (delta.Seconds > 1 && audio3) {
				print ("Hint7");
				speakings [3].Play (); 
				t0 = System.DateTime.Now;
				audio3 = false;
			}


			//			print("aaa");
			//


			//				try {
			//
			//					//					string[] sentenceList = this.getKeywordList ();
			//					print (System.DateTime.Now.Subtract(tt));
			//					for (int i = 0; i < keywordList.Count; i++) {
			//						print ("Sentence: " + keywordList [i]);
			//					}
			//					//					print("aaa");
			//				} catch (NullReferenceException e) {
			//					print ("Null");
			//				} catch (ArgumentOutOfRangeException e) {
			//					print("OutofRange");
			//				} finally {
			//					t0 = System.DateTime.Now;
			//				}
		}
	}
}