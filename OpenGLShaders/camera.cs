using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace OpenGLShaders
{
    public class Camera
    {
        public Vector3 position;
        public Vector3 view;
        public Vector3 up;
        public Vector3 right;
        public Vector2 scale;
    }
}
