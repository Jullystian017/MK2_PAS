# 🎮 UH_MK2 — 2D Platformer Game

> **Proyek Unity 2D Platformer** — Dibuat untuk keperluan **PAS (Penilaian Akhir Semester)**

![Unity](https://img.shields.io/badge/Engine-Unity-black?style=for-the-badge&logo=unity)
![C#](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=csharp)
![Platform](https://img.shields.io/badge/Platform-Windows-0078D6?style=for-the-badge&logo=windows)
![Genre](https://img.shields.io/badge/Genre-2D%20Platformer-ff69b4?style=for-the-badge)

---

## 📸 Screenshot

### 🏠 Main Menu
> *Taruh screenshot main menu di sini*

![Main Menu](screenshots/mainmenu.png)

---

### 🌄 Level 1
> *Taruh screenshot level 1 di sini*

![Level 1](screenshots/level1.png)

---

### 🌲 Level 2
> *Taruh screenshot level 2 di sini*

![Level 2](screenshots/level2.png)

---

### 🏔️ Level 3
> *Taruh screenshot level 3 di sini*

![Level 3](screenshots/level3.png)

---

### 💀 Game Over Screen
> *Taruh screenshot game over di sini*

![Game Over](screenshots/gameover.png)

---

### 🏆 Win / Finish Screen
> *Taruh screenshot finish screen di sini*

![Finish](screenshots/finish.png)

---

## 🕹️ Cara Bermain

| Tombol | Aksi |
|--------|------|
| `← →` atau `A D` | Gerak kiri / kanan |
| `Space` | Lompat |

### 📌 Aturan Game
- Injak **kepala musuh** untuk membunuhnya dan mendapat **+20 poin**
- Ambil **koin / gold** untuk mendapat **+10 poin**
- Hindari **spike** dan **musuh** — kena damage mengurangi nyawa ❤️
- Jatuh dari peta → respawn, tapi nyawa berkurang
- Capai **bendera (flag)** di ujung level untuk lanjut ke level berikutnya
- Selesaikan **Level 3** untuk menang! 🏆

---

## ❤️ Sistem Nyawa

Player memiliki **3 nyawa** yang ditampilkan sebagai ikon hati di UI.

```
❤️ ❤️ ❤️  →  Full health (3 nyawa)
❤️ ❤️ 🖤  →  Kena damage (2 nyawa)
❤️ 🖤 🖤  →  Hampir mati (1 nyawa)
🖤 🖤 🖤  →  GAME OVER
```

- Ada **damage cooldown** setelah terkena damage (tidak bisa kena damage spam)
- Kena **spike** atau **musuh dari samping** → kehilangan 1 nyawa

---

## 🗺️ Level

| Level | Nama Scene | Keterangan |
|-------|------------|------------|
| 1 | `level1` | Level awal — pengenalan mekanik dasar |
| 2 | `level2` | Level menengah — lebih banyak musuh & rintangan |
| 3 | `level3` | Level terakhir — selesaikan untuk menang! |
| - | `mainmenu` | Halaman utama dengan pilihan level |

---

## 🎵 Aset yang Digunakan

| Kategori | Nama Aset |
|----------|-----------|
| 🎮 Sprite / Character | Simple 2D Platformer BE2 (Aztech Games) |
| 🎵 Background Music | 8-Bit RPG Adventure Music Pack I — Francesco Fabrizio |
| 🔊 Sound Effects | True 8-bit Sound Effect Collection - Lite |
| 🖼️ GUI / UI | Game GUI Vol1 |
| 🔤 Font | TextMesh Pro |
| 🪙 Coin | Custom Gold Coin Assets |
| 🖼️ Background | Pixel Art Sky & Arcade Scene backgrounds |

---

## 📁 Struktur Project

```
UH_MK2/
├── Assets/
│   ├── Scenes/
│   │   ├── mainmenu.unity       # Main Menu
│   │   ├── level1.unity         # Level 1
│   │   ├── level2.unity         # Level 2
│   │   └── level3.unity         # Level 3
│   ├── Player.cs                # Kontrol player, health, score, collision
│   ├── MainMenu.cs              # Navigasi main menu & level select
│   ├── CoinManager.cs           # Manajemen koin (singleton)
│   ├── CameraFollow.cs          # Kamera mengikuti player
│   ├── background.cs            # Parallax / background logic
│   ├── coin.cs                  # Behaviour koin
│   ├── TestButton.cs            # UI button testing
│   ├── 8-Bit RPG Adventure .../  # Background music pack
│   ├── True 8-bit Sound .../     # Sound effects pack
│   ├── Simple 2D Platformer .../  # Sprite & karakter
│   ├── Game GUI Vol1/            # UI assets
│   └── coin/                     # Aset koin (Gold 0-3)
├── ProjectSettings/
├── Packages/
└── README.md
```

---

## 🧩 Script Utama

### `Player.cs`
Script utama yang mengontrol:
- ✅ Pergerakan kiri/kanan dengan `Rigidbody2D`
- ✅ Sistem lompat (jump) dengan deteksi ground
- ✅ Sistem nyawa (3 HP) dengan UI hati
- ✅ Sistem skor (koin +10, musuh +20)
- ✅ Deteksi collision: koin, spike, musuh, flag
- ✅ Damage cooldown (anti-spam)
- ✅ Respawn saat jatuh dari peta
- ✅ Game Over & Finish panel
- ✅ Efek suara: jump, coin, hurt, enemy dead, finish

### `MainMenu.cs`
- ✅ Buka/tutup panel level select
- ✅ Load scene per level (`level1`, `level2`, `level3`)

### `CameraFollow.cs`
- ✅ Kamera smooth follow mengikuti posisi player

### `CoinManager.cs`
- ✅ Singleton manager untuk tracking coin count
- ✅ Update UI text koin secara real-time

---

## 🛠️ Cara Menjalankan di Unity

1. **Clone repository ini:**
   ```bash
   git clone https://github.com/Jullystian017/MK2_PAS.git
   ```

2. **Buka Unity Hub** dan klik **"Open Project"**

3. **Pilih folder** `UH_MK2`

4. Tunggu Unity **mengimport semua aset** (bisa beberapa menit pertama kali)

5. Buka scene `mainmenu` dari folder `Assets/Scenes/`

6. Klik tombol ▶️ **Play** untuk mulai bermain!

> ⚠️ **Catatan:** Pastikan menggunakan **Unity 2022.3 LTS** atau lebih baru

---

## 👨‍💻 Pembuat

| Info | Detail |
|------|--------|
| 👤 Nama | Jullystian |
| 🏫 Kelas | XI |
| 📚 Mata Pelajaran | MK3 |
| 📝 Tujuan | Penilaian Akhir Semester (PAS) |
| 🔗 GitHub | [@Jullystian017](https://github.com/Jullystian017) |

---

## 📄 Lisensi

Project ini dibuat untuk keperluan akademik. Aset yang digunakan merupakan asset pack dari Unity Asset Store yang berlisensi untuk penggunaan non-komersial.

---

<div align="center">
  <i>Made with ❤️ using Unity Engine</i>
</div>
