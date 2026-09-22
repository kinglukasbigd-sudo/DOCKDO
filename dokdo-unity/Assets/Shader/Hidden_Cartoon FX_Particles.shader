Shader "Hidden/Cartoon FX/Particles" {
Properties {
	_BaseColor ("Alpha Blended Color", Color) = (0.5,0.5,0.5,0.5)
	_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
	_MainTex ("Particle Texture", 2D) = "white" {}
	_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
}
SubShader {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	Blend SrcAlpha OneMinusSrcAlpha
	ColorMask RGB
	Cull Off Lighting Off ZWrite Off
	Pass {
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#include "UnityCG.cginc"
		sampler2D _MainTex; float4 _MainTex_ST; fixed4 _TintColor; fixed4 _BaseColor;
		struct appdata { float4 vertex : POSITION; fixed4 color : COLOR; float2 uv : TEXCOORD0; };
		struct v2f { float4 pos : SV_POSITION; fixed4 color : COLOR; float2 uv : TEXCOORD0; };
		v2f vert (appdata v) { v2f o; o.pos = UnityObjectToClipPos(v.vertex); o.color = v.color; o.uv = TRANSFORM_TEX(v.uv, _MainTex); return o; }
		fixed4 frag (v2f i) : SV_Target { fixed4 t = tex2D(_MainTex, i.uv); return 2.0 * i.color * _BaseColor * t; }
		ENDCG
	}
}
}
