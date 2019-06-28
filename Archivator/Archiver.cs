using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivator
{
    class Archiver
    {

        DelegateSetError SetError;
        string archiverFileName;

        public Archiver(DelegateSetError SetError)
        {
            this.SetError = SetError;
        }

        public bool Create(string fileName)
        {
            SetError("");
            try
            {
                archiverFileName = fileName;
                using (FileStream file = new FileStream(fileName, FileMode.Create))
                // using releases resources after, CreateNew checks if file exists, throws ex
                {
                    ;
                }
                return true;
            }
            catch (Exception ex) //if fails
            {
                SetError(ex.Message);
                    return false;
            }
        }

        public bool Open(string fileName)
        {
            SetError("");
            try
            {
                archiverFileName = fileName;
                return true;
            }
            catch (Exception ex) //if fails
            {
                SetError(ex.Message);
                return false;
            }
        }

        public bool AddFile(string addFileName)
        {
            SetError(""); //clear field
            try
            {
                string fileNameOnly = Path.GetFileName(addFileName); //get file name
                using (FileStream archiveFile = new FileStream(archiverFileName,
                    FileMode.Append)) //new stream, cursor at the end of file with Append
                {
                    using (BinaryWriter archiveFileBin = new BinaryWriter(archiveFile))//create binary file
                    {
                        byte[] addFileNameBytes = Encoding.UTF8.GetBytes(fileNameOnly);//convert file to byte[]
                        WriteLength(archiveFileBin, addFileNameBytes.Length);//writes filename in bytes
                        archiveFileBin.Write(addFileNameBytes);//write binary file data.


                        byte[] addFileBytes = File.ReadAllBytes(addFileName);//file inhold to binary
                        WriteLength(archiveFileBin, addFileBytes.Length);//add binary inhold to archive
                        archiveFileBin.Write(addFileBytes);
                        // now in archive binary data for filename and file inhold
                    }
                }
                    return true;
            }
            catch (Exception ex) //if fails
            {
                SetError(ex.Message);
                return false;
            }
        }

        public bool ExtractFiles(string path)
        {
            SetError("");
            try
            {
                if (!path.EndsWith("\\"))
                    path = path + "\\";
                using (FileStream archiveFile = new FileStream(archiverFileName, FileMode.Open))
                {
                    using (BinaryReader archiveFileBin = new BinaryReader(archiveFile))//read binary file
                    {
                        while (archiveFile.Position != archiveFile.Length)
                        {
                            int length = ReadLength(archiveFileBin);
                            byte[] fileNameBytes = archiveFileBin.ReadBytes(length);
                            string fileName = Encoding.UTF8.GetString(fileNameBytes);

                            length = ReadLength(archiveFileBin);//skip on file inhold length
                            using (FileStream extFile = new FileStream(path + fileName, FileMode.Create))
                            {
                                using (BinaryWriter extFileBin = new BinaryWriter(extFile))
                                {
                                    extFileBin.Write(archiveFileBin.ReadBytes(length));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) //if fails
            {
                SetError(ex.Message);
                return false;
            }
            return false;
        }

        public List<string> GetNames() //return list of files
        {
            List <string> list = new List<string>();
            list.Clear();

            SetError("");
            try
            {
                using (FileStream archiveFile = new FileStream(archiverFileName, FileMode.Open))
                {
                    using (BinaryReader archiveFileBin = new BinaryReader(archiveFile))//read binary file
                    {
                        while (archiveFile.Position != archiveFile.Length)
                        {
                            int length = ReadLength(archiveFileBin);
                            byte[] fileNameBytes = archiveFileBin.ReadBytes(length);
                            string fileName = Encoding.UTF8.GetString(fileNameBytes);
                            list.Add(fileName);

                            length = ReadLength(archiveFileBin);//skip on file inhold length
                            archiveFile.Seek(length, SeekOrigin.Current);
                        }
                    }
                }
                return list;
            }
            catch (Exception ex) //if fails
            {
                SetError(ex.Message);
                return list;
            }
        }

        private void WriteLength(BinaryWriter writer, int length)
        {
            writer.Write(BitConverter.GetBytes(length));//convet to bytes
        }

        private int ReadLength(BinaryReader reader)
        {
            byte[] lengthBytes = reader.ReadBytes(4); //4 bytes are file name stored
            return BitConverter.ToInt32(lengthBytes,0);
        }

    }
}
