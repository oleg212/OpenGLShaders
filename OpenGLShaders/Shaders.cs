﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace OpenGLShaders
{
    public class Shaders
    {
        private int programID;

        public Shaders(string vertex_filename, string fragment_filename)
        {
            int vertexShader = CreateShader(vertex_filename, ShaderType.VertexShader);
            int fragmentShader = CreateShader(fragment_filename, ShaderType.FragmentShader);

            programID = GL.CreateProgram();
            GL.AttachShader(programID, vertexShader);
            GL.AttachShader(programID, fragmentShader);
            GL.LinkProgram(programID);
            GL.ValidateProgram(programID);

            GL.DetachShader(programID, vertexShader);
            GL.DetachShader(programID, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            GL.GetProgram(programID, GetProgramParameterName.LinkStatus, out int code);
            if (code == 0)
            {
                string infolog = GL.GetProgramInfoLog(programID);
                Console.WriteLine($"Ошибка линковки шейдерной программы\n\n{infolog}");
            }
            else
            {
                Console.WriteLine($"Шейдерная программа успешно слинкована");
            }
        }

        public void ActivateProgram()
        {
            GL.UseProgram(programID);
        }

        public void DeactivateProgram()
        {
            GL.UseProgram(0);
        }

        public void Uniform1(string name, float x)
        {
            int loc = GL.GetUniformLocation(programID, name);
            if (loc == -1)
            {
                Console.WriteLine($"uniform1: name \"{name}\" does not correspond to an active uniform variable");
            }
            GL.Uniform1(loc, x);
        }

        public void Uniform2(string name, float x, float y)
        {
            int loc = GL.GetUniformLocation(programID, name);
            if (loc == -1)
            {
                Console.WriteLine($"uniform2: name \"{name}\" does not correspond to an active uniform variable");
            }
            GL.Uniform2(loc, x, y);
        }

        public void Uniform3(string name, float x, float y, float z)
        {
            int loc = GL.GetUniformLocation(programID, name);
            if (loc == -1)
            {
                Console.WriteLine($"uniform3: name \"{name}\" does not correspond to an active uniform variable");
            }
            GL.Uniform3(loc, x, y, z);
        }

        private static int CreateShader(string filename, ShaderType type)
        {
            int shaderID = GL.CreateShader(type);
            using (StreamReader sr = new StreamReader(filename))
            {
                GL.ShaderSource(shaderID, sr.ReadToEnd());
            }
            GL.CompileShader(shaderID);

            GL.GetShader(shaderID, ShaderParameter.CompileStatus, out int code);
            if (code == 0)
            {
                string infolog = GL.GetShaderInfoLog(shaderID);
                Console.WriteLine($"Ошибка компиляции шейдера {filename}\n\n{infolog}");
                GL.DeleteShader(shaderID);
                return 0;
            }
            else
            {
                Console.WriteLine($"Шейдер {filename} успешно скомпилирован");
            }

            return shaderID;
        }

        // Dispose

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                GL.DeleteProgram(programID);

                disposedValue = true;
            }
        }

        ~Shaders()
        {
            if (disposedValue == false)
            {
                Console.WriteLine("GPU Resource leak! Did you forget to call Dispose()?");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

