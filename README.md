# One Game A Week Jam

## Overview

This submission was made for the **One Game A Week Jam**. The genre was Resource Management, the theme was Unstable Key, the wildcard was a score the player cannot see, and the ingredient was a borrowed object.

After letting my mind go places thinking about how to creatively fulfill the requirements, I ended up doing something Dino-related. Dinosaurs are cool... right?

## Story & Game Loop

The player is trapped in a forested space. You are hungry and need to eat. You search for food, find an egg, eat it - and the T-Rex chases you while you try to escape into Jurassic Park. That's the core game loop.

You play as a Baryonyx. The dinosaur egg acts as the "unstable key" - once taken, something chaotic happens. It's also the borrowed object, since you're essentially stealing it from the T-Rex.

## Resource Management - Roar Inventory

For resource management, I implemented an inventory system around 3 different-sounding roars. Each roar was intended to affect the speed of the AI chasing you. Given only 6 days as a busy college student, I kept it simple: pressing `1`, `2`, or `3` triggers the corresponding AudioSource to play its roar.

I initially wanted a `for` loop iterating through the roar list to produce a random roar, but in the interest of time I assigned each roar to its corresponding input directly. Due to time constraints, the logic that would've slowed down the AI when roaring was never implemented.

## Pickup System — Unstable Key

To simulate the player picking up (eating) the egg, I used `Vector3.distance` — a static method that returns the magnitude between two objects. When the distance between the egg and the player falls within a threshold, the egg is deactivated via `SetActive(false)` and its Transform is moved up on the Y axis, scaled by 2.

This Y-axis transform is critical to the AI system. The egg's Y position acts as the trigger that makes the T-Rex go live.

## AI System — Hidden Score

The T-Rex AI is the hidden score. Rather than a numeric value, the T-Rex's behavior indicates player success and pushes the player into the escape phase.

Once the egg's Y transform is no longer 0, the T-Rex becomes active. Its direction vector is calculated by subtracting the T-Rex's position from the Baryonyx's position and normalizing the result — normalization keeps the direction clean and prevents magnitude from affecting speed. The vector is then scaled by `moveSpeed` (a float) to control speed.

The T-Rex always faces the player using `Quaternion.LookRotation`, however there was an issue: it initially rotated in the completely opposite direction. The fix was multiplying that quaternion by a new `Quaternion.Euler` with a Y value of 90. As a side effect, the AI now moves on a slight curve rather than a perfectly linear path.

## Win Condition

To escape and win, the player must reach the Jurassic Park gate. The same `Vector3.distance` approach used for the egg pickup is applied here — if the player has the egg and is within a set distance from the gate, the game ends.

## Text & Objectives

Text prompts appear at key moments throughout the game to guide the player: at the start ("You are hungry, find food"), when attempting to escape without the egg, and when the egg is picked up. These messages surface only at pivotal moments to keep the experience clean.

## Reflection

I had fun working on this project, these systems and features are very bare bone but hey they work. I plan on adding more and polishing these systems very soon. This project would've had more polish if I didn't try staying so faithful to the requirements. I should've incorporated 1 or 2 of the themes that were required instead of trying to do all 4 given the time I had. Now that I look back I should've focused more on the AI system and objectives rather than trying to juggle creating a simple inventory system. 
