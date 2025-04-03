# Doctor Appointment Scheduling and Patient Management System

## 📖 Overview
This project is a comprehensive web-based system designed to streamline doctor appointment scheduling and patient management. The system modernizes an outdated e-channeling portal, significantly improving the user experience for both patients and doctors.

### Key features include:
- 🗓 **Appointment Booking:** Patients can easily book appointments.
- 🩺 **Doctor Search:** Patients can search for doctors based on symptoms.
- 📧 **Appointment Reminders:** Patients receive email reminders for their appointments.
- 👩‍⚕️ **Doctor Dashboard:** Doctors can track patient history, view lab reports, and update the Disease Knowledge Database.

## 🛠 Technologies Used

### Front-End:
- **Bootstrap:** Used for responsive, modern UI design.
- **ASP.NET:** Built with ASP.NET for a powerful and dynamic user experience.

### Back-End:
- **C#:** Core backend programming language used to implement business logic and integrate the database.

### Database:
- **Microsoft SQL Server Management Studio (MSSQL):** Database management and storage for patient data, appointments, doctor details, and lab reports.

## ⚡ Features
- **User Registration & Login:**
  - Patients and doctors can register and log in to access the system.
  
- **Appointment Scheduling:**
  - Patients can search for available doctors based on symptoms and schedule appointments.
  
- **Email Notifications:**
  - Patients are notified via email about their appointments, including reminders.

- **Doctor Dashboard:**
  - Doctors can access patient history, view lab reports, and add to a Disease Knowledge Database.

## 📝 Installation

To run the project locally, follow the steps below:

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Senomi-Jayasinghe/EchannelingSystem.git

2. Set up the database:
  - Install **Microsoft SQL Server Management Studio (MSSQL)** if not already installed.
  - Import the provided `.sql` files to create the necessary tables and relationships.
  - Configure the connection string in `appsettings.json` to point to your local database.

3. Run the application:
  - Open the project in **Visual Studio**.
  - Build the project and run it using IIS Express or any local server setup.

## 🚀 Usage

- **Patients can:**
  - Register an account.
  - Book appointments with doctors based on symptoms.
  - Receive email reminders.

- **Doctors can:**
  - Log in to their dashboard.
  - Track patient history and manage patient data.
  - Access and update the Disease Knowledge Database.

## 🙏 Acknowledgements
- **Bootstrap** for providing an easy-to-use front-end framework.
- **ASP.NET** for backend development.
- **Microsoft SQL Server Management Studio** for database management.
