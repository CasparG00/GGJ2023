Shader "Hidden/GradientFilter"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Gradient ("Gradient", 2D) = "white" {}
        _FilterIntensity ("Filter Intensity", Range(0, 1)) = 1
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

            sampler2D _MainTex, _Gradient;
            float _FilterIntensity;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float4 filter = tex2D(_Gradient, i.uv.x);
                col *= lerp(float4(1, 1, 1, 1), filter, _FilterIntensity);
                
                return col;
            }
            ENDCG
        }
    }
}
