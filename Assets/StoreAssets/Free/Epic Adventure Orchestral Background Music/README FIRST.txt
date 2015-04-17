Epic Adventure Orchestral Background Music (Free Sample): SETUP GUIDE

Dear Unity Developer,
Thank you for downloading this package.

Here are some indications as to how to use these samples.

These samples are NOT to be used by simply activating the "loop" function.  In order to avoid abrupt cuts in the natural release of instruments (the time it takes for the reverb and sound to completely disappear)
you have to alternate between two samples instead of looping them.  

For instance, if you have 2 samples that are 12 beats and 3 measures long, this means that you will have to make sure the second sample starts at the 9TH BEAT or 3rd MEASURE of the first one to have a seamless transition.
To illustrate this, imagine that the length of a sample is illustrated by the numbers below with 12 beats in total.
The lines _ mean that there is music playing during these beats.  The X marks means that there is silence and the natural release of the sound.
In the illustration below, sample 1B starts after 8 beats or exactly on the 9th beat of sample 1A. This can go on until you decide to play another loop or end the cycle with an "end" sample.

SAMPLE 1A

1  2  3  4  5  6  7  8  9  10 11 12             1  2  3  4  5  6  7  8  9  10 11 12
_  _  _  _  _  _  _  _  X  X  X  X              _  _  _  _  _  _  _  _  X  X  X  X 


SAMPLE 1B

                        1  2  3  4  5  6  7  8  9  10 11 12 
          		_  _  _  _  _  _  _  _  X  X  X  X

Music always works well in sequences of two.  Meaning you can either repeat twice the sample sample, or alternate twice between samples A and B.
Usually, odd numbers don't work well in music.  Meaning if you repeat a sample 3 times and then go to another sample, it will sound strange.
This has to do with music structure and the deep cultural roots of western music, so keep it in mind when you program your loops! :)


The script provided with the package does this for you.

The piece of code below (at the very end of the script) simply counts the NUMBER OF MEASURES through the i variable and goes up to 32 measures, then resets and starts counting again.
Why 32 measures? Because that is the MAXIMUM length of the samples I have included in this package (the main exploration themes 1a, 1b, 2a and 2b)
Thanks to this code, I can then set conditions to play the next sample after i has reached measure 32 or after it has reset to 0.

if (time + 1.0F > singleMeasureTime) {
			i +=1;
			Debug.Log ("The i int equals  " + i);
			if (i==32){
				i = 0;
			}
			singleMeasureTime += 60.0F / bpm * beatsPerMeasure;
		}


HOW TO SET UP THIS SCRIPT
-------------------------

You simply need to drag and drop the samples into the script's Array lists entitled "Clips_A", "Clips_B" and "Clips_C" as shown in the screenshot provided with this package ("setup.png")
Make sure the BPM (tempo) is set to 150 and the "beats per measure" to 4.
All the checkboxes should be UNCHECKED (mute, bypass effects, bypass listener effects...)

When you press "PLAY" to run the scene with the audio object and the attached script set up as indicated, you simply need to press the following keys to activate the different seemless transitions:

- Pressing "I" will start playing the exploration theme with an 8 measure introduction.
- Pressing "E" will start playing the exploration theme directly with no introduction.
- Pressing "T" will start playing the stronger exploration theme.
- Pressing "B" will let transition to the Battle mode.
- Pressing "F" will break out of Battle mode and restart the exploration theme with the introduction.

IMPORTANT TO REMEMBER
---------------------

Please note that you need to wait before some transitions occur. This is precisely to AVOID doing the good old "fade in - fade out" effects that you hear in many soundtracks.
The transitions will occur always at the end of the natural musical "cycle" of the samples so it sounds like a regular composition.

For instance, if you are in Battle mode, the "natural" sequence of the samples is 1A repeated twive then 1B repeated twice.
If you press the "F" key while in Battle mode ("B" key), the transition to break out of battle mode will only be played once the second repetition of 1B was played.



HOW TO USE THIS SCRIPT IN YOUR GAME
-----------------------------------

You can easily replace the code (below) that triggers the different samples to be played and looped with your own trigger 
(for instance placing a trigger in your game that checks how far an enemy is and prepare for the transition early).

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

For instance, you can put a boolean instead of the "Input.GetKey" in the "if" statement which will become true once the character has reached a certain point.
Remember that to have a good user experience with this technique, the key word is ANTICIPATION.  
You need to predict for instance that the player is likely to reach an enemy in 2, 3, or more seconds and trigger the transition in advance so that the Battle sequence 
initiates as close as possible with the actual encounter with the enemy.  Similarily, while in Battle, you need to calculate when all enemies are likely to be slain 
by measuring for instance their remaining health and that of the player to trigger the "end battle" sequence as close as possible to either the death of all enemies or that of the player.

WHAT'S LEFT FOR YOU TO DO?
-------------------------

The script includes the code to transition between exploration themes and into the battle theme 1.
You will need to code the remainder of the transitions between the different battle themes if you want to use these.
Why?  Well, I'm a self-taught coder and I don't have enough time to code it all by myself, especially not for free... :-P
Normally, if you look at the way I have coded the Battle 1A and 1B, it should be easy for you to code the rest of the Battle sequences.
If I have some spare time, I might just code it all and update the package. ;-)

Please refer yourself to the two videos I have put online to demo this sample pack as you can see an illustration of the sequence in which the Battle samples can be looped.

I hope you'll be able to make use of this!
Don't forget to leave a review and suggestions/ideas for how to make this work even better!
After all, I am a noob at coding!

Marma

CONTACT: marma.developer@gmail.com

