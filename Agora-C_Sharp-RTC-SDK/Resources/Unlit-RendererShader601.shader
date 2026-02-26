Shader "Unlit/RendererShader601"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _UTex ("uTexture", 2D) = "white" {}
        _VTex ("vTexture", 2D) = "white" {}
        _yStrideScale ("yStride Scale", Float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _UTex;
            sampler2D _VTex;
            float _yStrideScale;
            float4 _MainTex_ST;
            float4x4 _yuv2rgb;


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv * float2(_yStrideScale, 1.0);
                fixed4 color = fixed4(tex2D(_MainTex, uv).r, tex2D(_UTex, uv).r,tex2D(_VTex, uv).r,1.0);
                color = mul(_yuv2rgb,color);
                return color;
            }
            ENDCG
        }
    }
}
