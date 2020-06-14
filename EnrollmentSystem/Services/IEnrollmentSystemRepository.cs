using EnrollmentSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Services
{
    public interface IEnrollmentSystemRepository
    {
        /*Student Repo*/
        IEnumerable<Student> GetStudents();
        Student GetStudent(Guid studentId);
        void AddStudent(Student student);
        void UpdateStudent(Student student);

        void DeleteStudent(Student student);
        bool StudentExists(Guid studentId);

        bool Save();

        /*Student Detail Repo*/
        StudentDetail GetStudentDetail(Guid studentId, Guid studentDetailId);
        void AddStudentDetail(Guid studentId, StudentDetail studentDetail);
        void UpdateStudentDetail(Guid studentId, StudentDetail studentDetail);
        void DeleteStudentDetail(Guid studentId, StudentDetail studentDetail);


        /*Student Requirement Repo*/
        StudentRequirement GetStudentRequirement(Guid studentId, Guid studentRequirementId);
        void AddStudentRequirements(Guid studentId, StudentRequirement studentRequirement);
        void UpdateStudentRequirement(Guid studentId, StudentRequirement studentRequirement);
        void DeleteStudentRequirement(Guid studentId, StudentRequirement studentRequirement);

        /*SchoolYear Repo*/
        SchoolYear GetStudentSchoolYear(Guid studentId, Guid studentSchoolYearId);
        void AddStudentSchoolYear(Guid studentId, SchoolYear studentSchoolYear);
        void UpdateStudentSchoolYear(Guid studentId, SchoolYear studentSchoolYear);
        void DeleteStudentSchoolYear(Guid studentId, SchoolYear studentSchoolYear);

        /*Employee Repo*/
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(Guid employeeId);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        bool EmployeeExists(Guid employeeId);

        /*Transaction Repo*/
        IEnumerable<Transaction> GetTransactions();
        Transaction GetTransaction(Guid studentId, Guid employeeId, Guid transactionId);
        void AddTransaction(Guid studentId, Guid employeeId, Transaction transaction);
        void UpdateTransaction(Guid studentId, Guid employeeId, Transaction transaction);
        void DeleteTransaction(Guid studentId, Guid employeeId, Transaction transaction);
        bool TransactionExists(Guid employeeId);
    }
}
