#version 330 core

in vec4 vColor;
in vec2 vUv;

out vec4 FragColor;

uniform sampler2D uTexture;
uniform bool uUseTexture;

void main()
{
    if (uUseTexture)
        FragColor = vColor * texture(uTexture, vUv);
    else
        FragColor = vColor;
}