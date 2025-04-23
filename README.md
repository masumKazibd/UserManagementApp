# 📋 UserManagementApp

A full-stack web application built with **ASP.NET Core**, **C#**, **SQL Server**, and **Bootstrap**, designed for secure and efficient user management based on clearly defined requirements.

---

## 📌 Tech Stack

- **Backend**: C#, ASP.NET Core  
- **Database**: SQL Server  
- **Frontend**: Razor Pages with Bootstrap  
- **ORM**: Entity Framework Core  

---

## 📸 Features Overview

- **Unique Index on Email**
  - Enforced at the **database level** to ensure email uniqueness without application-side validation.

- **User Authentication**
  - User registration with any non-empty password (email confirmation not required).
  - Blocked users cannot log in.
  - Deleted users can re-register.

- **User Management Panel**
  - **Table Columns**:
    - Selection Checkbox (with Select All/Deselect All)
    - Name
    - Email
    - Last Login Time
    - Status (Active/Blocked)
  - **Sorting by Last Login Time**
  - **Toolbar** actions (no buttons inside table rows):
    - **Block** (text button)
    - **Unblock** (icon)
    - **Delete** (icon)

- **Access Control**
  - Only authenticated, non-blocked users can access the management panel.
  - Blocked or deleted users are redirected to the login page before processing requests.

- **User Experience Enhancements**
  - Adequate error messages
  - Tooltips for UI elements
  - Status messages for successful operations
  - Mobile & desktop responsiveness with Bootstrap  
  - Clean, functional interface with no animations, wallpapers, or per-row buttons

---


### **📬 Feedback & Contributions**
Suggestions, issues, or improvements? Feel free to fork the project, open a pull request, or create an issue!

### **📖 License**
This project is open-source and available under the MIT License.

## ✨ Author

**Md. Masum Kazi**  
[![LinkedIn](https://img.shields.io/badge/-LinkedIn-0A66C2?style=flat&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/masumkazi)
[![GitHub](https://img.shields.io/badge/-GitHub-181717?style=flat&logo=github&logoColor=white)](https://github.com/masumkazibd)
[![Portfolio](https://img.shields.io/badge/-Portfolio-FF5722?style=flat&logo=Firefox&logoColor=white)](https://masumkazi.com)


