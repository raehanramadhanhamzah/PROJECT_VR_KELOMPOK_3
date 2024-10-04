using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowInfo : MonoBehaviour
{
    public Text infoText; // Referensi ke UI Text untuk menampilkan informasi
    public Image infoBackground; // Referensi ke UI Image sebagai latar belakang

    [TextArea(3, 10)] // Menambahkan TextArea agar bisa input multi-baris di Inspector
    public string infoMessage; // Informasi yang akan ditampilkan

    private bool isPointerOver = false; // Status pointer apakah di dalam collider
    private Coroutine hoverCoroutine; // Coroutine untuk timer

    void Start()
    {
        // Menyembunyikan informasi dan background di awal
        infoText.gameObject.SetActive(false);
        infoBackground.gameObject.SetActive(false);
    }

    // Fungsi ini dipanggil ketika pointer mengenai collider
    public void OnPointerEnter()
    {
        if (!isPointerOver)
        {
            isPointerOver = true;
            hoverCoroutine = StartCoroutine(HoverTimer()); // Memulai timer selama 3 detik
        }
    }

    // Fungsi ini dipanggil ketika pointer keluar dari collider
    public void OnPointerExit()
    {
        if (isPointerOver)
        {
            isPointerOver = false;
            if (hoverCoroutine != null)
            {
                StopCoroutine(hoverCoroutine); // Menghentikan timer jika pointer keluar sebelum 3 detik
                hoverCoroutine = null;
            }
            // Menyembunyikan informasi dan background jika pointer keluar
            infoText.gameObject.SetActive(false);
            infoBackground.gameObject.SetActive(false);
        }
    }

    // Coroutine untuk menghitung waktu selama 3 detik
    private IEnumerator HoverTimer()
    {
        yield return new WaitForSeconds(3); // Menunggu selama 3 detik

        // Menampilkan informasi dan background hanya jika pointer tetap berada di objek
        if (isPointerOver)
        {
            infoText.text = infoMessage; // Mengatur teks informasi
            infoText.gameObject.SetActive(true); // Menampilkan teks informasi
            infoBackground.gameObject.SetActive(true); // Menampilkan background
        }
    }
}
