#version 330 core

layout (location = 0) in vec3 aPos;
layout (location = 2) in vec2 aUv;

uniform vec4 uColor;
uniform mat4 uProjection, uView, uModel;

out vec4 vColor;
out vec2 vUv;

void main()
{
	gl_Position = uProjection * uView * uModel * vec4(aPos, 1.0);
	vColor = uColor;
	vUv = aUv;
}