Shader "Unlit/RendererShader601WithAlpha"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _UTex ("uTexture", 2D) = "white" {}
        _VTex ("vTexture", 2D) = "white" {}
        _ATex ("aTexture", 2D) = "white" {}
        _yStrideScale ("yStride Scale", Float) = 1.0
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        LOD 100
        
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {   
                float4 vertex : SV_POSITION;
                float2 texcoord : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                UNITY_VERTEX_OUTPUT_STEREO
            };

            sampler2D _MainTex;
            sampler2D _UTex;
            sampler2D _VTex;
            sampler2D _ATex;
            float _yStrideScale;
            float4 _MainTex_ST;


            v2f vert (appdata_t v)
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.texcoord * float2(_yStrideScale, 1.0);
                fixed4 color = fixed4(tex2D(_MainTex, uv).r, tex2D(_UTex, uv).r, tex2D(_VTex, uv).r, 1.0);

                float4x4 yuvToRgb = float4x4(
                    1.1643835616, 0, 1.7927410714, -0.9729450750,
                    1.1643835616, -0.2132486143, -0.5329093286, 0.3014826655,
                    1.1643835616, 2.1124017857, 0, -1.1334022179,
                    0, 0, 0, 1);
               
                color = mul(yuvToRgb,color);
                color.a = tex2D(_ATex, i.texcoord).r;
                UNITY_APPLY_FOG(i.fogCoord, col);
                return color;
            }
            ENDCG
        }
    }
}
