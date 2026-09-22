Shader "FX/Water" {
Properties {
	_WaveScale ("Wave scale", Range (0.02,0.15)) = 0.063
	_ReflDistort ("Reflection distort", Range (0,1.5)) = 0.44
	_RefrDistort ("Refraction distort", Range (0,1.5)) = 0.4
	_RefrColor ("Refraction color", COLOR) = (.34, .85, .92, 1)
	[NoScaleOffset] _Fresnel ("Fresnel (A) ", 2D) = "gray" {}
	[NoScaleOffset] _BumpMap ("Normalmap ", 2D) = "bump" {}
	WaveSpeed ("Wave speed (map1 x,y; map2 x,y)", Vector) = (19,9,-16,-7)
	[NoScaleOffset] _ReflectiveColor ("Reflective color (RGB) fresnel (A) ", 2D) = "" {}
	_HorizonColor ("Simple water horizon color", COLOR) = (.172, .463, .435, 1)
	[HideInInspector] _ReflectionTex ("Internal Reflection", 2D) = "" {}
	[HideInInspector] _RefractionTex ("Internal Refraction", 2D) = "" {}
}
SubShader {
	Tags { "WaterMode"="Simple" "RenderType"="Opaque" }
	Pass {
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#include "UnityCG.cginc"
		uniform float4 _WaveScale4;
		uniform float4 _WaveOffset;
		struct appdata { float4 vertex : POSITION; };
		struct v2f { float4 pos : SV_POSITION; float2 bumpuv0 : TEXCOORD0; float2 bumpuv1 : TEXCOORD1; float3 viewDir : TEXCOORD2; };
		v2f vert (appdata v)
		{
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			float4 wpos = mul(unity_ObjectToWorld, v.vertex);
			float4 temp = wpos.xzxz * _WaveScale4 + _WaveOffset;
			o.bumpuv0 = temp.xy;
			o.bumpuv1 = temp.wz;
			o.viewDir.xzy = WorldSpaceViewDir(v.vertex);
			return o;
		}
		sampler2D _BumpMap;
		sampler2D _ReflectiveColor;
		float4 _HorizonColor;
		half4 frag (v2f i) : SV_Target
		{
			i.viewDir = normalize(i.viewDir);
			half3 bump1 = UnpackNormal(tex2D(_BumpMap, i.bumpuv0)).rgb;
			half3 bump2 = UnpackNormal(tex2D(_BumpMap, i.bumpuv1)).rgb;
			half3 bump = (bump1 + bump2) * 0.5;
			half fresnel = dot(i.viewDir, bump);
			half4 water = tex2D(_ReflectiveColor, float2(fresnel, fresnel));
			half4 col;
			col.rgb = lerp(water.rgb, _HorizonColor.rgb, water.a);
			col.a = _HorizonColor.a;
			return col;
		}
		ENDCG
	}
}
}
