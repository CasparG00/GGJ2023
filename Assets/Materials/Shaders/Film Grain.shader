Shader "Hidden/Film Grain"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _GrainSteps ("Grain Steps", float) = 1
        _GrainStrength ("Grain Strength", range(0, 1)) = 0.1 
    }
    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _GrainSteps;
            float _GrainStrength;

            float2 posterize(float2 input, float4 steps)
            {
                return floor(input / (1 / steps)) * (1 / steps);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                
                float2 uv = posterize(i.uv, _GrainSteps) + _Time * 0.1;
                float noise = frac(sin(dot(uv, float2(12.9898,78.233) * 2)) * 43758.5453);
                
                return col - noise * _GrainStrength;
            }
            ENDCG
        }
    }
}
