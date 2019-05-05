﻿using System;
using System.Linq;
using static Gamer.Core.Debug;

namespace Gamer.Estate.Tes.FilePack
{
    partial class BsaFile
    {
        public void TestContainsFile()
        {
            foreach (var file in _files)
            {
                Log($"{file.Path} {file.PathHash}");
                if (!ContainsFile(file.Path))
                    throw new FormatException("Hash Invalid");
                else if (!_filesByHash[HashFilePath(file.Path)].Any(x => x.Path == file.Path))
                    throw new FormatException("Hash Invalid");
            }
        }

        public void TestLoadFileData()
        {
            foreach (var file in _files)
            {
                Log(file.Path);
                LoadFileData(file);
            }
        }
    }
}