## Emotional Agents in the Shire

Project for the class of Autonomous Agents and Multiagent Systems.

In the project, we implement a parameterisable simulation that allows us to
observe how a struggling group of individuals manage their resources in order to
survive against hunger and the attacks of oppressive beings. By using the Unity
game engine, we are able to bring to life a world where these issues can be
explored, and the data collected for further analysis.

By running simulations and observing our results, we are able to understand that
while good coordination can completely eliminate a threat, it is difficult to
guarantee the survival of every member of a group.

## Introduction

In this project we aim to represent a simulation of a mystical village (“The
Shire”), where intelligent agents reside and interact with each other. These
agents are divided in two factions: the human villagers and the evil orcs, who
attack the villagers.

There is a component of resource-gathering within our simulation, which ties in
with one of the most important elements of the environment: energy saving and
replenishing.

We implemented a BDI architecture for villagers, and followed a simplified
version of the *Ortony, Clore and Collins* model [\[1\]](#ref1), where
perceptions have an effect on an agent’s emotion intensity.

This simulation was implemented in Unity, with the scripting done in C#.

## Scenario

In this project our environment is:

* Inaccessible, the agent is only capable of knowing accurate information about
  things in front of it, not obscured by other objects, in a radius of 30m, with
  an angle of  vision of 180º.
* Dynamic, as the environment updates as the agent is deliberating.
* Continuous, as any amount of actions or percepts can occur.
* Non-episodic, as all actions and perceptions influence the following ones,
  without being able to take a segment of actions independently from the
  previous ones.

The environment in question is a closed arena with resources, characterized by
wells, a village, and obstacles such as rocks and trees.

The resources are scarcely placed around the map, at fixed, unknown points to
the villagers. Spread across the map are also orcs wandering, which are hostile
to the villagers.

The villagers have as goal to gather as many resources for the village as
possible. The villagers also need to defend themselves from the orcs, which will
try to attack them.

Villagers have health which they need to keep to avoid dying. When they are
within the village, they regenerate their health slowly.

## Architectures

World events generate Perceptions, which the villagers process every 2 seconds.
These Perceptions are used to generate an Action, which is how the villager
interacts with the world. These Perceptions are passed to a Decider which can be
dynamically decided before executing the program, with one of the given
architectures.

### BDI Architecture

We follow a traditional implementation of the BDI architecture, in which the
perceptions generate beliefs, beliefs influence desires, desires are filtered
into intentions, and intentions generate plans.

The agent can have beliefs about each agent in the map, about where it is, and
what are its current characteristics in regards to health and resources. Beliefs
also have a components of certainty, which, depending on the kind of belief it
is, might be maintained or decreased with time.

For example, the belief that a resource point exists will always be certain,
while the belief an orc is somewhere will decrease over time as the probability
of it still being there after no longer knowing where it is decreases.

For the plan making, we followed a STRIPS architecture, using our filtered
intention as the final goal of the plan.

### Emotions

The emotion architecture is based upon the BDI architecture, with the addition
of an appraisal stage after getting the new Beliefs, to update the emotions.

Emotions follow a structure of valence and arousal, both mapped from -1 to 1. A
negative valence is associated with negative emotions such as sadness and anger,
and a positive valence is associated with positive emotions such as happiness. A
negative arousal is associated with emotions with low intensity, such as
depression and calmness, and a positive arousal is associated with emotions with
high intensity, such as anger and joy. This follows the idea that affective
experiences are best characterized by arousal and valence [\[2\]](#ref2).

In our implementation we had plans to implement contagion using a base of the
beliefs, in which the emotions of the other villagers would be informed to the
character through perceptions, which it then would keep in beliefs, which would
influence its emotions. Yet, we did not get the chance to implement this goal.

## References

1. <a name="ref1"></a> R. Doherty, The Emotional Contagion Scale: A Measure Of
   Individual Differences, *Journal of Nonverbal Behavior*, Vol. 21, No. 2, 1997
2. <a name="ref2"></a> Russell, J. A., A circumplex model of affect. *Journal of
   Personality and Social Psychology*, pp. 1161–1178, 1980.
