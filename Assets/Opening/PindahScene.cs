using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Tambahkan namespace ini untuk IEnumerator

public class PindahScene : MonoBehaviour
{
    public string NamaScene; // Nama scene yang ingin Anda pindah
    private Coroutine pointerTimerCoroutine; // Coroutine untuk timer
    private bool isPointerOver = false; // Status pointer apakah di dalam gambar

    // Fungsi ini dipanggil ketika pointer mengenai collider
    public void OnPointerEnter()
    {
        if (!isPointerOver)
        {
            isPointerOver = true;
            pointerTimerCoroutine = StartCoroutine(PointerTimer()); // Memulai timer selama 3 detik
        }
    }

    // Fungsi ini dipanggil ketika pointer keluar dari collider
    public void OnPointerExit()
    {
        if (isPointerOver)
        {
            isPointerOver = false;
            StopCoroutine(pointerTimerCoroutine); // Menghentikan timer jika pointer keluar sebelum 3 detik
        }
    }

    // Coroutine untuk menghitung waktu selama 3 detik
    private IEnumerator PointerTimer()
    {
        yield return new WaitForSeconds(3); // Menunggu selama 3 detik
        SceneManager.LoadScene(NamaScene); // Pindah ke scene baru setelah 3 detik
    }
}
