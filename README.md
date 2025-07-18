# 🎬 CinemaHub

CinemaHub is a powerful WPF application for cinema management. It allows users to browse movies, book seats, make payments, and manage administrative functions seamlessly.

<!-- Replace with real banner or screenshot -->
<img width="512" height="288" alt="The Perks of Being A Wallflower" src="https://github.com/user-attachments/assets/a8838337-1322-4bab-9316-728976067680" />

---

## ✨ Features

- 📝 **User Registration and Login**
- 🎟️ **Seat Booking System**
- 💳 **Integrated Payment Processing**
- 🛠️ **Admin Panel for Movie and Schedule Management**
- 👤 **User Dashboard with Booked Tickets History**
- 🔍 **Modern and Intuitive WPF UI Design**

---

## 🚀 Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 or newer with WPF support

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/nikilodiym/CinemaHub.git
2. Open the solution in Visual Studio/Rider.
3. Restore NuGet packages if prompted.
4. Build and run the project.

---
## 📂 Project Structure
```bash
CinemaHub/
├── CinemaHub.sln
├── CinemaWPF/
│   ├── App.xaml
│   ├── MainWindow.xaml
│   ├── Views/
│   │   ├── Auth/
│   │   │   ├── LoginWindowView.xaml
│   │   │   └── RegisterWindowView.xaml
│   │   ├── Admin/
│   │   │   ├── AdminPanelView.xaml
│   │   │   └── ManageMoviesView.xaml
│   │   ├── User/
│   │   │   ├── UserPanelView.xaml
│   │   │   └── BookTicketsView.xaml
│   │   └── Shared/
│   │       └── HomeView.xaml
│   ├── ViewModels/
│   │   ├── Auth/
│   │   ├── Admin/
│   │   ├── User/
│   │   └── Shared/
│   └── Models/
│       ├── Movie.cs
│       ├── User.cs
│       └── Ticket.cs
└── README.md
```

---
## 🛠️ Technologies Used
- C#
- WPF (Windows Presentation Foundation)
- MVVM Pattern
- XAML UI Design

## 🚧 Known Issues
- Payment gateway integration is currently simulated.
- Admin features are limited to local database only.

## 🌟 Future Plans
- Add movie trailers and reviews.
- Implement real payment processing via Stripe or PayPal API.
- Deploy as a standalone Windows executable installer.
