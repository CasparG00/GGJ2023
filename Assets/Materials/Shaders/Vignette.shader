Shader "Hidden/Vignette"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Radius("Vignette Radius", Range(0.0, 1.0)) = 1.0
        _Softness("Vignette Softness", Range(0.0, 1.0)) = 0.5
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
            float _Radius;
            float _Softness;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

                float distFromCenter = distance(i.uv, float2(0.5, 0.5));
                float4 vignette = smoothstep(_Radius, _Radius - _Softness, distFromCenter);
                col = saturate(col * vignette);
                
                return col;
            }
            ENDCG
        }
    }
}
