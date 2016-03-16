using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Management;

namespace Dumper
{
    public partial class FormMain : Form
    {
        private delegate void UpdateLogDelegate(string text);
        private UpdateLogDelegate updateLogDelegate = null;
        Thread workerThread = null;
        bool stopIt = false;

        public object Work { get; private set; }

        public FormMain()
        {
            InitializeComponent();
            this.updateLogDelegate = new UpdateLogDelegate(this.UpdateLog);
            UpdateUI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (workerThread == null)
            {
                stopIt = false;
                workerThread = new Thread(MakeArchive);
                workerThread.Start();
            }
            else
            {
                stopIt = true;
                UpdateLog("Остановка...");
            }
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (workerThread == null)
            {
                btnStart.Text = "Поехали!";
                btnStart.Enabled = true;
            }
            else if (stopIt)
            {
                btnStart.Text = "Оставнавливаем...";
                btnStart.Enabled = false;
            }
            else
            {
                btnStart.Text = "Остановить";
                btnStart.Enabled = true;
            }

            if (workerThread != null && !workerThread.IsAlive)
            {
                UpdateLog("Готово!");
                workerThread = null;
                UpdateUI();
            }
        }

        private void UpdateLog(string text)
        {
            eLog.Text += text + "\r\n";
        }

        private void Log(string text)
        {
            Invoke(updateLogDelegate, new[] { text });
        }

        private void MakeArchive()
        {
            var allProcesses = Process.GetProcesses()
               .ToList();
            var processes = allProcesses
               .Where(a => a.ProcessName == "browser")
               .ToList();

            Log(string.Format("Найдено {0} процессов", processes.Count));

            using (ZipFile zip = new ZipFile())
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestSpeed;
                string desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string archiveFileName = string.Format(@"{0}\dumps-{1}.zip", desktopDir, DateTime.Now.ToString("yyyyMMdd HHmm"));
                Log(string.Format("Создаю файл {0}", archiveFileName));

                zip.AddEntry("info.txt", GetProccessesInfo(processes));
                zip.AddEntry("all info.txt", GetProccessesInfo(allProcesses));
                zip.Save(archiveFileName);

                int counter = 1;
                foreach (var p in processes)
                {

                    string archiveFile = string.Format(@"dump-{0}.dmp", p.Id);
                    string tempDir = Path.GetTempPath();
                    string tempFile = string.Format(@"{0}\dump-{1}.dmp", tempDir, p.Id);
                    
                    using (FileStream dumpFile = File.Create(tempFile, 64 * 1024, FileOptions.DeleteOnClose))
                    {
                        Log(string.Format("Снимаю дамп процесса id={0}", p.Id));
                        DumpWriter.WriteDump(
                            p.Id,
                            dumpFile.SafeFileHandle,
                            Dumper.DumpOptions.WithFullMemory
                            );
                        Log(string.Format("{0}/{1}. Добавляю в архив файл {2} размером {3} МБ ", counter, processes.Count, archiveFile, dumpFile.Length / (1024 * 1024)));
                        dumpFile.Seek(0, SeekOrigin.Begin);
                        zip.AddEntry(archiveFile, dumpFile);
                        zip.Save();
                        counter++;
                    }
                    if (stopIt)
                        return;
                }
                Log(string.Format("На рабочем столе сформирован файл {0} размером {1}",
                        archiveFileName,
                        (new FileInfo(archiveFileName)).Length / (1024 * 1024)));
                
            }
        }

        private static string GetProccessesInfo(List<Process> processes)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var p in processes)
            {
                sb.AppendFormat(@"{0} {1}", p.Id, GetCommandLine(p.Id));
                sb.AppendLine();
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private static string GetCommandLine(int processId)
        {
            var commandLine = new StringBuilder();
            using (var searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + processId))
            {
                foreach (var @object in searcher.Get())
                {
                    commandLine.Append(@object["CommandLine"] + " ");
                }
            }
            return commandLine.ToString();
        }



        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
