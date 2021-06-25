Shader "Custom/Shadows"
{
    Properties
    {
        _Color("Color", Color) = (1, 1, 1, 1)
        _MoveAmount("Move Amount", Float) = 0
        _Length("Length", Float) = 1
        _BottomVerticesYOffset("Bottom Vertices Y Offset", Float) = 1.5

    }
    SubShader
    {
        Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 100

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            float _MoveAmount;
            float _Length;
            float _BottomVerticesYOffset;
            float4 _Color;

            v2f vert(appdata v, uint vertexId : SV_VertexID)
            {
                v2f o;

                if (vertexId != 2 && vertexId != 3 && vertexId != 0 && vertexId != 1 && vertexId != 8 && vertexId != 9 && vertexId != 13 && vertexId != 14 && vertexId != 16 && vertexId != 17 && vertexId != 22 && vertexId != 23)
                    o.vertex = UnityObjectToClipPos(float4(v.vertex.x + sin(_MoveAmount) * _Length, (v.vertex.y + _BottomVerticesYOffset) - cos(_MoveAmount) * _Length, 0, 0));
                else
                    o.vertex = UnityObjectToClipPos(float4(v.vertex.x, v.vertex.y, 0, 0));

                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return _Color;
            }
            ENDCG
        }
}
