Shader "Unlit/RendererShader601"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _UTex ("uTexture", 2D) = "white" {}
        _VTex ("vTexture", 2D) = "white" {}
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
            float4 _MainTex_ST;

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
                // sample the texture
                float y_col = tex2D(_MainTex, i.uv) - 0.5;
                float u_col = tex2D(_UTex, i.uv) - 0.5;
                float v_col = tex2D(_VTex, i.uv) - 0.5;

                float4 col;

                // color space 601
                col.r = y_col + 1.140*v_col + 0.5;
                col.g = y_col - 0.395*u_col - 0.581*v_col + 0.5;
                col.b = y_col + 2.032*u_col + 0.5;
                col.a = 1.0;

                return col;
            }
            ENDCG
        }
    }
}
