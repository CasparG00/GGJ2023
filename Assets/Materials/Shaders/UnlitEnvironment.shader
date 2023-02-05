Shader "Unlit/UnlitEnvironment"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BackfaceColor ("Backface Color", Color) = (0, 0, 0, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            Cull Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldNormal : NORMAL;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _BackfaceColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag (v2f i, fixed facing : VFACE) : SV_Target
            {
                float3 normal = normalize(i.worldNormal);
                float lightDir = saturate(dot(float3(-1, 0, 0), normal)) * 0.5 + 0.5;

                fixed4 frontCol = tex2D(_MainTex, i.uv) * lightDir;
                fixed4 col = facing > 0 ? frontCol : _BackfaceColor;
                return col;
            }
            ENDCG
        }
    }
}
