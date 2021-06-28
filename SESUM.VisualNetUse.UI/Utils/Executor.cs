using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SESUM.VisualNetUse.UI.Utils
{
    public static class Executor
    {
        public static void MontarAmbiente(string folderName,string scriptFile)
        {
            string caminhoCompleto = folderName + scriptFile;

            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
                Thread.Sleep(200);
            }

            if (!File.Exists(caminhoCompleto))
            {
                try
                {
                    using (var fluxoDoArquivo = new FileStream(caminhoCompleto, FileMode.Create))
                    {

                        var assembly = Assembly.GetExecutingAssembly();
                        var nomeDoRecurso = @assembly.GetName().Name + ".Recursos." + scriptFile;
                        var streamOrigem = assembly.GetManifestResourceStream(nomeDoRecurso);
                        streamOrigem.Seek(0, SeekOrigin.Begin);
                        streamOrigem.CopyTo(fluxoDoArquivo);
                        fluxoDoArquivo.Flush();
                        Thread.Sleep(3000);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }
        public static bool GetPastaMontada()
        {
            if (Directory.Exists("Z:\\"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static void ExecutaPowerShellScript(string folderName,string scriptFile)
        {
            string caminhoCompleto = folderName +  scriptFile;
           
            try
            {
                using (Process proc = new Process())
                {                                      
                    proc.StartInfo.WorkingDirectory = folderName;
                    proc.StartInfo.FileName = "powershell";
                    proc.StartInfo.Arguments = $"-NoProfile -ExecutionPolicy Bypass -File {scriptFile}";
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.CreateNoWindow = false;
                    proc.Start();
                    proc.WaitForExit();
                   var exitCode = proc.ExitCode;
                   MessageBox.Show("Saida do programa : " + exitCode);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static bool CheckForVPNInterface()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                NetworkInterface[] interfaces =
                    NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface item in interfaces)
                {
                    if (item.Description.Contains("Fortinet SSL VPN Virtual Ethernet Adapter")
                        && item.OperationalStatus == OperationalStatus.Up)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
