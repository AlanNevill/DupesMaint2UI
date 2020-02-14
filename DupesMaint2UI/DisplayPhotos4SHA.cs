using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Collections.Generic;

namespace DupesMaint2UI
{
    public partial class DisplayPhotos4SHA : Form
    {
        private static readonly StreamWriter _writer = File.AppendText(@"./logfile.txt");

        private ICollection<CheckSumDate> CheckSumDates { get; set; }

        private CheckSumDate CheckSumDate { get; set; }

        private ICollection<CheckSum> CheckSums { get; set; }
        private CheckSum Photo1 { get; set; }
        private CheckSum Photo2 { get; set; }


        public DisplayPhotos4SHA()
        {
            this.InitializeComponent();

            // get the CheckSumDate rows
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                string sql = "select CreateDateTime, count(*) as DupesCount from dbo.CheckSum where CreateDateTime > '1753-01-01' group by CreateDateTime having count(*) > 1";

                this.CheckSumDates = cnn.Query<CheckSumDate>(sql).ToList();
            }


            _writer.AutoFlush = true;

            string mess = $"\r\n{DateTime.Now} - INFO - {this.CheckSumDates.LongCount()} CheckSumDates rows with CreateDateTime count > 1.";
            Log(mess);

            if (this.CheckSumDates.LongCount() < 2)
            {
                mess = $"\r\n{DateTime.Now} - ERROR - Only {this.CheckSumDates.LongCount()} CheckSumDates rows with CreateDateTime count > 1.";
                Log(mess);
                MessageBox.Show(mess);
                this.Close();
            }

            this.DisplayPhotos4DateTime();
        }


        // constructor called by form SelectbySHA passing in the SHA string of the selected duplicates
        public void DisplayPhotos4DateTime()
        {
            this.toolStripStatusLabel.Text = $"INFO - {this.CheckSumDates.Count()} CheckSumDates rows with CreateDateTime count > 1.";

            // get the first date from the collection
            this.CheckSumDate = this.CheckSumDates.First();

            string mess = $"There are {this.CheckSumDate.DupesCount} photos for the CreatetionDate: {this.CheckSumDate.CreateDateTime.ToString("yyyy-MM-dd HH:mm:ss")}";
            Log(mess);
            this.toolStripStatusLabel.Text = mess;

            // get a collection of the CheckSum rows for this CreationDate
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                string sql = $"select * from CheckSum where CreateDateTime = '{this.CheckSumDate.CreateDateTime.ToString("yyyy-MM-dd HH:mm:ss")}' order by Id";

                this.CheckSums = cnn.Query<CheckSum>(sql).ToList();
            }

            // check for count errors
            if (this.CheckSumDate.DupesCount != this.CheckSums.Count)
            {
                mess = $"his.CheckSumDate.Count {this.CheckSumDate.DupesCount} != this.CheckSums.Count {this.CheckSums.Count}";
                Log(mess);
                MessageBox.Show(mess);
                this.Close();
            }

            // get the first photo
            this.Photo1 = this.CheckSums.First();

            // get the last photo
            this.Photo2 = this.CheckSums.Last();

            if (this.Photo2 == null)
            {
                this.toolStripStatusLabel.Text = $"WARN - Photo1 with DateTime: {this.Photo1.SCreateDateTime} cannot find any other photos.";
                return;
            }

            // Note the escape character used (@) when specifying the path. 
            try
            {
                using (MemoryStream stream1 = new MemoryStream(File.ReadAllBytes(this.@Photo1.FullName())))
                {
                    this.pictureBox1.Image = Image.FromStream(stream1);
                    stream1.Dispose();
                }
                using (MemoryStream stream2 = new MemoryStream(File.ReadAllBytes(this.@Photo2.FullName())))
                {
                    this.pictureBox2.Image = Image.FromStream(stream2);
                    stream2.Dispose();
                }

            }
            catch (Exception e)
            {
                mess = $"{DateTime.Now} - ERROR\n\r{e.ToString()}";
                Log(mess);
                MessageBox.Show(mess);
                this.Close();
            }

            this.tbPhoto1.Text = this.Photo1.FullName();
            this.tbPhoto2.Text = this.Photo2.FullName();
            this.tbPhoto1Size.Text = this.Photo1.FileSize.ToString("N0");
            this.tbPhoto2Size.Text = this.Photo2.FileSize.ToString("N0");


            this.dateTimePhoto1.Format = DateTimePickerFormat.Custom;
            this.dateTimePhoto2.Format = DateTimePickerFormat.Custom;
            this.dateTimePhoto1.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.dateTimePhoto2.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.dateTimePhoto1.Value = this.Photo1.CreateDateTime;
            this.dateTimePhoto2.Value = this.Photo2.CreateDateTime;

            this.cbPhoto1.Text = $"Move photo1 with Id {this.Photo1.Id.ToString()}";
            this.cbPhoto2.Text = $"Move photo2 with Id {this.Photo2.Id.ToString()}";
        }



        private void cbPhoto1_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.cbPhoto1.Checked)
            {
                return;
            }

            // move Photo1 in file system from OneDrive Photos folder to target root folder
            if (!this.PhotoMove(this.Photo1))
            {
                this.toolStripStatusLabel.Text = $"ERROR - Photo1.id {this.Photo1.Id} was not moved.";
                return;
            }

            // if move succeeds then write a new DupesAction row for Photo1
            this.DupesAction_Insert(this.Photo1, this.Photo2.FullName());

            // delete Photo1 and Photo2 from the CheckSum table and CheckSums collection
            this.Db_Delete(this.Photo1, this.Photo2);

            // reset the photo 1 check box
            this.cbPhoto1.Checked = false;

            // refresh the display
            DisplayPhotos4DateTime();

        }

        private void cbPhoto2_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.cbPhoto2.Checked)
            {
                return;
            }

            // move Photo2 in file system from OneDrive Photos folder to target root folder
            if (!this.PhotoMove(this.Photo2))
            {
                this.toolStripStatusLabel.Text = $"ERROR - Photo2.id {this.Photo2.Id} was not moved.";
                return;
            }

            // if move succeeds then write a new DupesAction row for Photo1
            this.DupesAction_Insert(this.Photo2, this.Photo1.FullName());

            // delete Photo1 and Photo2 from the CheckSum table and CheckSums collection
            this.Db_Delete(this.Photo1, this.Photo2);

            // reset the photo2 check box
            this.cbPhoto2.Checked = false;

            // refresh the display
            DisplayPhotos4DateTime();
        }


        // write new row into the DupesAction table
        private void DupesAction_Insert(CheckSum photo, string duplicateOf)
        {
            // set up the parameters for the stored procedure
            var p = new DynamicParameters();
			p.Add("@TheFileName", photo.FullName());
			p.Add("@DuplicateOf", duplicateOf);
			p.Add("@SHA", $"Photos with the same EXIF DateTime: {photo.SCreateDateTime}");
			p.Add("@FileExt", photo.FileExt);
			p.Add("@FileSize", photo.FileSize);
			p.Add("@FileCreateDt", photo.CreateDateTime);
			p.Add("@OneDriveRemoved", "Y");
			p.Add("@GooglePhotosRemoved", "N");

            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Execute("dbo.spDupesAction_ins", p, commandType: CommandType.StoredProcedure);
            }
        }


        // Move the file specified in CheckSum photo to a new directory
        private bool PhotoMove(CheckSum photo)
        {
            // check if target folder exists, if not create it
            string targetPath = TargetFolderCheck(photo);

            // now move the file from source folder to target folder
            return PhotoMove(photo, targetPath);
        }


        private static string TargetFolderCheck(CheckSum photo)
        {
            string targetFolder = Program.targetRootFolder;
            DirectoryInfo rootFolder = new DirectoryInfo(Program.targetRootFolder);

            // make sure the targetRootFolder exists
            if (!rootFolder.Exists)
            {
                rootFolder.Create();
            }

            // construct the targetFolder for this CheckSum photo
            targetFolder += @photo.Folder.Substring(2);

            // if target folder does not exist then create it
            DirectoryInfo diTarget = new DirectoryInfo(targetFolder);
            if (!diTarget.Exists)
            {
                diTarget.Create();
            }

            return targetFolder;
        }


        // Physically move the file from its source location to the target folder
        private static bool PhotoMove(CheckSum photo, string targetPath)
        {
            // construct the destPath including the file name
            string[] sourceFolderParts = photo.TheFileName.Split('\\');
            string fileName = sourceFolderParts[sourceFolderParts.Length - 1];
            string destPath = targetPath + "\\" + fileName;

            // instaniate a FileInfo object for the source file
            FileInfo sourcePath = new FileInfo(photo.FullName());
            try
            {
                // move the file from sourcePath to destPath
                sourcePath.MoveTo(destPath);

                string mess = $"{DateTime.Now} - INFO - File {photo.TheFileName} was moved to {destPath}.";
                Log(mess);

                return true;
            }
            catch (Exception Ex)
            {
                string mess = $"{DateTime.Now} - ERROR - File {photo.TheFileName} was NOT moved.\r\n{Ex.ToString()}";
                Log(mess);

                return false;
            }
        }


        // delete the CheckSum row that was moved so that CheckSum still reflects the folder scan, and remove the 2 CheckSumDups rows as the duplicate has been removed
        private void Db_Delete(CheckSum photo1, CheckSum photo2)
        {
            // remove the 2 rows from the CheckSum table
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                string sql = $"delete from CheckSum where Id in ({photo1.Id},{photo2.Id})";
                cnn.Execute(sql, commandType: CommandType.Text);
            }

            // remove the CheckSumDate item for the CreationDateTime from the CheckSumDates list
            this.CheckSumDates.Remove(CheckSumDate);
        }


        private void DisplayPhotos4SHA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.pictureBox1.Dispose();
            this.pictureBox2.Dispose();

            GC.Collect();
        }

        public static string GetConnectionString(string name = "Pops")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        private static void Log(string mess)
        {
            _writer.WriteLine(mess);
        }


        // keep both the photos
        private void btnKeep_Click(object sender, EventArgs e)
        {
            string mess = $"{DateTime.Now} - WARN - These photo have the same EXIF Date\\Time: {this.Photo1.SCreateDateTime} but are different so they were kept.\r\n" +
                $"{this.Photo1.FullName()}\r\n{this.Photo2.FullName()}";
            Log(mess);

            // delete Photo1 and Photo2 from the CheckSum table and remove the CreateDateTime from the CheckSumDates collection
            this.Db_Delete(this.Photo1, this.Photo2);

            // refresh the display
            DisplayPhotos4DateTime();
        }
    }
}
