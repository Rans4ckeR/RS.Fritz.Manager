namespace RS.Fritz.Manager.API
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public static class SpecialFolder
    {
        public static string Downloads => _downloads ??= GetDownloads();

        // workaround for missing .net feature SpecialFolder.Downloads
        // - https://stackoverflow.com/a/3795159/227110
        // - https://stackoverflow.com/questions/10667012/getting-downloads-folder-in-c
        private static string GetDownloads()
        {
            if (Environment.OSVersion.Version.Major < 6)
                throw new NotSupportedException();

            var pathPtr = IntPtr.Zero;
            try
            {
                if (SHGetKnownFolderPath(ref _folderDownloads, 0, IntPtr.Zero, out pathPtr) != 0)
                    throw new DirectoryNotFoundException();
                return Marshal.PtrToStringUni(pathPtr);
            }
            finally
            {
                Marshal.FreeCoTaskMem(pathPtr);
            }
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetKnownFolderPath(ref Guid id, int flags, IntPtr token, out IntPtr path);

        private static Guid _folderDownloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");
        private static string _downloads;
    }
}