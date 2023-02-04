Shader "Unlit/FogOfWar"
{
    Properties
    {
        _Color ("Color", color) = (0, 0, 0, 1)
        _Mask ("Mask", 2D) = "white" {}
        _Opacity ("Opacity", range(0, 1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

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

            sampler2D _Mask;
            float4 _MainTex_ST;
            float4 _Color;

            float _Opacity;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 mask = tex2D(_Mask, i.uv);
                
                return _Color * _Opacity;
            }
            ENDCG
        }
    }
}
