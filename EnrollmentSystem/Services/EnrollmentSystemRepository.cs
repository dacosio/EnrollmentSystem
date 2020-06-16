using EnrollmentSystem.DbContexts;
using EnrollmentSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace EnrollmentSystem.Services
{
    public class EnrollmentSystemRepository : IEnrollmentSystemRepository
    {
        private readonly EnrollmentContext _context;
        public EnrollmentSystemRepository(EnrollmentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _context.Employees.Add(employee);
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _context.Students.Add(student);

        }

        public void AddStudentDetail(Guid studentId, StudentDetail studentDetail)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            if (studentDetail == null)
            {
                throw new ArgumentNullException(nameof(studentDetail));
            }

            studentDetail.StudentId = studentId;
            _context.StudentDetails.Add(studentDetail);
            
        }

        public void AddStudentRequirements(Guid studentId, StudentRequirement studentRequirement)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            if (studentRequirement == null)
            {
                throw new ArgumentNullException(nameof(studentRequirement));
            }

            studentRequirement.StudentId = studentId;
            _context.StudentRequirements.Add(studentRequirement);

        }

        public void AddStudentSchoolYear(Guid studentId, SchoolYear studentSchoolYear)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            if (studentSchoolYear == null)
            {
                throw new ArgumentNullException(nameof(studentSchoolYear));
            }

            studentSchoolYear.StudentId = studentId;
            _context.SchoolYears.Add(studentSchoolYear);
        }

        public void AddTransaction(Guid studentId, Guid employeeId, Transaction transaction)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            if (employeeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            transaction.StudentId = studentId;
            transaction.EmployeeId = employeeId;

            _context.Transactions.Add(transaction);
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _context.Employees.Remove(employee);
        }

        public void DeleteStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _context.Students.Remove(student);
        }

        public void DeleteStudentDetail(Guid studentId, StudentDetail studentDetail)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            _context.StudentDetails.Remove(studentDetail);

        }

        public void DeleteStudentRequirement(Guid studentId, StudentRequirement studentRequirement)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudentSchoolYear(Guid studentId, SchoolYear studentSchoolYear)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            _context.SchoolYears.Remove(studentSchoolYear);
        }

        public void DeleteTransaction(Guid studentId, Guid employeeId, Transaction transaction)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            if (employeeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            _context.Transactions.Remove(transaction);
        }

        public bool EmployeeExists(Guid employeeId)
        {
            return _context.Employees.Any(e => e.Id == employeeId);
        }

        public Employee GetEmployee(Guid employeeId)
        {
            if (employeeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            return _context.Employees.FirstOrDefault(e => e.Id == employeeId);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.OrderBy(e => e.LastName).ThenBy(e=> e.FirstName).ToList();
        }

        public Student GetStudent(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            return _context.Students.FirstOrDefault(e => e.Id == studentId);
        }

        public StudentDetail GetStudentDetail(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            return _context.StudentDetails.FirstOrDefault(s => s.StudentId == studentId);

        }

        

        public StudentRequirement GetStudentRequirement(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            return _context.StudentRequirements.FirstOrDefault(s => s.StudentId == studentId);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.OrderByDescending(s => s.SchoolYear).ThenByDescending(s => s.LastName).ToList();
        }

        public SchoolYear GetStudentSchoolYear(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            return _context.SchoolYears.FirstOrDefault(s => s.StudentId == studentId);
        }

        public Transaction GetTransaction(Guid transactionId)
        {
            if (transactionId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(transactionId));
            }

            return _context.Transactions.FirstOrDefault(t => t.Id == transactionId);
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return _context.Transactions.OrderByDescending(t => t.DateTimePaid).ToList();
        }

       /* public IEnumerable<Transaction> GetTransactionsOfEmployee(Guid employeeId)
        {
            //return from emp in _context.Employees
            //       join tr in _context.Transactions
            //       on emp.Id equals tr.EmployeeId
            //       select new
            //       {
            //           FirstName = emp.FirstName,
            //           AmountPaid = tr.AmountPaid
            //       };

            //return _context.Transactions.Join(_context.Employees, t=>t.EmployeeId, e => e.Id)
            //    .Where(e=> e.EmployeeId == employeeId).ToList();
        }*/

        public IEnumerable<Transaction> GetTransactionsOfStudent(Guid studentId)
        {
            return _context.Transactions.Where(e => e.StudentId == studentId).ToList();
        }

        public bool Save()
        {   // this will return true if saved
            return (_context.SaveChanges() >= 0);
        }

        public bool StudentExists(Guid studentId)
        {
            return _context.Students.Any(s => s.Id == studentId);
        }

        public bool TransactionExists(Guid employeeId)
        {
            return _context.Transactions.Any(t => t.Id == employeeId);

        }

        public void UpdateEmployee(Employee employee)
        {
            //no immplemntation required
        }

        public void UpdateStudent(Student student)
        {
            //no immplemntation required
        }

        public void UpdateStudentDetail(Guid studentId, StudentDetail studentDetail)
        {
            //no immplemntation required
        }

        public void UpdateStudentRequirement(Guid studentId, StudentRequirement studentRequirement)
        {
            //no immplemntation required
        }

        public void UpdateStudentSchoolYear(Guid studentId, SchoolYear studentSchoolYear)
        {
            //no immplemntation required
        }

        public void UpdateTransaction(Guid studentId, Guid employeeId, Transaction transaction)
        {
            //no immplemntation required
        }
    }
}
