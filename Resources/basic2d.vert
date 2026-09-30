#version 330 core

layout (location = 0) in vec3 aPos;
layout (location = 1) in vec2 aColor;

uniform mat4 uProjection;
uniform mat4 uView;

out vec4 vColor;

void main()
{
	gl_Position = uProjection * uView * vec4(aPos, 1.0);
	vColor = vec4(aColor, 0.0, 1.0);
}
