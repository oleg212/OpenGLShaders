using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace OpenGLShaders
{
    public class Scene
    {
        public static readonly int DEFAULT = 1;
        public static readonly int LIGHT = 2;
        public static readonly int GLASS = 3;

        public static void InitializeCamera(Shaders shaders, Camera camera)
        {
            shaders.Uniform3("uCamera.position", camera.position[0], camera.position[1], camera.position[2]);
            shaders.Uniform3("uCamera.view", camera.view[0], camera.view[1], camera.view[2]);
            shaders.Uniform3("uCamera.up", camera.up[0], camera.up[1], camera.up[2]);
            shaders.Uniform3("uCamera.right", camera.right[0], camera.right[1], camera.right[2]);
            shaders.Uniform2("uCamera.scale", camera.scale[0], camera.scale[1]);
        }
        public static void InitializeScene(Shaders shaders)
        {
            // TRIANGLES (clockwise order of vectors!!!)
            shaders.Uniform1("triangles_used", 12);

            // left wall: triangles 0, 1
            shaders.Uniform3("triangles[0].v1", -5.0f, -5.0f, -5.0f);
            shaders.Uniform3("triangles[0].v2", -5.0f, 5.0f, -5.0f);
            shaders.Uniform3("triangles[0].v3", -5.0f, 5.0f, 5.0f);
            shaders.Uniform1("triangles[0].MaterialId", 1);

            shaders.Uniform3("triangles[1].v1", -5.0f, -5.0f, -5.0f);
            shaders.Uniform3("triangles[1].v2", -5.0f, 5.0f, 5.0f);
            shaders.Uniform3("triangles[1].v3", -5.0f, -5.0f, 5.0f);
            shaders.Uniform1("triangles[1].MaterialId", 1);

            // right wall: triangles 2, 3
            shaders.Uniform3("triangles[2].v1", 5.0f, -5.0f, 5.0f);
            shaders.Uniform3("triangles[2].v2", 5.0f, 5.0f, 5.0f);
            shaders.Uniform3("triangles[2].v3", 5.0f, 5.0f, -5.0f);
            shaders.Uniform1("triangles[2].MaterialId", 3);

            shaders.Uniform3("triangles[3].v1", 5.0f, -5.0f, 5.0f);
            shaders.Uniform3("triangles[3].v2", 5.0f, 5.0f, -5.0f);
            shaders.Uniform3("triangles[3].v3", 5.0f, -5.0f, -5.0f);
            shaders.Uniform1("triangles[3].MaterialId", 3);

            // down wall: triangles 4, 5
            shaders.Uniform3("triangles[4].v1", 5.0f, -5.0f, -5.0f);
            shaders.Uniform3("triangles[4].v2", -5.0f, -5.0f, -5.0f);
            shaders.Uniform3("triangles[4].v3", -5.0f, -5.0f, 5.0f);
            shaders.Uniform1("triangles[4].MaterialId", 0);

            shaders.Uniform3("triangles[5].v1", 5.0f, -5.0f, -5.0f);
            shaders.Uniform3("triangles[5].v2", -5.0f, -5.0f, 5.0f);
            shaders.Uniform3("triangles[5].v3", 5.0f, -5.0f, 5.0f);
            shaders.Uniform1("triangles[5].MaterialId", 0);

            // up wall: triangles 6, 7
            shaders.Uniform3("triangles[6].v1", -5.0f, 5.0f, -5.0f);
            shaders.Uniform3("triangles[6].v2", 5.0f, 5.0f, -5.0f);
            shaders.Uniform3("triangles[6].v3", 5.0f, 5.0f, 5.0f);
            shaders.Uniform1("triangles[6].MaterialId", 0);

            shaders.Uniform3("triangles[7].v1", -5.0f, 5.0f, -5.0f);
            shaders.Uniform3("triangles[7].v2", 5.0f, 5.0f, 5.0f);
            shaders.Uniform3("triangles[7].v3", -5.0f, 5.0f, 5.0f);
            shaders.Uniform1("triangles[7].MaterialId", 0);

            // back wall: triangles 8, 9
            shaders.Uniform3("triangles[8].v1", -5.0f, -5.0f, 5.0f);
            shaders.Uniform3("triangles[8].v2", -5.0f, 5.0f, 5.0f);
            shaders.Uniform3("triangles[8].v3", 5.0f, 5.0f, 5.0f);
            shaders.Uniform1("triangles[8].MaterialId", 2);

            shaders.Uniform3("triangles[9].v1", -5.0f, -5.0f, 5.0f);
            shaders.Uniform3("triangles[9].v2", 5.0f, 5.0f, 5.0f);
            shaders.Uniform3("triangles[9].v3", 5.0f, -5.0f, 5.0f);
            shaders.Uniform1("triangles[9].MaterialId", 2);

            // front wall: triangles 10, 11
            shaders.Uniform3("triangles[10].v1", 5.0f, -5.0f, -5.0f);
            shaders.Uniform3("triangles[10].v2", -5.0f, 5.0f, -5.0f);
            shaders.Uniform3("triangles[10].v3", -5.0f, -5.0f, -5.0f);
            shaders.Uniform1("triangles[10].MaterialId", 0);

            shaders.Uniform3("triangles[11].v1", 5.0f, -5.0f, -5.0f);
            shaders.Uniform3("triangles[11].v2", 5.0f, 5.0f, -5.0f);
            shaders.Uniform3("triangles[11].v3", -5.0f, 5.0f, -5.0f);
            shaders.Uniform1("triangles[11].MaterialId", 0);

            // SPHERES
            shaders.Uniform1("spheres_used", 3);

            // big sphere: sphere 0
            shaders.Uniform3("spheres[0].center", -1.0f, -1.0f, -2.0f);
            shaders.Uniform1("spheres[0].radius", 2.0f);
            shaders.Uniform1("spheres[0].MaterialId", 4);

            // small sphere: sphere 1
            shaders.Uniform3("spheres[1].center", 2.0f, 1.0f, 2.0f);
            shaders.Uniform1("spheres[1].radius", 1.0f);
            shaders.Uniform1("spheres[1].MaterialId", 6);

            // light sphere: sphere 2
            shaders.Uniform3("spheres[2].center", 0.0f, 2.0f, -4.0f);
            shaders.Uniform1("spheres[2].radius", 0.2f);
            shaders.Uniform1("spheres[2].MaterialId", 5);
        }

        public static void InitializeLight(Shaders shaders)
        {
            shaders.Uniform3("uLight.position", 0.0f, 2.0f, -4.0f);
        }
    }
}
