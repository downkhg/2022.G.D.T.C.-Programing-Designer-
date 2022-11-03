using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsEnDecryptFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void KeyGen_Click(object sender, EventArgs e)
        {
            label1.Text = CryptFuction.KeyGen();
        }

        private void EecryptFile_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog _encryptOpenFileDialog = new OpenFileDialog())
            {
                if (CryptFuction._rsa is null)
                {
                    MessageBox.Show("Key not set.");
                }
                else
                {
                    //_encryptOpenFileDialog = new OpenFileDialog();
                    // Display a dialog box to select a file to encrypt.
                    _encryptOpenFileDialog.InitialDirectory = CryptFuction.SrcFolder;
                    if (_encryptOpenFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fName = _encryptOpenFileDialog.FileName;
                        if (fName != null)
                        {
                            // Pass the file name without the path.
                            CryptFuction.EncryptFile(new FileInfo(fName));
                        }
                    }
                }
            }

            MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        private void DecryptFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog _decryptOpenFileDialog = new OpenFileDialog())
            {
                if (CryptFuction._rsa is null)
                {
                    MessageBox.Show("Key not set.");
                }
                else
                {
                    // Display a dialog box to select the encrypted file.
                    _decryptOpenFileDialog.InitialDirectory = CryptFuction.EncrFolder;
                    if (_decryptOpenFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fName = _decryptOpenFileDialog.FileName;
                        if (fName != null)
                        {
                            CryptFuction.DecryptFile(new FileInfo(fName));
                        }
                    }
                }
            }
        }
    }
}
