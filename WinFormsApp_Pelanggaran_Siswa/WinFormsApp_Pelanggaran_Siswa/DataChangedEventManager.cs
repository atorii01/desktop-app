using System;

namespace WinFormsApp_Pelanggaran_Siswa
{
    /// <summary>
    /// Event manager untuk komunikasi antar form
    /// Gunakan pattern Singleton untuk memastikan semua form menggunakan instance yang sama
    /// </summary>
    public sealed class DataChangedEventManager
    {
        private static readonly Lazy<DataChangedEventManager> lazy =
            new Lazy<DataChangedEventManager>(() => new DataChangedEventManager());

        public static DataChangedEventManager Instance => lazy.Value;

        // Event untuk notifikasi perubahan data siswa
        public event EventHandler SiswaDataChanged;

        // Event untuk notifikasi perubahan data pelanggaran
        public event EventHandler PelanggaranDataChanged;

        // Event untuk notifikasi data dihapus semua (setelah ekspor)
        public event EventHandler AllDataCleared;

        private DataChangedEventManager()
        {
            // Private constructor untuk singleton pattern
        }

        /// <summary>
        /// Trigger event ketika data siswa berubah (tambah/edit/hapus)
        /// </summary>
        public void NotifySiswaDataChanged()
        {
            SiswaDataChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Trigger event ketika data pelanggaran berubah (tambah/edit/hapus)
        /// </summary>
        public void NotifyPelanggaranDataChanged()
        {
            PelanggaranDataChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Trigger event ketika semua data dihapus (setelah ekspor)
        /// </summary>
        public void NotifyAllDataCleared()
        {
            System.Diagnostics.Debug.WriteLine($"DataChangedEventManager: NotifyAllDataCleared called. Subscribers: {AllDataCleared?.GetInvocationList().Length ?? 0}");

            if (AllDataCleared != null)
            {
                foreach (var handler in AllDataCleared.GetInvocationList())
                {
                    try
                    {
                        System.Diagnostics.Debug.WriteLine($"  - Invoking handler: {handler.Target?.GetType().Name}");
                        handler.DynamicInvoke(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"  - Error invoking handler: {ex.Message}");
                    }
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("  - WARNING: No subscribers for AllDataCleared event!");
            }
        }

        /// <summary>
        /// Clear semua event subscriber (gunakan saat aplikasi close)
        /// </summary>
        public void ClearAllSubscribers()
        {
            SiswaDataChanged = null;
            PelanggaranDataChanged = null;
            AllDataCleared = null;
        }
    }
}