# Student Registration System (LINQ to SQL)

Kani waa nidaam yar oo casri ah oo loo adeegsado diwaangelinta iyo maaraynta xogta ardayda (**Student Registration System**). Mashruucan waxaa lagu dhisay tiknoolajiyadda **C# Windows Forms App (.NET Framework)** iyo **SQL Server**, iyadoo loo adeegsaday habka casriga ah ee **LINQ to SQL (Language Integrated Query)** si loogu maamulo xogta CRUD-ka si hufan, ammaan ah, oo aad u nadiif ah.

---

## 🚀 Features (Waxyaabaha uu Qaban Karo)

* **Read (Load Data):** Wuxuu si otomaatig ah u soo bandhigaa dhammaan ardayda diwaangashan marka barnaamijku kiciyo iyadoo lagu shubayo `DataGridView`.
* **Create (Add Student):** Wuxuu dhaliyaa xog cusub oo arday, isagoo marka hore sameynaya *Validation* (Hubin) si loogu keydiyo SQL Server si nabadgelyo ah.
* **Read Specific (Get Student):** Waxaad ku raadin kartaa arday kasta adoo isticmaalaya *StudentID* iyo habka *Lambda Expressions (`FirstOrDefault`)*.
* **Update Student:** Waxaad si fudud wax uga baddali kartaa magaca, koorsada, taleefanka, ama semester-ka ardayga jira.
* **Delete Student:** Waxaad si toos ah database-ka uga tirtiri kartaa xogta ardayga adoo adeegsanaya ID-giisa.
* **Auto-Clear Fields:** Marka ay guulaystaan falalka ADD, UPDATE, ama DELETE, dhammaan Textbox-yada si otomaatig ah ayay isu nadiifiyaan, cursor-kuna wuxuu ku soo laabanayaa bilowga.

---

## 🛠️ Tech Stack (Tiknoolajiyadda la Isticmaalay)

* **Frontend UI:** C# Windows Forms (.NET Framework)
* **Data Access Layer:** LINQ to SQL ORM Framework
* **Database:** Microsoft SQL Server (SSMS)

---

## 🗄️ Database Architecture (Qaabdhismeedka Shaxda)

Mashruucu wuxuu ku tiirsan yahay Database la yiraahdo `CollegeDB` iyo shaxda `Students` oo loo naqshadeeyay sidan hoose:

```sql
-- 1. Abuur Database cusub
CREATE DATABASE CollegeDB;
GO

USE CollegeDB;
GO

-- 2. Abuur shaxda ardayda
CREATE TABLE Students (
    StudentID INT IDENTITY(1,1) PRIMARY KEY, 
    FullName VARCHAR(100) NOT NULL,
    Course VARCHAR(50) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Semester VARCHAR(20) NOT NULL
);
GO
