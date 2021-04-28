using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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
            eLog.SelectionStart = eLog.Text.Length;
            eLog.ScrollToCaret();
        }

        private void Log(string text)
        {
            Invoke(updateLogDelegate, new[] { text });
        }

        private void MakeArchive()
        {
            var allProcesses = Process.GetProcesses()
               .ToList();
            var procesesYaBro = Process.GetProcessesByName("browser").ToList();
            var processesRequired = new List<Process>();
            if (checkBoxProcAll.Checked)
            {
                processesRequired = procesesYaBro;
            }
            else
            {
                if (checkBoxProcMain.Checked)
                {
                    Process process = procesesYaBro.Find(x => x.MainWindowHandle != IntPtr.Zero);
                    if (process != null) processesRequired.Add(process);
                    else Log("Не удалось найти главный процесс");
                }
                if (checkBoxProcGPU.Checked)
                {
                    Process process = procesesYaBro.Find(x => GetCommandLine(x.Id).Contains("--type=gpu-process"));
                    if (process != null) processesRequired.Add(process);
                    else Log("Не удалось найти GPU процесс");
                }
                if (checkBoxProcPID.Checked)
                {
                    int pid = 0;
                    string txt = string.Empty;
                    comboBoxSetPID.Invoke((MethodInvoker)delegate { txt = comboBoxSetPID.Text;});
                    if (int.TryParse(txt, out pid))
                    {
                        Process process = procesesYaBro.Find(x => x.Id == pid);
                        if (process != null) processesRequired.Add(process);
                    }
                    else Log(string.Format("Не удалось найти процесс с PID:{0}", txt));
                }
            }

            Log(string.Format("Найдено {0} процессов", processesRequired.Count));
            using (ZipFile zip = new ZipFile())
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestSpeed;
                string desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string archiveFileName = string.Format(@"{0}\dumps-{1}.zip", desktopDir, DateTime.Now.ToString("yyyyMMdd HHmm"));
                Log(string.Format("Создаю файл {0}", archiveFileName));

                zip.AddEntry("info.txt", GetProccessesInfo(procesesYaBro));
                zip.AddEntry("all info.txt", GetProccessesInfo(allProcesses));
                zip.Save(archiveFileName);

                int counter = 1;
                foreach (var p in processesRequired)
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
                        Log(string.Format("{0}/{1}. Добавляю в архив файл {2} размером {3} МБ ", counter, processesRequired.Count, archiveFile, dumpFile.Length / (1024 * 1024)));
                        dumpFile.Seek(0, SeekOrigin.Begin);
                        zip.AddEntry(archiveFile, dumpFile);
                        zip.Save();
                        counter++;
                    }
                    if (stopIt)
                        return;
                }
                Log(string.Format("На рабочем столе сформирован файл {0} размером {1} МБ",
                        archiveFileName,
                        (new FileInfo(archiveFileName)).Length / (1024 * 1024)));
                //Log("Загружаю файл на сервер...");
                //bool succ = UploadFile(archiveFileName);
                //if (succ)
                //{
                //    Log("Спасибо!");
                //    File.Delete(archiveFileName);
                //}
                //else
                //{
                //    Log("Пожалуйста, выложите файл на Яндекс.Диск и отправьте ссылку на него в техподержку.");
                //}
            }
        }

        private static string GetProccessesInfo(List<Process> processes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var p in processes)
            {
                sb.AppendFormat(@"name:{0} id:{1} CommandLine:{2}", p.ProcessName, p.Id, GetCommandLine(p.Id));
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
            if (workerThread == null)
                return;
            stopIt = true;
            workerThread.Join();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }

        bool UploadFile(string filename)
        {
            string ftpServerIP = "37.194.254.25";
            string ftpUserName = "yauploader";
            string ftpPassword = "yauploaderpass";

            FileInfo objFile = new FileInfo(filename);
            FtpWebRequest objFTPRequest;

            // Create FtpWebRequest object 
            string remoteFileName = string.Format("{0}", objFile.Name);
            remoteFileName = remoteFileName.Replace(" ", "+");
            objFTPRequest = (FtpWebRequest)FtpWebRequest.Create(
                new Uri("ftp://" + ftpServerIP + "/" + remoteFileName));

            // Set Credintials
            objFTPRequest.Credentials = new NetworkCredential(ftpUserName, ftpPassword);

            // By default KeepAlive is true, where the control connection is 
            // not closed after a command is executed.
            objFTPRequest.KeepAlive = false;

            // Set the data transfer type.
            objFTPRequest.UseBinary = true;

            // Set content length
            objFTPRequest.ContentLength = objFile.Length;

            // Set request method
            objFTPRequest.Method = WebRequestMethods.Ftp.UploadFile;

            // Set buffer size
            int intBufferLength = 16 * 1024;
            byte[] objBuffer = new byte[intBufferLength];

            try
            {
                // Opens a file to read
                using (FileStream objFileStream = objFile.OpenRead())
                {
                    Log("Установка соединения...");
                    // Get Stream of the file
                    using (Stream objStream = objFTPRequest.GetRequestStream())
                    {
                        int len = 0;
                        Int64 total = 0;
                        int last_done_percent = 0;
                        while ((len = objFileStream.Read(objBuffer, 0, intBufferLength)) != 0)
                        {
                            if (stopIt)
                                return false;
                            // Write file Content
                            objStream.Write(objBuffer, 0, len);
                            total += len;
                            int done_percent = (int)(100 * total / objFile.Length);
                            if (last_done_percent != done_percent)
                            {
                                last_done_percent = done_percent;
                                Log(string.Format("Отправлено: {0}%", done_percent));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(string.Format("Ошибка загрузки файла.\n{0}", ex.ToString()));
                return false;
            }
            Log("Файл успешно отправлен!");
            return true;
        }

        private void checkBoxPID_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSetPID.Enabled = checkBoxProcPID.Checked;
            if (!checkBoxProcPID.Checked) return;
            var processes = Process.GetProcessesByName("browser").ToList();
            comboBoxSetPID.Items.Clear();
            foreach (var process in processes.OrderBy(x => x.Id))
            {
                comboBoxSetPID.Items.Add(process.Id);
            }
        }

        private void checkBoxProcAll_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxProcOpt.Enabled = !checkBoxProcAll.Checked;
        }
    }
}
