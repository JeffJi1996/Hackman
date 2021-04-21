Shader "Custom/1_Surface"
{
   //Properties block
    Properties
	{
	    _Color("Color",Color) = (1,1,1,1)
	}
    SubShader
	{
		CGPROGRAM
		#pragma surface surf Lambert

		struct Input
		{
			//Must have AT Least one member
			float2 uv_MainTex;
		};
		//fixed4, half4, float4...etc are called PACKED ARRAYS
		fixed4 _Color;

		void surf(Input IN, inout SurfaceOutput o)
		{
			o.Albedo = _Color.rgb;
		}
		ENDCG
	}

    FallBack "Diffuse"
	
}
