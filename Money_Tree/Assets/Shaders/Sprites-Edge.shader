// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)
// Based on Unity's Sprites/Default, modified for The-Money-Tree to add an edge glow

Shader "Sprites/Edge"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0

        [PerRendererData] _EdgeGlowColor ("Edge Glow Color", Color) = (1,1,0,1)
        [PerRendererData] _EdgeGlowIntensity ("Edge Glow Intensity (0.0 to 1.0)", Float) = 1.0
        [PerRendererData] _EdgeGlowTrigger ("Edge Glow Trigger Value (0.0 to sqrt(0.5))", Float) = 0.2
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        Pass
        {
        CGPROGRAM

            #pragma vertex SpriteVert
            #pragma fragment EdgeSpriteFrag
            #pragma target 2.0
            #pragma multi_compile_instancing
            #pragma multi_compile _ PIXELSNAP_ON
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            #include "UnitySprites.cginc"


            // Values defined in the Properties section:
            fixed4 _EdgeGlowColor; 
            float _EdgeGlowIntensity;
            float _EdgeGlowTrigger;

            fixed4 EdgeSpriteFrag(v2f IN) : SV_Target
            {
                fixed4 baseColor = SpriteFrag(IN);

                // FIXME: Apply glow selectively based on the distance to the center
                // Does not look too good, UV edges != sprite edges
                //float edgeFac = length(IN.texcoord - float2(0.5, 0.5)); // 0.0 to (sqrt(0.5) ~= 0.71)
                //float glowFac = float(edgeFac > _EdgeGlowTrigger) * _EdgeGlowIntensity;
                //fixed4 glowColor = _EdgeGlowColor * glowFac * baseColor.a;

                // FIXME: Current implementation: apply glow to whole sprite
                fixed4 glowColor = _EdgeGlowColor * _EdgeGlowIntensity * baseColor.a;

                return baseColor + glowColor;
            }
        ENDCG
        }
    }
}
