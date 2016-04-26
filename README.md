# 2DMetaballs
A 2D metaballs implementation in Unity.

Based on this tutorial:
http://patomkin.com/2016/04/25/metaball-tutorial/

With the following changes:
- Cutoff shader merged with the blur effect in MetaballEffect.cs. Should be faster and there's no need for a separate RenderTexture quad.
- A hundred squishing and rotating metaballs for your enjoyment. Top-notch screensaver quality.

See the result here:
http://huvaakoodia.github.io/2DMetaballs/
