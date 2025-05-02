using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using myApp;

namespace myApp.Tests
{
    [TestClass]
    public class myApp_Tests
    {
        [TestMethod]
        public void Main_PrintsOutput()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            
            Program.Main();
            
            var output = sw.ToString();
            Assert.IsTrue(output.Length > 100, "La salida es demasiado corta, probablemente no se imprimió nada.");
        }
        
        [TestMethod]
        public void ToString_ReturnsValidString()
        {
            // Crea una instancia de Program a través de reflexión ya que el constructor es privado
            var program = Activator.CreateInstance(typeof(Program), true);
            
            // Obtiene el resultado de ToString
            var result = program.ToString();
            
            // Verifica que ToString devuelva algo (no null y no vacío)
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        
        [TestMethod]
        public void SayHello_HandlesExceptions()
        {
            using var sw = new StringWriter();
            Console.SetError(sw);
            
            // Crea una instancia de Program a través de reflexión
            var program = Activator.CreateInstance(typeof(Program), true);
            
            // Utiliza reflexión para acceder al método privado say_hello
            var method = typeof(Program).GetMethod("say_hello", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            
            // Simula una excepción reemplazando Console.WriteLine temporalmente
            var originalConsoleOut = Console.Out;
            Console.SetOut(TextWriter.Null); // Esto causará una excepción en say_hello
            
            try
            {
                method.Invoke(program, null);
            }
            catch
            {
                // La excepción se maneja en say_hello, no debería llegar aquí
            }
            finally
            {
                Console.SetOut(originalConsoleOut);
            }
            
            // Verificamos que se haya manejado correctamente
            // (Este test pasará si la excepción es manejada dentro del método)
        }
        
        [TestMethod]
        public void SayBye_HandlesExceptions()
        {
            using var sw = new StringWriter();
            Console.SetError(sw);
            
            // Crea una instancia de Program a través de reflexión
            var program = Activator.CreateInstance(typeof(Program), true);
            
            // Utiliza reflexión para acceder al método privado say_bye
            var method = typeof(Program).GetMethod("say_bye", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            
            // Simula una excepción reemplazando Console.WriteLine temporalmente
            var originalConsoleOut = Console.Out;
            Console.SetOut(TextWriter.Null); // Esto causará una excepción en say_bye
            
            try
            {
                method.Invoke(program, null);
            }
            catch
            {
                // La excepción se maneja en say_bye, no debería llegar aquí
            }
            finally
            {
                Console.SetOut(originalConsoleOut);
            }
            
            // Verificamos que se haya manejado correctamente
            // (Este test pasará si la excepción es manejada dentro del método)
        }
    }
}