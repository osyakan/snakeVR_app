Shader "Hidden/ThermalVision"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "black" {}
	}

	SubShader
	{
		// Tags { "RenderType"="Temperature" }
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			//#include "UnityCG.cginc"

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

			float Luminance(float3 color)
			{
				return dot(color, float3(0.299f, 0.587f, 0.114f));
			}

			sampler2D _MainTex;
            sampler2D _ReferencePalette;

			// float4 frag (v2f i) : SV_Target
			half4 frag (v2f i) : SV_Target
			{
				half4 temperature = tex2D(_MainTex, i.uv);
				half4 result = tex2D(_ReferencePalette, float2(temperature.x, 0.5));
				return result;
			}
			ENDCG
		}
	}

	// SubShader
	// {
	// 	// Tags { "RenderType"="Temperature" }
	// 	// No culling or depth
	// 	Cull Off ZWrite Off ZTest Always

	// 	Pass
	// 	{
	// 		CGPROGRAM
	// 		#pragma vertex vert
	// 		#pragma fragment frag

	// 		//#include "UnityCG.cginc"

	// 		struct appdata
	// 		{
	// 			float4 vertex : POSITION;
	// 			float2 uv : TEXCOORD0;
	// 		};

	// 		struct v2f
	// 		{
	// 			float2 uv : TEXCOORD0;
	// 			float4 vertex : SV_POSITION;
	// 		};

	// 		v2f vert (appdata v)
	// 		{
	// 			v2f o;
	// 			o.vertex = UnityObjectToClipPos(v.vertex);
	// 			o.uv = v.uv;
	// 			return o;
	// 		}

	// 		float Luminance(float3 color)
	// 		{
	// 			return dot(color, float3(0.299f, 0.587f, 0.114f));
	// 		}

	// 		sampler2D _MainTex;
    //         sampler2D _ReferencePalette;
	// 		float _EnvironmentTemperature;

	// 		// float4 frag (v2f i) : SV_Target
	// 		half4 frag (v2f i) : SV_Target
	// 		{
	// 			// half4 temperature = tex2D(_MainTex, i.uv);
	// 			// half4 result = tex2D(_ReferencePalette, float2(temperature.x, 0.5));
	// 			half4 result = tex2D(_ReferencePalette, float2(_EnvironmentTemperature, 0.5));
	// 			return result;
	// 		}
	// 		ENDCG
	// 	}
	// }
    FallBack off // 何もしない 
}
