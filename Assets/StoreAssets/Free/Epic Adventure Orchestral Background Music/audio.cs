using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class audio : MonoBehaviour {
	public float bpm = 150.0F;
	public int beatsPerMeasure = 4;
	public AudioClip[] clips_A = new AudioClip[10];
	public AudioClip[] clips_B = new AudioClip[10];
	public AudioClip[] clips_trans = new AudioClip[10];
	private double singleMeasureTime;
	private double delayEvent;
	private AudioSource[] audioSources_A_samples = new AudioSource[10];
	private AudioSource[] audioSources_B_samples = new AudioSource[10];
	private AudioSource[] audioSources_transitions = new AudioSource[10];
	private bool running = false;
	private bool exploration_intro = false;
	private bool exploration_main = false;
	private bool exploration_1A = false;
	private bool exploration_1B = false;
	private bool battle_1A = false;
	private bool battle_1B = false;
	private bool battle_1A_rep = false;
	private bool battle_1B_rep = false;
	private bool exploration_strong = false;
	private bool battle1 = false;
	private bool battle1_start = false;
	private bool battle1_end = false;
	private bool battle1_finish = false;
	private bool battle2 = false;
	private bool soft_transition = false;
	private bool one_time_event = false;
	private int i;
	private int j;
	void Start() {
		int i = 0;
		while (i < 10) {
			GameObject child = new GameObject("Audio_A");
			child.transform.parent = gameObject.transform;
			audioSources_A_samples[i] = child.AddComponent<AudioSource>() as AudioSource;

			GameObject child2 = new GameObject("Audio_B");
			child2.transform.parent = gameObject.transform;
			audioSources_B_samples[i] = child2.AddComponent<AudioSource>() as AudioSource;

			GameObject child3 = new GameObject("Transitions");
			child2.transform.parent = gameObject.transform;
			audioSources_transitions[i] = child2.AddComponent<AudioSource>() as AudioSource;

			i++;
		}
		singleMeasureTime = AudioSettings.dspTime + 2.0F;
		running = true;
	}
	void Update() {
				if (!running)
						return;
				double time = AudioSettings.dspTime;

		//To run the exploration samples with the intro
		if (Input.GetKey(KeyCode.I)) {
			i=0;
			Debug.Log ("The E key was pressed");
			exploration_intro = true;
			exploration_main=false;
			exploration_strong = false;
			battle1 = false;
			battle2 = false;
		}

		//To run only the soft exploration samples without intro
		if (Input.GetKey(KeyCode.E)) {
			Debug.Log ("The E key was pressed");
			exploration_intro = false;
			exploration_main=true;
			soft_transition = true;
			exploration_strong = false;
			battle1 = false;
			battle2 = false;
		}

		//To run the strong exploration samples
		if (Input.GetKey(KeyCode.T)) {
			Debug.Log ("The T key was pressed");
			exploration_strong = true;
			exploration_intro = false;
			exploration_main=false;
			battle1 = false;
			battle2 = false;
			soft_transition = true;
		}

		//To run the Battle1 samples with start
		if (Input.GetKey(KeyCode.B)) {
			Debug.Log ("The B key was pressed");
			exploration_strong = false;
			exploration_intro = false;
			exploration_main=false;
			battle1_start=true;
			battle1 = false;
			battle2 = false;
			soft_transition = false;
		}

		//To end Battle1 and start the intro exploration again
		if (Input.GetKey(KeyCode.F)) {
			Debug.Log ("The B key was pressed");
			exploration_strong = false;
			exploration_intro = false;
			exploration_main=false;
			battle1_end =true;
			battle1 = false;
			battle2 = false;
			soft_transition = false;
		}


		if (exploration_intro) {
			if (time + 1.0F > singleMeasureTime) {
				if (i==0){
					audioSources_transitions [0].clip = clips_trans [0];
					audioSources_transitions [0].PlayScheduled (time);
				}
					if (i == 4){
						i=0;
						Debug.Log ("The switch to the main exploration theme was called");
						exploration_intro = false;
						exploration_main = true;
						exploration_1A = true;
					}
			}
		}
				

		if (exploration_strong) {
			if (time + 1.0F > singleMeasureTime) {
				if (i==0 | i ==16){
					exploration_1A = true;
				}
				if (i==8 | i==24 ){
					exploration_1B = true;
				}
				Debug.Log ("The i int equals  " + i + " And the booleans exploration_1a and 1b are respectively " + exploration_1A + " " + exploration_1B);
			}

			if (exploration_1A){
				audioSources_A_samples [1].clip = clips_A [1];
				audioSources_A_samples [1].PlayScheduled (time);
				exploration_1A = false;
			}

			if (exploration_1B) {
				audioSources_B_samples [1].clip = clips_B [1];
				audioSources_B_samples [1].PlayScheduled (time);
				exploration_1B = false;
			}
		}

		if (exploration_main) {
			if (time + 1.0F > singleMeasureTime) {
				if (i==0 | i ==16){
					exploration_1A = true;
				}
				if (i==8 | i==24 ){
					exploration_1B = true;
				}
				Debug.Log ("The i int equals  " + i + " And the booleans exploration_1a and 1b are respectively " + exploration_1A + " " + exploration_1B);
			}
			
			if (exploration_1A){
				audioSources_A_samples [0].clip = clips_A [0];
				audioSources_A_samples [0].PlayScheduled (time);
				exploration_1A = false;
			}
			
			
			if (exploration_1B) {
				audioSources_B_samples [0].clip = clips_B [0];
				audioSources_B_samples [0].PlayScheduled (time);
				exploration_1B = false;
			}
		}

		if (battle1) {
			if (time + 1.0F > singleMeasureTime) {
				if (i==0){
					battle_1A = true;
				}
				if (i==2){
					battle_1A_rep = true;
				}
				if (i==4){
					battle_1B = true;
				}
				if (i==6 ){
					battle_1B_rep = true;
				}
				if(i==8){
					i=0;
					battle_1A = true;
				}
				Debug.Log ("the booleans battle_1a and 1b are respectively " + battle_1A + " " + battle_1B+ " " + battle_1A_rep+ " " + battle_1B_rep);
			}
			
			if (battle_1A){
				audioSources_A_samples [2].clip = clips_A [2];
				audioSources_A_samples [2].PlayScheduled (time);
				battle_1A = false;
			}

			if (battle_1A_rep){
				audioSources_B_samples [2].clip = clips_B [2];
				audioSources_B_samples [2].PlayScheduled (time);
				battle_1A_rep = false;
			}
				
			if (battle_1B) {
				audioSources_A_samples [3].clip = clips_A [3];
				audioSources_A_samples [3].PlayScheduled (time);
				battle_1B = false;
			}
			if (battle_1B_rep) {
				audioSources_B_samples [3].clip = clips_B [3];
				audioSources_B_samples [3].PlayScheduled (time);
				battle_1B_rep = false;
			}
		}

				if (soft_transition) {
					if (i==0|i==8|i==16|i==24){
						audioSources_transitions [1].clip = clips_trans [1];
						audioSources_transitions [1].PlayScheduled (time);
						soft_transition = false;
					}	
				}


		if (battle1_start) {
			if (time + 1.0F > singleMeasureTime) {
				if (i==0|i==8|i==16|i==24){
					j=i;
					audioSources_transitions [3].clip = clips_trans [3];
					audioSources_transitions [3].PlayScheduled (time);
					battle_1A = true;

				}
				if(i == j+1){
					battle1_start = false;
					battle1=true;
					Debug.Log ("the booleans battle1 is " + battle1);
					i=0;
					j=100;
	
				}
			}
		}

		if (battle1_end) {
			if (time + 1.0F > singleMeasureTime) {
				if (i==0){
					battle1_finish = true;
				}
				if (i==2){
					battle_1A_rep = true;
				}
				if (i==4){
					battle_1B = true;
				}
				if (i==6 ){
					battle_1B_rep = true;
				}
				if(i==8){
					i=0;
					battle1_finish = true;
				}
				Debug.Log ("the booleans battle_1a and 1b are respectively " + battle_1A + " " + battle_1B+ " " + battle_1A_rep+ " " + battle_1B_rep);
			}
			
			if (battle1_finish){
				j=i;
				audioSources_transitions [4].clip = clips_trans [4];
				audioSources_transitions [4].PlayScheduled (time);
				battle1_finish = false;
			}
			
			if (battle_1A_rep){
				audioSources_B_samples [2].clip = clips_B [2];
				audioSources_B_samples [2].PlayScheduled (time);
				battle_1A_rep = false;
			}
			
			
			if (battle_1B) {
				audioSources_A_samples [3].clip = clips_A [3];
				audioSources_A_samples [3].PlayScheduled (time);
				battle_1B = false;
			}
			if (battle_1B_rep) {
				audioSources_B_samples [3].clip = clips_B [3];
				audioSources_B_samples [3].PlayScheduled (time);
				battle_1B_rep = false;
			}
			if (i== j+2){
					battle1_end = false;
					exploration_intro = true;
					i=0;
			}

			
		}

		//THE most important part of this script: this is the metronome, keeping count of the measures and making sure the audio is in sync
		if (time + 1.0F > singleMeasureTime) {
			i +=1;
			Debug.Log ("The i int equals  " + i);
			if (i==32){
				i = 0;
			}
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
		}

	}
}